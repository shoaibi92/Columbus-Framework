/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces
{
    /// <summary>
    /// Interface for all queue processors
    /// </summary>
    public interface IQueueProcessor
    {
        /// <summary>
        /// Do the actual work implemented in unit of work classes
        /// </summary>
        /// <param name="message">Queue message</param>
        /// <returns>status</returns>
        bool DoWork(IQueueMessage message);
    }
}