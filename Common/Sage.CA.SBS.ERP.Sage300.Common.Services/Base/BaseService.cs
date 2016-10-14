/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Class BaseService.
    /// </summary>
    public abstract class BaseService
    {

        /// <summary>
        /// IsReadOnly property - opens business entity in readonly mode
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets Context
        /// </summary>
        /// <value>The context.</value>
        protected Context Context { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context.</param>
        protected BaseService(Context context)
        {
            Context = context;
        }

        /// <summary>
        /// Resolve T
        /// </summary>
        /// <returns>T</returns>
        protected T Resolve<T>() where T : IRepository
        {
            var businessRepository = Context.Container.Resolve<T>(UnityInjectionType.Default, new ParameterOverride("context", Context));
            businessRepository.IsReadOnly = IsReadOnly;
            return businessRepository;
        }

        /// <summary>
        /// Resolve Default T - no need to inject context
        /// </summary>
        /// <returns>T</returns>
        protected T ResolveDefault<T>()
        {
            return Context.Container.Resolve<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T Resolve<T>(string type) where T : IRepository
        {
            var businessRepository = Context.Container.Resolve<T>(type, new ParameterOverride("context", Context), new ParameterOverride("dbLinkType", DBLinkType.System));
            businessRepository.IsReadOnly = IsReadOnly;
            return businessRepository;
        }

        /// <summary>
        /// Resolve with Pooling. NOT to be generally used
        /// </summary>
        /// <param name="type"></param>
        /// <param name="objectPoolType"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T Resolve<T>(string type, ObjectPoolType objectPoolType) where T : IRepository
        {
            // return Context.Container.Resolve<T>(type, new ParameterOverride("context", Context), new ParameterOverride("objectPoolType", objectPoolType));
            var businessRepository = Context.Container.Resolve<T>(type, new ParameterOverride("context", Context), new ParameterOverride("objectPoolType", objectPoolType));
            businessRepository.IsReadOnly = IsReadOnly;
            return businessRepository;
        }

        /// <summary>
        /// Resolve Service T
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T.</returns>
        protected T ResolveService<T>()
        {
            return Context.Container.Resolve<T>(new ParameterOverride("context", Context));
        }

        /// <summary>
        /// Export - will add a request in queue
        /// </summary>
        /// <param name="request">Model</param>
        /// <returns>String</returns>
        public virtual ExportResponse Export(ExportRequest request)
        {
            //Stop processing in case there is no item selected for export
            var stopExport = true;
            //Remove all the gridfields which is not selected for printing/export
            foreach (var dataMigrationItem in request.DataMigrationList)
            {
                var itemsToExport = (from item in dataMigrationItem.Items where item.print select item).ToList();
                if (itemsToExport.Count > 0)
                {
                    stopExport = false;
                }
                dataMigrationItem.Items = itemsToExport.ToList();
            }

            if (stopExport)
            {
                var errorExportRequests = new List<EntityError>();
                errorExportRequests.Add(new EntityError { Message = CommonResx.ExportImportNoColumnSelected, Priority = Priority.Warning });

                var errorResponse = new ExportResponse { Results = errorExportRequests, Status = ProcessStatus.Error };
                return errorResponse;
            }

            var queue = CreateQueue();
            var workflowManager = WorkflowManagerFactory.Create(queue, Context.Container);

            //Serialize the payload
            var seed = GetSeed(request);

            //Create the provisioning workflow
            var instance = workflowManager.CreateAndQueueFirstUnitOfWork(Context.ProductUserId, Context.TenantId,
                (int)WorkFlowKind.ExportJournalEntry, seed, null);

            var response = new ExportResponse { ResponseId = instance.UnitOfWorkInstanceId };
            return response;
        }

        /// <summary>
        /// Import - will add a request in queue
        /// </summary>
        /// <param name="request">Model</param>
        /// <returns>String</returns>
        public virtual ImportResponse Import(ImportRequest request)
        {
            var queue = CreateQueue();
            var workflowManager = WorkflowManagerFactory.Create(queue, Context.Container);

            //Serialize the payload
            var seed = GetSeed(request);
            //Create the provisioning workflow
            var instance = workflowManager.CreateAndQueueFirstUnitOfWork(Context.ProductUserId, Context.TenantId,
                (int)WorkFlowKind.ImportJournalEntry, seed, null);

            var response = new ImportResponse { ResponseId = instance.UnitOfWorkInstanceId };
            return response;
        }

        /// <summary>
        /// Get Status
        /// TODO - Why we send ExportResponse as input. It can only be Unit of work instance Id
        /// </summary>
        /// <param name="request">Export response</param>
        /// <returns>Process Result</returns>
        public ExportResponse ExportStatus(ExportResponse request)
        {
            ExportResponse response;

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            //Check for tenant ID
            var uowInstance = GetUnitOfWork(request.ResponseId);

            if (uowInstance == null)
            {
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(uowInstance.WorkerRoleAddress) || string.IsNullOrEmpty(uowInstance.WorkerRolePort))
            {
                response = new ExportResponse { Status = ProcessStatus.NotStarted };
            }
            else
            {
                switch (uowInstance.WorkStatusType)
                {
                    case WorkStatusType.Completed:
                        response = SerializationUtil.StringToType<ExportResponse>(uowInstance.ResultEntity);
                        response.Status = ProcessStatus.Completed;
                        break;
                    case WorkStatusType.Error:
                        response = request;
                        var error = new EntityError { Priority = Priority.Error, Message = CommonResx.UnhandledExceptionMessage };
                        response.Results.Add(error);
                        response.Status = ProcessStatus.Error;
                        break;
                    default:
                        response = new ExportResponse { Status = ProcessStatus.Executing };
                        break;
                }
            }
            return response;
        }

        /// <summary>
        /// Get Status 
        /// TODO - Why we send ExportResponse as input. It can only be Unit of workinstance Id
        /// TODO - Lot of code is repeated from above Export method. Cabn be refactored.
        /// </summary>
        /// <param name="request">Export response</param>
        /// <returns>Process Result</returns>
        public ImportResponse ImportStatus(ImportResponse request)
        {
            ImportResponse response;

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var uowInstance = GetUnitOfWork(request.ResponseId);

            if (uowInstance == null)
            {
                throw new ArgumentException();
            }


            if (string.IsNullOrEmpty(uowInstance.WorkerRoleAddress) || string.IsNullOrEmpty(uowInstance.WorkerRolePort))
            {
                response = new ImportResponse { Status = ProcessStatus.NotStarted };
            }
            else
            {
                switch (uowInstance.WorkStatusType)
                {
                    case WorkStatusType.Completed:
                        response = SerializationUtil.StringToType<ImportResponse>(uowInstance.ResultEntity);
                        response.Status = ProcessStatus.Completed;
                        break;
                    case WorkStatusType.Error:
                        response = request;
                        var error = new EntityError { Priority = Priority.Error, Message = CommonResx.UnhandledExceptionMessage };
                        response.Results.Add(error);
                        response.Status = ProcessStatus.Error;
                        break;
                    default:
                        response = new ImportResponse { Status = ProcessStatus.Executing };
                        break;
                }
            }
            return response;
        }

        /// <summary>
        /// Get Seed Serialized Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected string GetSeed<T>(T request) where T : ModelBase
        {
            var seedEntity = new Seed<T> { Context = Context, Model = request };
            return SerializationUtil.TypeToString(seedEntity);
        }

        /// <summary>
        /// Get result when there is an exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <returns>ProcessResult</returns>
        protected ProcessResult GetErrorResult(string message)
        {
            var errorMessage = new EntityError { Priority = Priority.Error, Message = message };
            var result = new ProcessResult { ProcessStatus = ProcessStatus.Error };
            result.Results.Add(errorMessage);
            return result;
        }

        /// <summary>
        /// Get the next executing unit of work in the workflow series
        /// </summary>
        /// <param name="unitOfWorkInstanceId">unit of work instance</param>
        /// <returns>Unit of work instance</returns>
        protected UnitOfWorkInstance GetUnitOfWork(int unitOfWorkInstanceId)
        {
            using (var context = new WorkflowContext())
            {
                var uowInstance =
                    context.UnitOfWorkInstanceRepository()
                        .Get(
                            unitOfWorkInstance =>
                                unitOfWorkInstance.UnitOfWorkInstanceId == unitOfWorkInstanceId
                                && unitOfWorkInstance.WorkflowInstance.TenantId == Context.TenantId
                                && unitOfWorkInstance.WorkflowInstance.InitiatorId == Context.ProductUserId,
                                null,
                                "WorkflowInstance")
                        .FirstOrDefault();
                return uowInstance;
            }
        }

        /// <summary>
        /// Create queue
        /// </summary>
        /// <returns></returns>
        private IQueue CreateQueue()
        {
            return QueueFactory.Create();
        }
    }
}