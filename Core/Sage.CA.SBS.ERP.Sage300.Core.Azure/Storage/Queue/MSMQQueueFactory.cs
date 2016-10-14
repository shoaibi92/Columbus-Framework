/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System.Messaging;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// Queue Factory for MSMQ specific queues.
    /// </summary>
    static internal class MsmqQueueFactory
    {
        /// <summary>
        /// Create MSMQ Queue
        /// </summary>
        /// <param name="cloudQueue">CloudQueue</param>
        /// <returns>IQueue</returns>
        public static IQueue Create(MessageQueue cloudQueue)
        {
            return new MsmqQueue(cloudQueue);
        }

        /// <summary>
        /// Create MSMQ Queue
        /// </summary>
        /// <returns>IQueue</returns>
        public static IQueue Create()
        {
            var queueName = ConfigurationHelper.GetConfigValue("AzureQueueName");
            return new MsmqQueue(CreateQueue(queueName));
        }

        /// <summary>
        /// Creates the MSMQ queue hidden behind the CRE implementations
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        private static MessageQueue CreateQueue(string queueName)
        {
            MessageQueue queue = null;
            try
            {
                string privateQueueName = string.Format(@".\Private$\{0}", queueName);

                // Create and connect to a private Message Queuing queue. 
                if (!MessageQueue.Exists(privateQueueName))
                {
                    // Create the queue if it does not exist.
                    queue = MessageQueue.Create(privateQueueName, false);
                }
                else
                {
                    queue = new MessageQueue(privateQueueName);
                }

                queue.SetPermissions("Everyone", MessageQueueAccessRights.FullControl);
            }
            catch (System.Exception ex)
            {
                throw new QueueException(string.Format(StorageResx.QueueErrorMessage, StorageResx.Creating), ex);
            }

            return queue;
        }
    }
}