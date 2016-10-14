/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table.Queryable;
using Sage.CA.SBS.ERP.Sage300.Common.Cryptography;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using System;
using System.IO;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;
using System.Security;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage
{
    /// <summary>
    /// Helper class for Uploading/downloading data
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Batch Count
        /// </summary>
        public const int BatchCount = 100;

        /// <summary>
        /// This is used as a key in defining the blob metadata
        /// </summary>
        public const string Persistent = "Persistent";

        /// <summary>
        /// Import blob directory for Import OFX Statements
        /// </summary>
        public const string ImportOfxDirectory = "importofxstatement";

        /// <summary>
        /// Export blob directory 
        /// </summary>
        public const string ExportDirectory = "export";

        /// <summary>
        /// Import blob directory
        /// </summary>
        public const string ImportDirectory = "import";

        /// <summary>
        /// CPRS blob directory
        /// </summary>
        public const string CPRSDirectory = "CPRS";

       

        //Note: Consider general usage of the upload and downloads
        //We are already doing this but if these are large blobs we might be better served with streams....

        /// <summary>
        /// Upload Byte Array
        /// </summary>
        /// <param name="blob">Cloud Blob</param>
        /// <param name="value">The actual byte of data</param>
        /// <param name="accessCondition">Access Condition</param>
        internal static void UploadByteArray(this ICloudBlob blob, byte[] value, AccessCondition accessCondition = null)
        {
            using (var stream = new MemoryStream(value))
            {
                blob.UploadFromStream(stream, accessCondition);
            }
        }

        /// <summary>
        /// Upload Text to cloud
        /// </summary>
        /// <param name="blob">Cloud Blob</param>
        /// <param name="value">The text value</param>
        internal static void UploadText(this ICloudBlob blob, string value)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                blob.UploadFromStream(stream);
            }
        }

        /// <summary>
        /// Upload the complete file to cloud
        /// </summary>
        /// <param name="blob">cloud blob</param>
        /// <param name="fileName">Complete File Path</param>
        internal static void UploadFile(this ICloudBlob blob, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                blob.UploadFromStream(stream);
            }
        }

        /// <summary>
        /// Download text from cloud
        /// </summary>
        /// <param name="blob">cloud blob</param>
        /// <returns>the downloaded text</returns>
        internal static string DownloadText(this ICloudBlob blob)
        {
            MemoryStream stream = null;
            StreamReader reader = null;
            try
            {
                stream = new MemoryStream();
                blob.DownloadToStream(stream);
                reader = new StreamReader(stream, true);
                stream.Position = 0;
                return reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Dispose();
                }
                else if (stream != null)
                {
                    stream.Dispose();
                }

            }
        }

        /// <summary>
        /// Download Byte Array
        /// </summary>
        /// <param name="blob">Cloud Blob</param>
        /// <returns>Downloaded byte</returns>
        internal static byte[] DownloadByteArray(this ICloudBlob blob)
        {
            using (var stream = new MemoryStream())
            {
                blob.DownloadToStream(stream);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Create Cloud storage account, using the connection string
        /// </summary>
        /// <returns>CloudStorageAccount instance</returns>
        internal static CloudStorageAccount CreateCloudStorageAccount()
        {
            return
                CloudStorageAccount.Parse(string.IsNullOrEmpty(ConfigurationHelper.DataCryptoThumbprint)
                    ? ConfigurationHelper.SystemStorageConnectionString
                    : DecryptAzureStorageConnStr(ConfigurationHelper.SystemStorageConnectionString));
        }

        /// <summary>
        /// Verify table name. If invalid throws argument exception error.
        /// </summary>
        /// <param name="tableName">Azure Table Name</param>
        internal static void VerifyTableName(string tableName)
        {
            if (!IsValidTableName(tableName))
            {
                throw new ArgumentException("Invalid table name.");
            }
        }

        /// <summary>
        /// Add entities in batch asynchronously
        /// </summary>
        /// <param name="table">Cloud Table</param>
        /// <param name="entities">Entities</param>
        /// <returns>List of asynchronus tasks</returns>
        internal static List<Task<IList<TableResult>>> AddEntitiesInBatchesAsync(CloudTable table,
            List<ITableEntity> entities)
        {
            var batches = new Dictionary<string, TableBatchOperation>();
            var tasks = new List<Task<IList<TableResult>>>();
            foreach (var entity in entities)
            {
                TableBatchOperation batch;

                if (batches.TryGetValue(entity.PartitionKey, out batch) == false)
                {
                    batches[entity.PartitionKey] = batch = new TableBatchOperation();
                }

                batch.Add(TableOperation.Insert(entity));

                if (batch.Count == BatchCount)
                {
                    tasks.Add(table.ExecuteBatchAsync(batch));
                    batches[entity.PartitionKey] = new TableBatchOperation();
                }
            }
            foreach (var batch in batches.Values)
            {
                if (batch.Count > 0)
                {
                    tasks.Add(table.ExecuteBatchAsync(batch));
                }
            }
            return tasks;
        }

        /// <summary>
        /// Delete All Entities in Batch
        /// </summary>
        /// <param name="table">Cloud Table</param>
        /// <param name="filter">Filter</param>
        internal static void DeleteAllEntitiesInBatches(CloudTable table,
            Expression<Func<DynamicTableEntity, bool>> filter)
        {
            Action<IEnumerable<DynamicTableEntity>> processor = entities =>
            {
                var batches = new Dictionary<string, TableBatchOperation>();

                foreach (var entity in entities)
                {
                    TableBatchOperation batch;

                    if (batches.TryGetValue(entity.PartitionKey, out batch) == false)
                    {
                        batches[entity.PartitionKey] = batch = new TableBatchOperation();
                    }

                    batch.Add(TableOperation.Delete(entity));

                    if (batch.Count == BatchCount)
                    {
                        table.ExecuteBatch(batch);
                        batches[entity.PartitionKey] = new TableBatchOperation();
                    }
                }

                foreach (var batch in batches.Values)
                {
                    if (batch.Count > 0)
                    {
                        table.ExecuteBatch(batch);
                    }
                }
            };

            ProcessEntities(table, processor, filter);
        }


        /// <summary>
        /// Decrypt Azure Storage Connection string
        /// </summary>
        /// <param name="connectionString">connection string to decrypt</param>
        /// <returns>decrypted connection string</returns>
        private static string DecryptAzureStorageConnStr(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            // Get the AccountKey value from Connection string
            var storageKey = new StringBuilder();

            var accountKey =
                new StringBuilder(connectionString.Split(';').FirstOrDefault(data => data.StartsWith("AccountKey")));
            if (!string.IsNullOrEmpty(accountKey.ToString()))
            {
                var index = accountKey.ToString().IndexOf('=');
                storageKey.Append(accountKey.ToString().Substring(index + 1));
            }
            else
            {
                throw new Exception("Invalid storage connection string.");
            }

            // Read the Account Key from cache. If AccountKey not available in cache, Decrypt it from connection string.
            var encryptedAccountKey = InMemoryCacheProvider.Instance.Get<SecureString>(connectionString);
            if (encryptedAccountKey == null)
            {
                encryptedAccountKey = CertificateCryptography.SecureDecrypt(storageKey.ToString().Trim(),
                    ConfigurationHelper.DataCryptoThumbprint);
                InMemoryCacheProvider.Instance.Set(connectionString, encryptedAccountKey);
            }

            return connectionString.Replace(storageKey.ToString().Trim(),
                CertificateCryptography.SecureStringToString(encryptedAccountKey));
        }

        /// <summary>
        /// Is Valid Table Name
        /// </summary>
        /// <param name="tableName">Azure Table Name</param>
        /// <returns>Result</returns>
        private static bool IsValidTableName(string tableName)
        {
            return Regex.IsMatch(tableName, "^[A-Za-z][A-Za-z0-9]{2,62}$", RegexOptions.Compiled);
        }

        /// <summary>
        /// Process Entities
        /// </summary>
        /// <param name="table">Cloud Table</param>
        /// <param name="processor">Processor</param>
        /// <param name="filter">Filter</param>
        private static void ProcessEntities(CloudTable table,
                           Action<IEnumerable<DynamicTableEntity>> processor,
                           Expression<Func<DynamicTableEntity, bool>> filter)
        {
            TableQuerySegment<DynamicTableEntity> segment = null;

            while (segment == null || segment.ContinuationToken != null)
            {
                if (filter == null)
                {
                    segment = table.ExecuteQuerySegmented(new TableQuery().Take(BatchCount), segment == null ? null : segment.ContinuationToken);
                }
                else
                {
                    var query = table.CreateQuery<DynamicTableEntity>().Where(filter).Take(BatchCount).AsTableQuery();
                    segment = query.ExecuteSegmented(segment == null ? null : segment.ContinuationToken);
                }

                processor(segment.Results);
            }
        }
       
    }
}
