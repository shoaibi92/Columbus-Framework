/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces
{
    /// <summary>
    /// Base interface for any worker processes.   
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Execute the next piece of work if it exists.   
        /// </summary>
        void Execute();

        /// <summary>
        /// Returns the next action to execute or null if out of actions.
        /// </summary>
        /// <returns></returns>
        Action GetNextAction();
    }
}