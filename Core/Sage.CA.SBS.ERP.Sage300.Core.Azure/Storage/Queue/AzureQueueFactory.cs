/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// Queue Factory for Azure specific queues.
    /// </summary>
    public static class AzureQueueFactory
    {
        /// <summary>
        /// Create Azure Queue
        /// </summary>
        /// <param name="cloudQueue">CloudQueue</param>
        /// <returns>IQueue</returns>
        public static IQueue Create(CloudQueue cloudQueue)
        {
            return new AzureQueue(cloudQueue);
        }

        /// <summary>
        /// Create Azure Queue
        /// </summary>
        /// <returns>IQueue</returns>
        public static IQueue Create()
        {
            var queueName = ConfigurationHelper.GetConfigValue("AzureQueueName");
            return new AzureQueue(CreateQueue(queueName));
        }

        /// <summary>
        /// Creates the Azure queue hidden behind the CRE implementations
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        private static CloudQueue CreateQueue(string queueName)
        {
            CloudQueue queue = null;
            try
            {
                CloudStorageAccount storageAccount = Helper.CreateCloudStorageAccount();
                CloudQueueClient queueStorage = storageAccount.CreateCloudQueueClient();

                if (queueStorage != null)
                {
                    queue = queueStorage.GetQueueReference(queueName);

                    if (queue != null)
                        queue.CreateIfNotExists();
                }
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.QueueErrorMessage, StorageResx.Creating), ex);
            }
            return queue;
        }
    }
}