/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Linq;

using Microsoft.Practices.Unity;

using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork
{
    /// <summary>
    /// Class ProcessUow.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class ProcessUow<T, TEntity> : BaseUnitOfWork where T : ModelBase, new()
        where TEntity : IProcessingRepository<T>
    {
        /// <summary>
        /// Constructor to initialize base class BaseUnitOfWork
        /// </summary>
        /// <param name="workflowInstance">WorkFlowInstance</param>
        /// <param name="unitOfWorkInstance">UnitOfWorkInstance</param>
        /// <param name="queue">Azure Queue</param>
        /// <param name="keepAlive">KeepAlive</param>
        /// <param name="container">Unity COntainer</param>
        /// <remarks>Derived classes that are longer running should make sure to add a keepAlive to their constructor so the
        /// keep alive call back can be passed in and prevent message hidden lease from expiring. See JobListResponseUOW
        /// as an example</remarks>
        public ProcessUow(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
            : base(workflowInstance, unitOfWorkInstance, queue, keepAlive, container)
        {
        }

        /// <summary>
        /// Implementation of Execute method
        /// </summary>
        protected override void OnExecute()
        {
            ProcessResult result;
            try
            {
                var seedEntity = GetSeedEntity<T>(WorkflowInstance.SeedEntity); 

                seedEntity.Context.Container = Container;

                using (var repository = Resolve<TEntity>(seedEntity.Context))
                {
                    var model = repository.Process(seedEntity.Model);
                    result = new ProcessResult
                    {
                        ProcessStatus = ProcessStatus.Completed,
                        Results = model.Warnings.ToList()
                    };
                }
            }
            catch (BusinessException exception)
            {
                result = new ProcessResult {ProcessStatus = ProcessStatus.Error, Results = exception.Errors};
            }
            UpdateResult(result);
        }

        /// <summary>
        /// Update result/errors to database
        /// </summary>
        /// <param name="result">The result.</param>
        protected void UpdateResult(ProcessResult result)
        {
            var processResultAsString = SerializationUtil.TypeToString(result);
            var unitOfWorkManager = UnitOfWorkManagerFactory.Create(WorkflowManagerFactory.Create(null, null));
            unitOfWorkManager.UpdateUnitOfWorkWithResult(UnitOfWorkInstance.UnitOfWorkInstanceId, processResultAsString);
        }

        /// <summary>
        /// Implementation for getting Status
        /// </summary>
        /// <returns>ProgressMeter.</returns>
        protected override ProgressMeter GetProgressStatus()
        {
            try
            {
                var seedEntity = GetSeedEntity<T>(WorkflowInstance.SeedEntity);
                seedEntity.Context.Container = Container;
                using (var repository = Resolve<TEntity>(seedEntity.Context))
                {
                    return repository.GetProgressMeter();
                }
            }
            catch (BusinessException businessException)
            {
                var result = new ProcessResult {ProcessStatus = ProcessStatus.Error, Results = businessException.Errors};
                UpdateResult(result);
                return null;
            }
        }

        /// <summary>
        /// Cancel the process
        /// </summary>
        protected override void CancelProcess()
        {
            try
            {
                var seedEntity = GetSeedEntity<T>(WorkflowInstance.SeedEntity);
                seedEntity.Context.Container = Container;
                using (var repository = Resolve<TEntity>(seedEntity.Context))
                {
                    repository.Cancel();
                }
            }
            catch (BusinessException businessException)
            {
                var result = new ProcessResult {ProcessStatus = ProcessStatus.Error, Results = businessException.Errors};
                UpdateResult(result);
            }
        }
    }
}