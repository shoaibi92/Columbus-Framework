/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces
{
    /// <summary>
    /// Manager for Unit Of Work (each work item in a workflow)
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// Create - First
        /// </summary>
        /// <param name="workflowInstance">workflow ID</param>
        /// <param name="aggregateEntity">Aggregate Entity</param>
        /// <returns>UnitOfWork Instanace</returns>
        UnitOfWorkInstance CreateFirstUnitOfWorkInstance(WorkflowInstance workflowInstance, string aggregateEntity);

        /// <summary>
        /// Create - Other/Next
        /// </summary>
        /// <param name="workflowInstanceId">workflow ID</param>
        /// <param name="unitOfWorkKindId">Kind</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="aggregateEntity">Aggregate Entity</param>
        /// <returns>UnitOfWorkInstance</returns>
        UnitOfWorkInstance CreateUnitOfWorkInstance(int workflowInstanceId, int unitOfWorkKindId, Guid tenantId, string aggregateEntity);

        /// <summary>
        /// Search by workflow ID
        /// </summary>
        /// <param name="workflowInstanceId">workflow ID</param>
        /// <returns>UnitOfWorkInstance</returns>
        UnitOfWorkInstance FindCurrentUnitOfWorkInstance(int workflowInstanceId);

        /// <summary>
        /// Get Current work
        /// </summary>
        /// <param name="workFlowInstanceId">workflow ID</param>
        /// <returns>UnitOfWorkInstance</returns>
        List<UnitOfWorkInstance> FindExecutedUnitOfWorkInstances(int workFlowInstanceId);

        /// <summary>
        /// Search by ID
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <returns>UnitOfWorkInstance</returns>
        UnitOfWorkInstance FindUnitOfWorkInstance(int unitOfWorkInstanceId);

        /// <summary>
        /// Increment retry count
        /// </summary>
        /// <param name="retryUnitOfWorkId">ID</param>
        void IncrementRetryCount(int retryUnitOfWorkId);

        /// <summary>
        /// Loop to next work item
        /// </summary>
        /// <param name="previousUnitOfWorkInstanceId">Previous ID</param>
        /// <returns>UnitOfWorkInstance</returns>
        UnitOfWorkInstance ProgressToNextUnitOfWorkInstance(int previousUnitOfWorkInstanceId);

        /// <summary>
        /// Get next Kind of work
        /// </summary>
        /// <param name="currentUnitOfWork">Current type</param>
        /// <returns>work kind</returns>
        UnitOfWorkKind ReadNextUnitOfWorkKind(UnitOfWorkInstance currentUnitOfWork);

        /// <summary>
        /// get/initialize all work kinds
        /// </summary>
        Dictionary<int, UnitOfWorkKind> UnitOfWorkKinds { get; }

        /// <summary>
        /// Update work item with errors
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <param name="error">Error</param>
        void UpdateUnitOfWorkWithError(int unitOfWorkInstanceId, string error);

        /// <summary>
        /// Update work item with Result
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <param name="result">Result - EntityResult</param>
        void UpdateUnitOfWorkWithResult(int unitOfWorkInstanceId, string result);

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <param name="status">Status</param>
        void UpdateUnitOfWorkStatus(int unitOfWorkInstanceId, WorkStatusType status);

        /// <summary>
        /// Read first kind
        /// </summary>
        /// <param name="workflowKindId">kind ID</param>
        /// <returns>Unit Of work kind instance</returns>
        UnitOfWorkKind ReadFirstUnitOfWorkKind(int workflowKindId);

        /// <summary>
        /// Update executiontime
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        void UpdateExecutionStartTime(int unitOfWorkInstanceId);

        /// <summary>
        /// Update Complete time
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        void UpdateExecutionCompleteTime(int unitOfWorkInstanceId);

        /// <summary>
        /// Update the address (IP and Port) of the worker instance into datatbase
        /// </summary>
        /// <param name="unitOfWorkInstanceId">Unit Of Work Instance Id</param>
        /// <param name="address">IP address</param>
        /// <param name="port"></param>
        void UpdateWorkerRoleAddress(int unitOfWorkInstanceId, string address, string port);
    }
}
