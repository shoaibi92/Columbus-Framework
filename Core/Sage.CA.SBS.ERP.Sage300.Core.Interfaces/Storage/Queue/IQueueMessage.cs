/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue
{
    /// <summary>
    /// Interface IQueueMessage
    /// </summary>
    public interface IQueueMessage
    {
        /// <summary>
        /// Id of the message only valid once placed in the queue
        /// </summary>
        /// <value>The identifier.</value>
        string Id { get; }

        /// <summary>
        /// Data
        /// </summary>
        /// <value>The payload.</value>
        string Payload { get; }

        /// <summary>
        /// 
        /// </summary>
        DateTimeOffset? NextVisibleTime { get; }
    }
}