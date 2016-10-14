/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Resources;
using System.Messaging;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// MSMQ specific queue implementation
    /// </summary>
    internal class MsmqQueue : IQueue
    {
        /// <summary>
        /// Azure queue
        /// </summary>
        private readonly MessageQueue _messageQueue;

        /// <summary>
        /// Default visibility time out for queue messages, 1hr for now
        /// </summary>
        private readonly TimeSpan _visibilityTimeout = ConfigurationHelper.MessageVisibilityTimeOut;

        /// <summary>
        /// Add a scheduled message to the end of the queue
        /// </summary>
        /// <param name="message"></param>
        /// <param name="nextDateTime"></param>
        public void ScheduledEnqueue(IQueueMessage message, DateTime nextDateTime)
        {
            // ignore the schedule
            Enqueue(message);
        }

        /// <summary>
        /// Extends the time before message will be visible in the queue again
        /// </summary>
        /// <param name="message"></param>
        public void ExtendLease(IQueueMessage message)
        {
            // dothing;
        }

        /// <summary>
        /// Constructor that takes a MSMQ queue
        /// </summary>
        /// <param name="messageQueue"> MSMQ queue</param>
        public MsmqQueue(MessageQueue messageQueue)
        {
            if (messageQueue == null)
                throw new ArgumentNullException();

            _messageQueue = messageQueue;
        }

        /// <summary>
        /// Deletes a specific message from the Queue
        /// </summary>
        /// <param name="message"></param>
        public void Delete(IQueueMessage message)
        {
            // dothing
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
                _messageQueue.Send(((MsmqQueueMessage)message).QueueMessage);
            }
            catch (System.Exception e)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Enqueuing), e);
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
                _messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

                Message msg = _messageQueue.Receive(_visibilityTimeout);

                if (msg != null)
                    storageMessage = new MsmqQueueMessage(msg);
            }
            catch (MessageQueueException ex)
            {
                throw new QueueException(string.Format(StorageResx.MessageErrorMessage, StorageResx.Dequeuing), ex);
            }
            return storageMessage;
        }


        private Message PeekWithoutTimeout(MessageQueue queue, Cursor cursor, PeekAction action)
        {
            Message ret = null;
            try
            {
                queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(String) });

                ret = queue.Peek(new TimeSpan(1), cursor, action);
            }
            catch (MessageQueueException mqe)
            {
                if (!mqe.Message.ToLower().Contains("timeout"))
                {
                    throw;
                }
            }
            return ret;
        }

        private int GetMessageCount(MessageQueue queue)
        {
            int count = 0;
            Cursor cursor = queue.CreateCursor();

            Message m = PeekWithoutTimeout(queue, cursor, PeekAction.Current);
            if (m != null)
            {
                count = 1;
                while ((m = PeekWithoutTimeout(queue, cursor, PeekAction.Next)) != null)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of message sitting in the queue
        /// </summary>
        public int Count
        {
            get
            {
                int? count = GetMessageCount(_messageQueue);
                return count.Value;
            }
        }

        /// <summary>
        /// Remove all message in the queue
        /// </summary>
        public void Clear()
        {
            try
            {
                _messageQueue.Purge(); 
            }
            catch (MessageQueueException ex)
            {
                throw new QueueException(string.Format(StorageResx.QueueErrorMessage, StorageResx.Clearing), ex);
            }
        }


        /// <summary>
        /// Creates a storage queue message based on the payload
        /// </summary>
        public IQueueMessage CreateMessage(string payload)
        {
            return MsmqQueueMessageFactory.Create(payload);
        }

        /// <summary>
        /// Helper function that validates arguments passed to the public functions
        /// </summary>
        /// <param name="message"></param>
        private static void ValidateMessage(IQueueMessage message)
        {
            if (message == null)
                throw new ArgumentNullException();

            if (!(message is MsmqQueueMessage))
                throw new ArgumentException();
        }
    }
}
