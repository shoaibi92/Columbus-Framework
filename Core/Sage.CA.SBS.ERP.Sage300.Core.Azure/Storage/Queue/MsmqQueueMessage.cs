/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using System.Messaging;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// A MSMQ queue message wrapper class
    /// </summary>
    internal class MsmqQueueMessage : IQueueMessage
    {
        private readonly Message _queueMessage;

        /// <summary>
        /// Creates a "empty" message
        /// </summary>
        public MsmqQueueMessage()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Creates a message and sets the payload to the passed in message
        /// </summary>
        /// <param name="message"></param>
        public MsmqQueueMessage(string message)
            : this(new Message(message))
        {
        }

        /// <summary>
        /// Used when you already have a CloudQueueMessage(i.e. Dequeue)
        /// </summary>
        /// <param name="queueMessage"></param>
        public MsmqQueueMessage(Message queueMessage)
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
                return _queueMessage.Body.ToString();
            }
        }

        public DateTimeOffset? NextVisibleTime
        {
            get
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the Message
        /// </summary>
        public Message QueueMessage
        {
            get { return _queueMessage; }
        }
    }
}
