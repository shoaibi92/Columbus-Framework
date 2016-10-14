/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue
{
    /// <summary>
    /// Abstraction around an Queue.   Basic interfaces for enqueuing messages and removing them.
    /// </summary>
    public interface IQueue
    {
        /// <summary>
        /// Enqueue a message to the queue
        /// </summary>
        /// <param name="message"></param>
        void Enqueue(IQueueMessage message);

        /// <summary>
        /// Enqueue a scheduled unit of work
        /// </summary>
        void ScheduledEnqueue(IQueueMessage message, DateTime nextDateTime);

        /// <summary>
        /// Pulls off the top message in the queue.   Message
        /// is not removed until Delete is called
        /// </summary>
        /// <returns></returns>
        IQueueMessage Dequeue();

        /// <summary>
        /// Deletes a specific message from the queue
        /// </summary>
        /// <param name="message"></param>
        void Delete(IQueueMessage message);

        /// <summary>
        /// Deletes a specific message from the queue
        /// </summary>
        /// <param name="message"></param>
        void ExtendLease(IQueueMessage message);

        /// <summary>
        /// Retrieve the number of messages sitting in the queue.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Clears our the entire queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Creates a storage queue message based on the payload
        /// </summary>
        IQueueMessage CreateMessage(string payload);
    }
}
