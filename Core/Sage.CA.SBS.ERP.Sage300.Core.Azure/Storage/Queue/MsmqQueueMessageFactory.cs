/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue
{
    /// <summary>
    /// Queue Factory for MSMQ specific queues.
    /// </summary>
    internal static class MsmqQueueMessageFactory
    {

        /// <summary>
        /// Create MSMQ queue
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public static IQueueMessage Create(string payload)
        {
            return new MsmqQueueMessage(payload);
        }
    }
}
