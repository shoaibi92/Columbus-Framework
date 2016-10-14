/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.ServiceModel;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.DataAccess;
using Sage.CA.SBS.ERP.Sage300.Workflow.Interfaces;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;

namespace Sage.CA.SBS.ERP.Sage300.Worker
{
    /// <summary>
    /// Service Contract Implementation - IWorkerService
    /// </summary>
    public class WorkerService : IWorkerService
    {
        /// <summary>
        /// Operation Contract - Get Status
        /// </summary>
        /// <param name="unitOfWorkInstanceId">The workflow instance</param>
        /// <returns>Progress status</returns>
        public ProgressMeter GetStatus(int unitOfWorkInstanceId)
        {
            try
            {
                return GetProgressMeter(unitOfWorkInstanceId);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggingConstants.ApplicationError, LoggingConstants.ModuleWcfException, null, ex);

                throw new FaultException<WorkerFault>(
                    new WorkerFault(CommonResx.ProcessErrorMessage));
            }
        }

        /// <summary>
        /// Health Status Check
        /// </summary>
        /// <param name="command">command for status</param>
        /// <returns>string status</returns>
        public string GetHealthStatus(int command)
        {
            try
            {
                switch (command)
                {
                    default: return "I am healthy";
                }
            }
            catch (Exception ex)
            {
                Logger.Error(LoggingConstants.ApplicationError, LoggingConstants.ModuleWcfException, null, ex);

                throw new FaultException<WorkerFault>(
                    new WorkerFault(CommonResx.ProcessErrorMessage));
            }
        }

        /// <summary>
        /// Cancel work
        /// </summary>
        /// <param name="unitOfWorkInstanceId">workflow instance Id</param>
        public void CancelWork(int unitOfWorkInstanceId)
        {
            try
            {
                CancelWorkInternal(unitOfWorkInstanceId);
            }
            catch (Exception ex)
            {
                Logger.Error(LoggingConstants.ApplicationError, LoggingConstants.ModuleWcfException, null, ex);

                throw new FaultException<WorkerFault>(
                    new WorkerFault(CommonResx.ProcessCancelErrorMessage));
            }
        }

        /// <summary>
        /// Return progressmeter object
        /// </summary>
        /// <param name="unitOfWorkInstanceId">unit of work instance id</param>
        /// <returns>Progress Meter</returns>
        /// <exception cref="System.ArgumentNullException">unitOfWorkInstanceId</exception>
        private ProgressMeter GetProgressMeter(int unitOfWorkInstanceId)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");

            using (var context = new WorkflowContext())
            {
                var unitOfWorkObject = GetBaseUnitOfWork(context, unitOfWorkInstanceId);
                return unitOfWorkObject.GetExecutionStatus();
            }
        }

        /// <summary>
        /// Cance the work
        /// </summary>
        /// <param name="unitOfWorkInstanceId">unit of work instance id</param>
        /// <exception cref="System.ArgumentNullException">unitOfWorkInstanceId</exception>
        private void CancelWorkInternal(int unitOfWorkInstanceId)
        {
            if (unitOfWorkInstanceId == 0) throw new ArgumentNullException("unitOfWorkInstanceId");

            using (var context = new WorkflowContext())
            {
                var unitOfWorkObject = GetBaseUnitOfWork(context, unitOfWorkInstanceId);
                unitOfWorkObject.Cancel();
            }
        }

        /// <summary>
        /// Return the Base Unit of work
        /// </summary>
        /// <param name="context">workflow context</param>
        /// <param name="unitOfWorkInstanceId">unit of work instance id</param>
        /// <returns>BaseUnitOfWork.</returns>
        private BaseUnitOfWork GetBaseUnitOfWork(WorkflowContext context, int unitOfWorkInstanceId)
        {
            var unitOfWorkInstance = context.UnitOfWorkInstanceRepository().GetById(unitOfWorkInstanceId);
            var qualified = string.Format("{0}, {1}", unitOfWorkInstance.UnitOfWorkKind.TypeName,
                unitOfWorkInstance.UnitOfWorkKind.AssemblyName);
            var type = Type.GetType(qualified, true);

            return
                (BaseUnitOfWork)
                    Activator.CreateInstance(type,
                        new object[]
                        {
                            unitOfWorkInstance.WorkflowInstance, unitOfWorkInstance, null, null,
                            BootstrapTaskManager.Container
                        });
        }
    }
}