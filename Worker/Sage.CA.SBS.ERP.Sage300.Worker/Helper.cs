/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Core.Exceptions.Storage;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Class Helper.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Host Worker WCF Services
        /// </summary>
        public static void HostWorkerService()
        {
            WcfService.Instance.HostWorkerService();
        }
        
        /// <summary>
        /// Create, Queue, Worker, dispatcher
        /// </summary>
        /// <returns>WorkerDispatcher.</returns>
        public static WorkerDispatcher GetWorkerDispatcherInstance()
        {
            //Initialize - Queue, Manager and execute the scheduled workflows (start and keep the first job item of each schedule in the queue)
            ConfigurationHelper.Initialize(BootstrapTaskManager.Container, string.Empty);

            var queue = QueueFactory.Create();
            var manager = WorkflowManagerFactory.Create(queue, BootstrapTaskManager.Container);

            if (IsSchedulingWorkflow())
            {
                manager.ExecuteScheduledWorkflows();
            }

            IQueueProcessor processor = new UnitOfWorkProcessor(queue, manager);
            IWorker worker = new UnitOfWorkWorker(processor, queue);
            return new WorkerDispatcher(worker);
        }

        /// <summary>
        /// This code uses a blob to manage concurrency between multiple worker processes.
        /// </summary>
        /// <returns></returns>
        public static bool IsSchedulingWorkflow()
        {
            if (!ConfigurationHelper.IsRoleAvailable())
            {
                return true;
            }

            Logger.Info("IsSchedulingWorkflow executed.", LoggingConstants.ModuleWorkerRole);

            const string containerName = "scheduler";
            var blobName = string.Format("{0}/{1}", containerName, ConfigurationHelper.DeploymentId);
            var containerFactory = ConfigurationHelper.Container.Resolve<IBlobContainerFactory>();
            IBlobContainer container = containerFactory.GetBlobContainer(containerName);
            try
            {
                var blob = container.GetBlobReference(blobName);
                blob.UploadByteArray(new byte[0], BlobAccessCondition.IfNoneMatchETag);
                var metadataList = new Dictionary<string, string>();
                metadataList["SchedulerInstance"] = ConfigurationHelper.RoleInstanceId;
                blob.SetMetadata(metadataList);
                return true;
            }
            catch (BlobStorageException ex)
            {
                // This worker will not handle the scheduling
                Logger.Info(string.Format("IsSchedulingWorkflow (Expected Error): {0}", ex),
                    LoggingConstants.ModuleWorkerRole);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error("Errors in scheduled workflows:", ex);
                return false;
            }
        }

    }
}