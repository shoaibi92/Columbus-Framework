/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */


using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces
{
    /// <summary>
    /// WorkFlow Manager class
    /// </summary>
    public interface IWorkflowManager
    {
        /// <summary>
        /// Create first workflow and unit of work instance and put in table
        /// </summary>
        /// <param name="personId">Initiator ID</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="workflowKindId">Kind of work 
        /// (Should be pre populated in table, before using)</param>
        /// <param name="seedEntity">The Input model/context</param>
        /// <param name="aggregateEntity">Aggregate entities</param>
        /// <param name="timeOfNextOperation">Time of next operation</param>
        /// <returns>Just Created instance</returns>
        UnitOfWorkInstance CreateAndQueueFirstUnitOfWork(Guid personId, Guid tenantId, int workflowKindId, string seedEntity,
            string aggregateEntity, DateTime? timeOfNextOperation = null);

        /// <summary>
        /// Search workflow by Status
        /// </summary>
        /// <param name="status">Status Enum</param>
        /// <returns>workflow</returns>
        IList<WorkflowInstance> FindAllWorkflowInstanceByStatus(WorkStatusType status);

        /// <summary>
        /// Search workflow by ID
        /// </summary>
        /// <param name="workflowInstanceId">ID</param>
        /// <returns>workflow</returns>
        WorkflowInstance FindWorkflowInstance(int workflowInstanceId);

        /// <summary>
        /// Update workflow's status
        /// </summary>
        /// <param name="workFlowInstanceId">ID</param>
        /// <param name="status">Status</param>
        void UpdateWorkflowStatus(int workFlowInstanceId, WorkStatusType status);

        /// <summary>
        /// Update workflow Start time
        /// </summary>
        /// <param name="workflowInstanceId">ID</param>
        void UpdateExecutionStartTime(int workflowInstanceId);

        /// <summary>
        /// Update workflow completion time
        /// </summary>
        /// <param name="workflowInstanceId">ID</param>
        void UpdateExecutionCompleteTime(int workflowInstanceId);

        /// <summary>
        /// Executed all the scheduled workflows
        /// </summary>
        void ExecuteScheduledWorkflows();

        /// <summary>
        /// Unity Container
        /// </summary>
        IUnityContainer Container { get; }

        /// <summary>
        /// Update workflow about errors
        /// </summary>
        /// <param name="workFlowInstanceId">ID</param>
        /// <param name="error">Errors</param>
        void UpdateWorkflowError(int workFlowInstanceId, string error);
    }
}
