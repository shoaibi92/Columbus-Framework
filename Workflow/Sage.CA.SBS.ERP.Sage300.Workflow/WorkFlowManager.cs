/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// Work flow manager class
    /// </summary>
    [Serializable]
    public class WorkflowManager : IWorkflowManager
    {
        private readonly IQueue _queue;
        private static IDictionary<int, WorkflowKind> _workflowKindsCache;
        private static readonly object WorkflowKindsCacheLock = new object();
        private static IUnityContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="queue">Queue</param>
        /// <param name="container">Unity Container</param>
        internal WorkflowManager(IQueue queue, IUnityContainer container)
        {
            if (queue != null)
                _queue = queue;
            if(container != null)
                _container = container;
        }

        /// <summary>
        /// Creates the instances of a workflow and its first unit of work in the data store and optionally enqueues it
        /// for a the specified time.
        /// </summary>
        public UnitOfWorkInstance CreateAndQueueFirstUnitOfWork(Guid personId, Guid tenantId, int workflowKindId, string seedEntity,
            string aggregateEntity, DateTime? timeOfNextOperation)
        {
            return InternalCreateAndQueueFirstUnitOfWork(personId, tenantId, workflowKindId, seedEntity, aggregateEntity, null,
                                                  timeOfNextOperation);
        }

        /// <summary>
        /// Create UOW
        /// </summary>
        /// <param name="personId">initiator ID</param>
        /// <param name="tenanatId">Tenant Id</param>
        /// <param name="workflowKindId">Kind Id</param>
        /// <param name="seedEntity">Seed Entity</param>
        /// <param name="aggregateEntity">Agg. Entity</param>
        /// <param name="scheduledWorkflowId">Workflow Schedule Id</param>
        /// <param name="timeOfNextOperation">Time of next operation</param>
        /// <returns></returns>
        public UnitOfWorkInstance InternalCreateAndQueueFirstUnitOfWork(Guid personId, Guid tenanatId, int workflowKindId, string seedEntity,
            string aggregateEntity, int? scheduledWorkflowId, DateTime? timeOfNextOperation)
        {
            var workflowInstance = CreateNewWorkflowInstance(personId, tenanatId, scheduledWorkflowId, workflowKindId, seedEntity);
            IUnitOfWorkManager manager = UnitOfWorkManagerFactory.Create(this);
            var unitOfWorkInstance = manager.CreateFirstUnitOfWorkInstance(workflowInstance, aggregateEntity);

            //Queue the workflow
            var message = _queue.CreateMessage(unitOfWorkInstance.UnitOfWorkInstanceId.ToString(CultureInfo.InvariantCulture));
            if (timeOfNextOperation != null)
                _queue.ScheduledEnqueue(message, (DateTime)timeOfNextOperation);
            else
                _queue.Enqueue(message);
            return unitOfWorkInstance;
        }

        /// <summary>
        /// Create new workflow
        /// </summary>
        /// <param name="personId">Initiator Id</param>
        /// <param name="tenantId">Tenant Id</param>
        /// <param name="workflowScheduleId">Schedule Id</param>
        /// <param name="workflowKindId">Kind Id</param>
        /// <param name="seedEntity">Seed Entity</param>
        /// <returns>Workflow Instance</returns>
        public WorkflowInstance CreateNewWorkflowInstance(Guid personId, Guid tenantId, int? workflowScheduleId, int workflowKindId, string seedEntity)
        {
            using (var context = new WorkflowContext())
            {
                var kind = WorkflowKinds[workflowKindId];
                var workflowInstance = new WorkflowInstance
                {
                    WorkflowScheduleId = workflowScheduleId,
                    InitiatorId = personId,
                    TenantId = tenantId,
                    WorkflowKindId = kind.WorkflowKindId,
                    RetryCount = kind.MaxRetries,
                    WorkStatusType = WorkStatusType.Executing,
                    SeedEntity = seedEntity,
                    DateCreated = DateTime.UtcNow,
                    DateStartExecution = DateTime.UtcNow
                };
                context.WorkflowInstanceRepository().Insert(workflowInstance);
                context.Save();
                return workflowInstance;
            }
        }

        /// <summary>
        /// Update Status
        /// </summary>
        /// <param name="workFlowInstanceId">Id</param>
        /// <param name="status">Status</param>
        public void UpdateWorkflowStatus(int workFlowInstanceId, WorkStatusType status)
        {
            if (workFlowInstanceId == 0) throw new ArgumentNullException("workFlowInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.WorkflowInstanceRepository().GetById(workFlowInstanceId);
                instance.WorkStatusType = status;
                context.Save();
            }
        }

        /// <summary>
        /// Search workflow by ID
        /// </summary>
        /// <param name="workflowInstanceId">Id</param>
        /// <returns>WorkFlow</returns>
        public WorkflowInstance FindWorkflowInstance(int workflowInstanceId)
        {
            if (workflowInstanceId == 0) throw new ArgumentNullException("workflowInstanceId");

            using (var context = new WorkflowContext())
            {
                return context.WorkflowInstanceRepository().GetById(workflowInstanceId);
            }
        }

        /// <summary>
        /// Search by Status
        /// </summary>
        /// <param name="status">Status</param>
        /// <returns>All workflows</returns>
        public IList<WorkflowInstance> FindAllWorkflowInstanceByStatus(WorkStatusType status)
        {
            using (var context = new WorkflowContext())
            {
                return
                    context.WorkflowInstanceRepository()
                        .Get(workflowInstance => workflowInstance.WorkStatusId == (int)status)
                        .ToList();
            }
        }

        /// <summary>
        /// Update Execution start time (now)
        /// </summary>
        /// <param name="workflowInstanceId">Id</param>
        public void UpdateExecutionStartTime(int workflowInstanceId)
        {
            if (workflowInstanceId == 0) throw new ArgumentNullException("workflowInstanceId");
            using (var context = new WorkflowContext())
            {
                var workflowInstance = context.WorkflowInstanceRepository().GetById(workflowInstanceId);
                workflowInstance.DateStartExecution = DateTime.UtcNow;
                context.Save();
            }
        }

        /// <summary>
        /// Update complete time (now)
        /// </summary>
        /// <param name="workflowInstanceId">ID</param>
        public void UpdateExecutionCompleteTime(int workflowInstanceId)
        {
            if (workflowInstanceId == 0) throw new ArgumentNullException("workflowInstanceId");
            using (var context = new WorkflowContext())
            {
                var workflowInstance = context.WorkflowInstanceRepository().GetById(workflowInstanceId);
                workflowInstance.DateCompleteExecution = DateTime.UtcNow;

                if (workflowInstance.WorkflowScheduleId != null)
                {
                    // This is a scheduled workflow.   We need to queue the next operation
                    var scheduledWorkflow =
                        context.WorkflowScheduleRepository().GetById(workflowInstance.WorkflowScheduleId);

                    if (scheduledWorkflow != null && scheduledWorkflow.NextRunTime.HasValue)
                    {
                        var nextScheduledTime = GetNextScheduledStartTime(scheduledWorkflow);

                        InternalCreateAndQueueFirstUnitOfWork(scheduledWorkflow.InitiatorId, scheduledWorkflow.TenantId,
                            scheduledWorkflow.WorkflowKindId, scheduledWorkflow.SeedEntity,
                            scheduledWorkflow.AggregateEntity, scheduledWorkflow.WorkflowScheduleId, nextScheduledTime);
                        scheduledWorkflow.NextRunTime = nextScheduledTime;
                    }
                }
                context.Save();
            }
        }

        /// <summary>
        /// Lazy load the WorkflowKinds and cache the result
        /// </summary>
        private IDictionary<int, WorkflowKind> WorkflowKinds
        {
            get
            {
                if (_workflowKindsCache == null || _workflowKindsCache.Any() == false)
                {
                    InitializeWorkflowKindsCache();
                }
                return _workflowKindsCache;
            }
        }

        /// <summary>
        /// For a running scheduled workflow compute the next scheduled start time.
        /// </summary>
        /// <param name="scheduledWorkflow"></param>
        /// <returns></returns>
        private DateTime GetNextScheduledStartTime(WorkflowSchedule scheduledWorkflow)
        {
            Debug.Assert(scheduledWorkflow.NextRunTime.HasValue, "Next Run Time should be set, this method computes the next run time from it");
            if (scheduledWorkflow.NextRunTime.HasValue == false)
                throw new InvalidOperationException();

            var now = DateTime.UtcNow;
            var nextScheduledTime = scheduledWorkflow.NextRunTime.Value.AddTicks(scheduledWorkflow.Interval);

            while (nextScheduledTime < now)
            {
                nextScheduledTime = nextScheduledTime.AddTicks(scheduledWorkflow.Interval);
            }

            return nextScheduledTime;
        }

        /// <summary>
        /// Given the start time on the schedule this method computes the next start time based on today's date.
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        private DateTime GetScheduledWorkflowStartTime(WorkflowSchedule schedule)
        {
            var now = DateTime.UtcNow;
            var initialStartTime = schedule.StartTime;

            var newStartTime = new DateTime(now.Year, now.Month, now.Day, initialStartTime.Hour, initialStartTime.Minute, initialStartTime.Second);

            //consider if this should be working with the run interval not days.
            // If we're in the past, start it tomorrow.
            if (newStartTime < now)
                newStartTime = newStartTime.AddDays(1);

            return newStartTime;
        }

        /// <summary>
        /// read and execute all schedule
        /// </summary>
        public void ExecuteScheduledWorkflows()
        {
            try
            {
                using (var context = new WorkflowDbContext())
                {
                    // Grab all non-running scheduled workflows.   Workflows may already be running on a re-deploy.
                    var scheduledWorkflows = context.WorkflowSchedules.Where(schedule => schedule.IsRunning == false);

                    foreach (var scheduledWorkflow in scheduledWorkflows)
                    {
                        try
                        {
                            var startTime = GetScheduledWorkflowStartTime(scheduledWorkflow);

                            InternalCreateAndQueueFirstUnitOfWork(scheduledWorkflow.InitiatorId,
                                scheduledWorkflow.TenantId, scheduledWorkflow.WorkflowKindId,
                                scheduledWorkflow.SeedEntity, scheduledWorkflow.AggregateEntity,
                                scheduledWorkflow.WorkflowScheduleId, startTime);

                            scheduledWorkflow.NextRunTime = startTime;
                            scheduledWorkflow.IsRunning = true;
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(
                                string.Format("Failed to schedule workflow: {0}", scheduledWorkflow.WorkflowScheduleId),
                                LoggingConstants.ModuleWorkerRole, null, ex);
                        }

                    }
                    context.SaveChanges();
                }
            }
            catch (Exception err)
            {
                Logger.Error("An error occurred starting the scheduled workflows", LoggingConstants.ModuleWorkerRole, null, err);
            }
        }

        /// <summary>
        /// Initialize the static cache of workflow kinds to avoid reloading all the time
        /// </summary>
        private void InitializeWorkflowKindsCache()
        {
            // Extra lock and null check to avoid 2 threads writing to the same variable during initialization
            lock (WorkflowKindsCacheLock)
            {
                if (_workflowKindsCache == null || _workflowKindsCache.Any() == false)
                {
                    using (var context = new WorkflowContext())
                    {
                        _workflowKindsCache = context.WorkflowKindRepository().Get().ToDictionary(wfk => wfk.WorkflowKindId);
                    }
                }
            }
        }

        /// <summary>
        /// Unity container
        /// </summary>
        public IUnityContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Save Business entity errors in database, and set the workflow as complete
        /// </summary>
        /// <param name="workFlowInstanceId"></param>
        /// <param name="error"></param>
        public void UpdateWorkflowError(int workFlowInstanceId, string error)
        {
            if (workFlowInstanceId == 0) throw new ArgumentNullException("workFlowInstanceId");
            using (var context = new WorkflowContext())
            {
                var instance = context.WorkflowInstanceRepository().GetById(workFlowInstanceId);
                instance.Error = error;
                instance.WorkStatusType = WorkStatusType.Completed;
                context.Save();
                //TODO: update all Unit Of work status also, as complete
            }
        }
    }
}
