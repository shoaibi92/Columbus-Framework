/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Microsoft.WindowsAzure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// A Azure queue message wrapper class
    /// </summary>
    internal class AzureQueueMessage : IQueueMessage
    {
        private readonly CloudQueueMessage _queueMessage;

        /// <summary>
        /// Creates a "empty" message
        /// </summary>
        public AzureQueueMessage()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Creates a message and sets the payload to the passed in message
        /// </summary>
        /// <param name="message"></param>
        public AzureQueueMessage(string message)
            : this(new CloudQueueMessage(message))
        {
        }

        /// <summary>
        /// Used when you already have a CloudQueueMessage(i.e. Dequeue)
        /// </summary>
        /// <param name="queueMessage"></param>
        public AzureQueueMessage(CloudQueueMessage queueMessage)
        {
            if (queueMessage == null)
                throw new ArgumentNullException();

            _queueMessage = queueMessage;
        }


        /// <summary>
        /// Id of the message.  Null until inserted
        /// </summary>
        public string Id
        {
            get { return _queueMessage.Id; }
        }

        /// <summary>
        /// Payload of the message
        /// </summary>
        public string Payload
        {
            get
            {
                return _queueMessage.AsString;
            }
        }

        public DateTimeOffset? NextVisibleTime
        {
            get
            {
                return _queueMessage.NextVisibleTime;
            }
        }

        /// <summary>
        /// Gets the Cloud Queue Message
        /// </summary>
        public CloudQueueMessage CloudQueueMessage
        {
            get { return _queueMessage; }
        }
    }
}
