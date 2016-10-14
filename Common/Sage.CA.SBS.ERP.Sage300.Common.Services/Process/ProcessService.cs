/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Process
{
    /// <summary>
    /// Process Service - common for all the processing screens
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <typeparam name="TEntity">Repository Interface</typeparam>
    public abstract class ProcessService<T, TEntity> : BaseService, IProcessService<T>
        where T : ModelBase, new()
        where TEntity : IProcessingRepository<T>, ISecurity
    {
        private readonly int _workFlowKind;
        private const string WorkerServiceUrl = "net.tcp://{0}:{1}/WorkerService";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="workFlowKind">WorkflowKind Enumeration</param>
        /// <remarks>To be deprecated at some point</remarks>
        protected ProcessService(Context context, WorkFlowKind workFlowKind)
            : base(context)
        {
            _workFlowKind = (int)workFlowKind;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="workFlowKind">WorkflowKind Integer Value</param>
        /// <remarks>New constructor to replace enumeration at some point</remarks>
        protected ProcessService(Context context, int workFlowKind)
            : base(context)
        {
            _workFlowKind = workFlowKind;
        }

        /// <summary>
        /// Get the model
        /// </summary>
        /// <returns>Model</returns>
        public virtual T Get()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.Get();
            }
        }

        /// <summary>
        /// Queue the Process and return
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>Newly created workflowinstance id</returns>
        public virtual int Process(T model)
        {
            var queue = QueueFactory.Create();
            var workflowManager = WorkflowManagerFactory.Create(queue, Context.Container);
            //Serialize the payload
            string seed = GetSeed(model);
            //Create the provisioning workflow
            var instance = workflowManager.CreateAndQueueFirstUnitOfWork(Context.ProductUserId, Context.TenantId, _workFlowKind, seed, null);
            return instance.WorkflowInstanceId;
        }

        /// <summary>
        /// Call the Worker service (WCF) to get the process meter
        /// </summary>
        /// <param name="workFlowInstanceId">WorkFlow Instance Id</param>
        /// <returns>Progressmeter</returns>
        public async virtual Task<ProcessResult> GetProgressAsync(int workFlowInstanceId)
        {
            if (workFlowInstanceId == 0)
            {
                throw new ArgumentNullException("workFlowInstanceId");
            }

            var workflowInstance = GetWorkflowInstance(workFlowInstanceId);

            if (workflowInstance == null)
            {
                throw new ArgumentException();
            }

            //Security Check
            if (workflowInstance.TenantId != Context.TenantId
                && workflowInstance.InitiatorId != Context.ProductUserId)
            {
                throw new ArgumentException();
            }

            //If workflow is completed return the result from last unit of work
            if (workflowInstance.WorkStatusType == WorkStatusType.Completed)
            {
                return GetResultFromLastUnitOfWork(workFlowInstanceId);
            }

            //check unit of work which is executing and get the result
            var uowInstance = GetExecutingUnitOfWork(workFlowInstanceId);

            if (uowInstance == null)
            {
                return GetResultFromLastUnitOfWork(workFlowInstanceId);
            }

            ProcessResult result;
            if (string.IsNullOrEmpty(uowInstance.WorkerRoleAddress) || string.IsNullOrEmpty(uowInstance.WorkerRolePort))
            {
                result = new ProcessResult
                {
                    ProcessStatus = ProcessStatus.NotStarted,
                    ProgressMeter = new ProgressMeter { Label = CommonResx.Processing }
                };
                return result;
            }
            var serviceClient = GetWorkerServiceClient(uowInstance);
            try
            {
                result = new ProcessResult
                {
                    ProcessStatus = ProcessStatus.Executing,
                    ProgressMeter = await serviceClient.GetStatusAsync(uowInstance.UnitOfWorkInstanceId)
                };
                serviceClient.Close();
            }
            catch (FaultException<WorkerFault> exception)
            {
                serviceClient.Abort();
                return GetErrorResult(exception.Detail != null ? exception.Detail.Message : exception.Message);
            }
            catch (Exception exception)
            {
                serviceClient.Abort();
                Logger.Error(LoggingConstants.ApplicationError, LoggingConstants.ModuleWcfException, Context, exception);
                return GetErrorResult(CommonResx.UnhandledExceptionMessage);
            }
            return result;
        }

        /// <summary>
        /// Call the Worker service (WCF) to cancel the ongoing process
        /// </summary>
        /// <param name="workFlowInstanceId">WorkFlow Instance Id</param>
        public async virtual Task<ProcessResult> CancelProcessAsync(int workFlowInstanceId)
        {
            if (workFlowInstanceId == 0)
            {
                throw new ArgumentNullException("workFlowInstanceId");
            }

            var uowInstance = GetExecutingUnitOfWork(workFlowInstanceId, "WorkflowInstance");

            if (uowInstance != null) //If this is null means that the work is already completed, may need to throw an error here
            {
                //Security Check
                if (uowInstance.TenantId != Context.TenantId
                    && uowInstance.WorkflowInstance.InitiatorId != Context.ProductUserId)
                {
                    throw new ArgumentException();
                }

                if (!string.IsNullOrEmpty(uowInstance.WorkerRoleAddress) &&
                    !string.IsNullOrEmpty(uowInstance.WorkerRolePort))
                {
                    var serviceClient = GetWorkerServiceClient(uowInstance);
                    try
                    {
                        await serviceClient.CancelWorkAsync(uowInstance.UnitOfWorkInstanceId);
                        serviceClient.Close();
                    }
                    catch (FaultException<WorkerFault> exception)
                    {
                        serviceClient.Abort();
                        return GetErrorResult(exception.Detail != null ? exception.Detail.Message : exception.Message);
                    }
                    catch (Exception exception)
                    {
                        serviceClient.Abort();
                        Logger.Error(LoggingConstants.ApplicationError, LoggingConstants.ModuleWcfException, Context, exception);
                        return GetErrorResult(CommonResx.UnhandledExceptionMessage);
                    }
                }
            }
            var result = new ProcessResult { ProcessStatus = ProcessStatus.Completed };
            return result;
        }


        /// <summary>
        /// Get WCF service
        /// TODO- Bindings can be configurable
        /// TODO- Service client needs to be cached for performance
        /// </summary>
        /// <param name="unitOfWorkInstance"></param>
        /// <returns></returns>
        private WorkerServiceClient GetWorkerServiceClient(UnitOfWorkInstance unitOfWorkInstance)
        {
            var binding = new NetTcpBinding(SecurityMode.None);
            var address =
                new EndpointAddress(
                    new Uri(string.Format(WorkerServiceUrl, unitOfWorkInstance.WorkerRoleAddress,
                        unitOfWorkInstance.WorkerRolePort)));
            return new WorkerServiceClient(binding, address);
        }

        /// <summary>
        /// get the status of the workflow
        /// </summary>
        /// <param name="workFlowInstanceId">WorkFlow Instance id</param>
        /// <returns>status as true/false</returns>
        private WorkflowInstance GetWorkflowInstance(int workFlowInstanceId)
        {
            using (var context = new WorkflowContext())
            {
                return context.WorkflowInstanceRepository().GetById(workFlowInstanceId);
            }
        }

        /// <summary>
        /// Get the result of all the work item
        /// This get the result of the last unit of work
        /// </summary>
        /// <param name="workFlowInstanceId">work flow instance id</param>
        /// <returns>Result</returns>
        private ProcessResult GetResultFromLastUnitOfWork(int workFlowInstanceId)
        {
            using (var context = new WorkflowContext())
            {
                var uowInstance =
                    context.UnitOfWorkInstanceRepository()
                        .Get(unitOfWorkInstance => unitOfWorkInstance.WorkflowInstanceId == workFlowInstanceId)
                        .OrderByDescending(uow => uow.UnitOfWorkKindId)
                        .Single();

                if (uowInstance.WorkStatusType == WorkStatusType.Error)
                {
                    return GetErrorResult(CommonResx.UnhandledExceptionMessage);
                }
                return SerializationUtil.StringToType<ProcessResult>(uowInstance.ResultEntity);
            }
        }

        /// <summary>
        /// Get the next executing unit of work in the workflow series
        /// </summary>
        /// <param name="workFlowInstanceId">unit of work instance</param>
        /// <param name="includeProperties">include properties</param>
        /// <returns>Unit of work instance</returns>
        private UnitOfWorkInstance GetExecutingUnitOfWork(int workFlowInstanceId, string includeProperties = "")
        {
            using (var context = new WorkflowContext())
            {
                var uowInstance =
                    context.UnitOfWorkInstanceRepository()
                        .Get(
                            unitOfWorkInstance =>
                                unitOfWorkInstance.WorkflowInstanceId == workFlowInstanceId &&
                                unitOfWorkInstance.WorkStatusId == (int)WorkStatusType.Executing,
                                null,
                                includeProperties)
                        .FirstOrDefault();
                return uowInstance;
            }
        }

        /// <summary>
        /// Get Access Rights
        /// </summary>
        /// <returns>UserAccess</returns>
        public UserAccess GetAccessRights()
        {
            using (var repository = Resolve<TEntity>())
            {
                return repository.GetAccessRights();
            }
        }
    }
}