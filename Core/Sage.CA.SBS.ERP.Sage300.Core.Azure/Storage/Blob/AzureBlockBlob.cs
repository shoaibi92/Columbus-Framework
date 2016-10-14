/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.Globalization;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob
{
    /// <summary>
    /// Azure-specific blob implementation
    /// </summary>
    public class AzureBlockBlob : IBlob
    {
        #region Private Members

        /// <summary>
        /// Cloud blob being wrapped
        /// </summary>
        private readonly CloudBlockBlob _cloudBlob;
        private static AzureBlockBlob _blockBlob;

        #endregion

        #region Properties

        public CloudBlockBlob CloudBlob { get { return _cloudBlob; }}
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor specifying the cloud blob instance
        /// </summary>
        /// <param name="cloudBlob"></param>
        public AzureBlockBlob(CloudBlockBlob cloudBlob)
        {
            if (cloudBlob == null)
            {
                throw new ArgumentNullException();
            }

            _cloudBlob = cloudBlob;
        }

        #endregion


        #region IStorageBlob Members

        /// <summary>
        /// Download blob contents as a string
        /// </summary>
        /// <returns></returns>
        public string DownloadText()
        {
            try
            {
                return _cloudBlob.DownloadText();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Upload text to the blob
        /// </summary>
        /// <param name="text"></param>
        public void UploadText(string text)
        {
            try
            {
                _cloudBlob.UploadText(text);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobUploadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Delete the blob
        /// </summary>
        public void Delete()
        {
            try
            {
                _cloudBlob.Delete();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDeleteError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Retrieve the specified blob
        /// </summary>
        /// <returns>Stream containing blob</returns>
        public byte[] DownloadByteArray()
        {
            try
            {
                return _cloudBlob.DownloadByteArray();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Retrieve the specified blob as stream
        /// </summary>
        /// <param name="stream">Output stream</param>
        public void DownloadStream(Stream stream)
        {
            try
            {
                _cloudBlob.DownloadToStream(stream);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Uploads the byte array to blob
        /// </summary>
        public void UploadByteArray(byte[] content)
        {
            UploadByteArray(content, false);
        }

        /// <summary>
        /// Uploads the byte array to blob
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="isPersistent">If true blob will not be deleted automatically.</param>
        public void UploadByteArray(byte[] content, bool isPersistent)
        {
            try
            {
                _cloudBlob.UploadByteArray(content);
                if (isPersistent)
                {
                    _cloudBlob.Metadata[Helper.Persistent] = "1";
                    _cloudBlob.SetMetadata();
                }
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Uploads the byte array to blob
        /// </summary>
        /// <param name="content">Content</param>
        /// <param name="blobAccessCondition">Represents a set of access conditions to be used for operations against the blob services.</param>
        public void UploadByteArray(byte[] content, BlobAccessCondition blobAccessCondition)
        {
            try
            {
                AccessCondition condition = null;
                if (blobAccessCondition == BlobAccessCondition.IfNoneMatchETag)
                {
                    condition = new AccessCondition {IfNoneMatchETag = "*"};
                }
                _cloudBlob.UploadByteArray(content, condition);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Uploads the stream to blob
        /// </summary>
        public bool UploadStream(Stream content)
        {
            try
            {
                _cloudBlob.UploadFromStream(content);
                return true;
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Uploads the file
        /// </summary>
        public void UploadFile(string fileName)
        {
            try
            {
                _cloudBlob.UploadFile(fileName);
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// Method to upload individual blocks of file
        /// </summary>
        /// <param name="blockOffset">Current block number</param>
        /// <param name="blockContent">Current block content</param>
        /// <returns></returns>
        public bool UploadBlock(long blockOffset, byte[] blockContent)
        {
            try
            {
                string blockId = EncodeOffset(blockOffset);
                string contentMd5 = CalculateMD5(blockContent);
                using (var stream = new MemoryStream(blockContent))
                {
                    _cloudBlob.PutBlock(blockId, stream, contentMd5);
                }

                return true;
            }
            catch (StorageException e)
            {
                throw new BlobStorageException(
                    string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), e);
            }
        }

        /// <summary>
        /// Method to commit all the uploaded chunks
        /// </summary>
        public void CommitUploadedBlocks()
        {
            // download the list of blocks that were uploaded
            var blockList = _cloudBlob.DownloadBlockList(BlockListingFilter.All);

            // sort the blocks by their offset
            var orderedBlockList = blockList.OrderBy(block =>
            {
                var currentOffset = DecodeOffset(block.Name);
                return currentOffset;
            });

            // ensure that there are no gaps in the sequence
            long offset = 0;
            foreach (var block in orderedBlockList)
            {
                var currentOffset = DecodeOffset(block.Name);

                if (currentOffset != offset)
                {
                    throw new InvalidDataException("One or more chunks of the uploaded file were found missing.");
                }
                offset += 1;
            }

            // commit the list of uploaded blocks
            _cloudBlob.PutBlockList(orderedBlockList.Select(p => p.Name));
        }

        /// <summary>
        /// Get the URI for the blob 
        /// </summary>
        public Uri Uri
        {
            get { return _cloudBlob.Uri; }
        }

        /// <summary>
        /// Open stream to read blob's content
        /// </summary> 
        /// <returns>Stream containing blob</returns>
        public Stream OpenRead()
        {
            try
            {
                return _cloudBlob.OpenRead();
            }
            catch (StorageException err)
            {
                throw new BlobStorageException(string.Format(StorageResx.BlobDownloadTextError, _cloudBlob.Uri), err);
            }
        }

        /// <summary>
        /// SetMetadata
        /// </summary>
        /// <param name="dictionary">List of metadata</param>
        public void SetMetadata(Dictionary<string, string> dictionary)
        {
            foreach (var item in dictionary)
            {
                _cloudBlob.Metadata[item.Key] = item.Value;
            }
            _cloudBlob.SetMetadata();
        }

        /// <summary>
        /// Returns the length (in bytes) of the blob
        /// </summary>
        public long Length
        {
            get { return _cloudBlob.Properties.Length; }
        }

       /// <summary>
        ///  Check whether blob is valid.
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsBlobValid(string blobName, Context context)
        {
            var blob = _blockBlob; //GetBlob(blobName, context) as AzureBlockBlob;
            if (blob != null && blob.CloudBlob.Exists())
            {
                blob.CloudBlob.FetchAttributes();
                if (blob.CloudBlob.Properties.LastModified.HasValue)
                    if (blob.CloudBlob.Properties.LastModified.Value.Date >= DateTime.UtcNow.Date)
                        return true;

            }
            return false;
        }

        public static IBlob GetBlob(string blobName, Context context)
        {
            if (!Configuration.ConfigurationHelper.IsSageKPICachEnabled)
            {
                return null;
            }
            var commonService = context.Container.Resolve<ICommonService>(new ParameterOverride("context", context));
            var container = commonService.GetBlobContainer();
            var subDirectory = container.GetDirectoryReference("CNADataCache");
            var hashedblobName = blobName.GetHashCode().ToString(CultureInfo.InvariantCulture);
            
            _blockBlob = subDirectory.GetBlobReference(hashedblobName) as AzureBlockBlob;
            return _blockBlob;
        }
        #endregion

        #region Private Methods

        private string CalculateMD5(byte[] input)
        {
            using (var cryptoService = MD5.Create())
            {
                var md5 = cryptoService.ComputeHash(input);
                return Convert.ToBase64String(md5);
            }
        }

        private string EncodeOffset(long offset)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(offset));
        }

        private long DecodeOffset(string blockId)
        {
            return BitConverter.ToInt64(Convert.FromBase64String(blockId), 0);
        }

        #endregion
    }
}
