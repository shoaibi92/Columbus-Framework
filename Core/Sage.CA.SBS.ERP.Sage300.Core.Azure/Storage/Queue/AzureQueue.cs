/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// Azure specific queue implementation
    /// </summary>
    internal class AzureQueue : IQueue
    {
        /// <summary>
        /// Azure queue
        /// </summary>
        private readonly CloudQueue _cloudQueue;

        /// <summary>
        /// Default visibility time out for queue messages, 1hr for now
        /// </summary>
        private readonly TimeSpan _visibilityTimeout = ConfigurationHelper.MessageVisibilityTimeOut;


        /// <summary>
        /// Constructor that takes a Azure queue
        /// </summary>
        /// <param name="cloudQueue"></param>
        public AzureQueue(CloudQueue cloudQueue)
        {
            if (cloudQueue == null)
                throw new ArgumentNullException();

            _cloudQueue = cloudQueue;
        }

        /// <summary>
        /// Add a message to the end of the queue
        /// </summary>
        /// <param name="message"></param>
        public void Enqueue(IQueueMessage message)
        {
            ValidateMessage(message);

            try
            {
                _cloudQueue.AddMessage(((AzureQueueMessage)message).CloudQueueMessage);
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Enqueuing), ex);
            }
        }

        /// <summary>
        /// Add a scheduled message to the end of the queue
        /// </summary>
        /// <param name="message"></param>
        /// <param name="nextDateTime"></param>
        public void ScheduledEnqueue(IQueueMessage message, DateTime nextDateTime)
        {
            ValidateMessage(message);

            try
            {
                var cloudMessage = ((AzureQueueMessage)message).CloudQueueMessage;

                //The figure out how long the message should be invisible
                var initialVisibilityDelay = nextDateTime - DateTime.UtcNow;
                if (initialVisibilityDelay.Ticks < 0)
                    initialVisibilityDelay = new TimeSpan(0);

                // 7 days is the max time an item can be queued (from time of insertion)
                // no current reason to use less time so queue for max
                var timeToLive = new TimeSpan(7, 0, 0, 0);

                _cloudQueue.AddMessage(cloudMessage, timeToLive, initialVisibilityDelay);
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Enqueuing), ex);
            }
        }

        /// <summary>
        /// Dequeue the top item off the queue
        /// </summary>
        /// <returns></returns>
        public IQueueMessage Dequeue()
        {
            IQueueMessage storageMessage = null;
            try
            {
                CloudQueueMessage msg = _cloudQueue.GetMessage(_visibilityTimeout);

                if (msg != null)
                    storageMessage = new AzureQueueMessage(msg);
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Dequeuing), ex);
            }
            return storageMessage;
        }

        /// <summary>
        /// Deletes a specific message from the Queue
        /// </summary>
        /// <param name="message"></param>
        public void Delete(IQueueMessage message)
        {
            ValidateMessage(message);
            try
            {
                _cloudQueue.DeleteMessage(((AzureQueueMessage)message).CloudQueueMessage);
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Deleting), ex);
            }
        }


        /// <summary>
        /// Extends the time before message will be visible in the queue again
        /// </summary>
        /// <param name="message"></param>
        public void ExtendLease(IQueueMessage message)
        {
            ValidateMessage(message);
            try
            {
                _cloudQueue.UpdateMessage(((AzureQueueMessage)message).CloudQueueMessage, _visibilityTimeout, MessageUpdateFields.Visibility);
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.ExtendingLease), ex);
            }
        }

        /// <summary>
        /// Returns the number of message sitting in the queue
        /// </summary>
        public int Count
        {
            get
            {
                int? count = _cloudQueue.ApproximateMessageCount;
                return count.HasValue ? count.Value : 0;
            }
        }

        /// <summary>
        /// Remove all message in the queue
        /// </summary>
        public void Clear()
        {
            try
            {
                _cloudQueue.Clear();
            }
            catch (StorageException ex)
            {
                throw new QueueException(string.Format(StorageResx.QueueErrorMessage, StorageResx.Clearing), ex);
            }
        }


        /// <summary>
        /// Creates a storage queue message based on the payload
        /// </summary>
        public IQueueMessage CreateMessage(string payload)
        {
            return AzureQueueMessageFactory.Create(payload);
        }

        /// <summary>
        /// Helper function that validates arguments passed to the public functions
        /// </summary>
        /// <param name="message"></param>
        private static void ValidateMessage(IQueueMessage message)
        {
            if (message == null)
                throw new ArgumentNullException();

            // Not supported based on this implementation.  We reply on the underlying implementation 
            // being the specific type.
            if (!(message is AzureQueueMessage))
                throw new ArgumentException();
        }
    }
}
