/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Workflow.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess.Interfaces
{
    /// <summary>
    /// Interface IWorkflowContext
    /// </summary>
    public interface IWorkflowContext : IDisposable
    {
        /// <summary>
        /// Returns UnitOfWorkInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<UnitOfWorkInstance> UnitOfWorkInstanceRepository();

        /// <summary>
        /// Returns UnitOfWorkKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<UnitOfWorkKind> UnitOfWorkKindRepository();

        /// <summary>
        /// Returns WorkflowInstanceRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowInstance> WorkflowInstanceRepository();

        /// <summary>
        /// Returns WorkflowKindRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowKind> WorkflowKindRepository();

        /// <summary>
        /// Returns WorkflowScheduleRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkflowSchedule> WorkflowScheduleRepository();

        /// <summary>
        /// Returns WorkStatusRepository
        /// </summary>
        /// <returns>GenericRepository</returns>
        GenericRepository<WorkStatus> WorkStatusRepository();

        /// <summary>
        /// Save
        /// </summary>
        void Save();
    }
}