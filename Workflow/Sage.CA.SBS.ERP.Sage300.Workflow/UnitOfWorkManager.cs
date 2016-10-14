/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// work manager class
    /// </summary>
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly IWorkflowManager _workflowManager;

        /// <summary>
        /// Constructor, which will initialize the class with workflow manager
        /// </summary>
        /// <param name="workflowManager">workflow manager</param>
        internal UnitOfWorkManager(IWorkflowManager workflowManager)
        {
            _workflowManager = workflowManager;
            UnitOfWorkKinds = new Dictionary<int, UnitOfWorkKind>();
            using (var context = new WorkflowContext())
            {
                foreach (var unitOfWorkKind in context.UnitOfWorkKindRepository().Get())
                {
                    UnitOfWorkKinds.Add(unitOfWorkKind.UnitOfWorkKindId, unitOfWorkKind);
                }
            }
        }

        /// <summary>
        /// Create new unit of work instance
        /// </summary>
        /// <param name="workflowInstanceId">WorkflowInstance ID</param>
        /// <param name="unitOfWorkKindId">ID</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="aggregateEntity">Agg Entity</param>
        /// <returns></returns>
        public UnitOfWorkInstance CreateUnitOfWorkInstance(int workflowInstanceId, int unitOfWorkKindId, Guid tenantId, string aggregateEntity)
        {
            var kind = UnitOfWorkKinds[unitOfWorkKindId];
            using (var context = new WorkflowContext())
            {
                var instance = new UnitOfWorkInstance
                {
                    UnitOfWorkKindId = kind.UnitOfWorkKindId,
                    WorkflowInstanceId = workflowInstanceId,
                    TenantId = tenantId,
                    WorkStatusType = WorkStatusType.Executing,
                    RetryCount = 0,
                    AggregateEntity = aggregateEntity,
                    ErrorMessage = string.Empty,
                    DateCreated = DateTime.UtcNow
                };
                context.UnitOfWorkInstanceRepository().Insert(instance);
                context.Save();
                return instance;
            }
        }

        /// <summary>
        /// Update status
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <param name="status">Status</param>
        public void UpdateUnitOfWorkStatus(int unitOfWorkInstanceId, WorkStatusType status)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                instance.WorkStatusType = status;
                context.Save();
            }
        }

        /// <summary>
        /// Update Errors
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <param name="error">Status</param>
        public void UpdateUnitOfWorkWithError(int unitOfWorkInstanceId, string error)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                instance.ErrorMessage = error;
                context.Save();
            }
        }

        /// <summary>
        /// Search work
        /// </summary>
        /// <param name="unitOfWorkInstanceId">ID</param>
        /// <returns>Unit of work instance</returns>
        public UnitOfWorkInstance FindUnitOfWorkInstance(int unitOfWorkInstanceId)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                return context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
            }
        }

        /// <summary>
        /// Find current Work
        /// </summary>
        /// <param name="workFlowInstanceId">Workflow ID</param>
        /// <returns>All Executing works</returns>
        public List<UnitOfWorkInstance> FindExecutedUnitOfWorkInstances(int workFlowInstanceId)
        {
            if (workFlowInstanceId == 0) throw new ArgumentNullException("workFlowInstanceId");

            using (var context = new WorkflowContext())
            {
                return
                    context.UnitOfWorkInstanceRepository()
                        .Get(unitOfWorkInstance => unitOfWorkInstance.WorkflowInstanceId == workFlowInstanceId).ToList();
            }
        }

        /// <summary>
        /// Find current work in the workflow
        /// </summary>
        /// <param name="workflowInstanceId">Workflow Id</param>
        /// <returns>unit of work instance</returns>
        public UnitOfWorkInstance FindCurrentUnitOfWorkInstance(int workflowInstanceId)
        {
            if (workflowInstanceId == 0) throw new ArgumentNullException("workflowInstanceId");
            using (var context = new WorkflowContext())
            {
                //This will fail if we get in a state where multiple unit of works are marked as executing
                //Failure is intended and expected as this should not occur
                var unitOfWorkInstances =
                    context.UnitOfWorkInstanceRepository()
                        .Get(unitOfWorkInstance => unitOfWorkInstance.WorkflowInstanceId == workflowInstanceId &&
                                                   (unitOfWorkInstance.WorkStatusId == (int)WorkStatusType.Executing ||
                                                    unitOfWorkInstance.WorkStatusId == (int)WorkStatusType.Error)).ToList();
                if (unitOfWorkInstances.Count != 1)
                {
                    return null;
                }
                return unitOfWorkInstances[0];
            }
        }

        /// <summary>
        /// Create and queue up the first unit of work
        /// </summary>
        public UnitOfWorkInstance CreateFirstUnitOfWorkInstance(WorkflowInstance workflowInstance,
            string aggregateEntity)
        {
            if (workflowInstance == null) throw new ArgumentNullException("workflowInstance");

            var firstKind = ReadFirstUnitOfWorkKind(workflowInstance.WorkflowKindId);
            if (firstKind == null)
                throw new Exception(string.Format("First unit of work is not defined for workflow kind: '{0}'",
                    workflowInstance.WorkflowKindId));

            var firstInstance = CreateUnitOfWorkInstance(workflowInstance.WorkflowInstanceId, firstKind.UnitOfWorkKindId,
                workflowInstance.TenantId, aggregateEntity);

            return firstInstance;
        }

        /// <summary>
        /// Marks the supplied unit of work as completed and returns the next unit of work
        /// If there are no units of work remaining a null value will be returned
        /// </summary>
        public UnitOfWorkInstance ProgressToNextUnitOfWorkInstance(int previousUnitOfWorkInstanceId)
        {
            if (previousUnitOfWorkInstanceId == 0) throw new ArgumentNullException("previousUnitOfWorkInstanceId");
            UnitOfWorkInstance nextInstance;

            using (var context = new WorkflowContext())
            {
                var current = context.UnitOfWorkInstanceRepository().GetById(previousUnitOfWorkInstanceId);
                var nextKind = ReadNextUnitOfWorkKind(current);
                if (nextKind == null) return null;
                nextInstance = CreateUnitOfWorkInstance(current.WorkflowInstanceId, nextKind.UnitOfWorkKindId,
                    current.TenantId, current.AggregateEntity);
            }

            return nextInstance;
        }

        /// <summary>
        /// Read next work kind
        /// </summary>
        /// <param name="currentUnitOfWork"></param>
        /// <returns></returns>
        public UnitOfWorkKind ReadNextUnitOfWorkKind(UnitOfWorkInstance currentUnitOfWork)
        {
            var currentKind = UnitOfWorkKinds[currentUnitOfWork.UnitOfWorkKindId];

            return (from k in UnitOfWorkKinds
                    where k.Value.ExecutionOrder == currentKind.ExecutionOrder + 1 &&
                    k.Value.WorkflowKindId == currentKind.WorkflowKindId
                    select k).SingleOrDefault().Value;
        }

        /// <summary>
        /// Read first work kind
        /// </summary>
        /// <param name="workflowKindId"></param>
        /// <returns></returns>
        public UnitOfWorkKind ReadFirstUnitOfWorkKind(int workflowKindId)
        {
            return (from k in UnitOfWorkKinds
                    where k.Value.ExecutionOrder == 1 &&
                    k.Value.WorkflowKindId == workflowKindId
                    select k).SingleOrDefault().Value;
        }

        /// <summary>
        /// increment retry count
        /// </summary>
        /// <param name="retryUnitOfWorkId">count</param>
        public void IncrementRetryCount(int retryUnitOfWorkId)
        {
            if (retryUnitOfWorkId == 0) throw new ArgumentNullException("retryUnitOfWorkId");
            using (var context = new WorkflowContext())
            {
                var unitOfWorkInstance = context.UnitOfWorkInstanceRepository().GetById(retryUnitOfWorkId);
                unitOfWorkInstance.RetryCount += 1;
                context.Save();
            }
        }

        /// <summary>
        /// update execution start time
        /// </summary>
        /// <param name="unitOfWorkInstanceId">Id</param>
        public void UpdateExecutionStartTime(int unitOfWorkInstanceId)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var unitOfWorkInstance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                unitOfWorkInstance.DateStartExecution = DateTime.UtcNow;
                context.Save();
            }
        }

        /// <summary>
        /// update execution complete time
        /// </summary>
        /// <param name="unitOfWorkInstanceId">Id</param>
        public void UpdateExecutionCompleteTime(int unitOfWorkInstanceId)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var unitOfWorkInstance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                unitOfWorkInstance.DateCompleteExecution = DateTime.UtcNow;
                context.Save();
            }
        }

        /// <summary>
        /// all work kinds
        /// </summary>
        public Dictionary<int, UnitOfWorkKind> UnitOfWorkKinds { get; set; }

        /// <summary>
        /// get workflow manager
        /// </summary>
        public IWorkflowManager WorkflowManager
        {
            get { return _workflowManager; }
        }

        /// <summary>
        /// Update result to database
        /// </summary>
        /// <param name="unitOfWorkInstanceId"></param>
        /// <param name="result"></param>
        public void UpdateUnitOfWorkWithResult(int unitOfWorkInstanceId, string result)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                instance.ResultEntity = result;
                context.Save();
            }
        }

        /// <summary>
        /// update worker Id - IP
        /// </summary>
        /// <param name="unitOfWorkInstanceId">workflow Id</param>
        /// <param name="address">IP address</param>
        /// <param name="port">Port number</param>
        public void UpdateWorkerRoleAddress(int unitOfWorkInstanceId, string address, string port)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
                instance.WorkerRoleAddress = address;
                instance.WorkerRolePort = port;
                context.Save();
            }
        }
    }
}
