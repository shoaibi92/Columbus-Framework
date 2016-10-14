/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork
{
    /// <summary>
    /// Class EmailUow.
    /// </summary>
    /// <typeparam name="T">Where Type of T is EmailOption</typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class EmailUow<T, TEntity> : BaseUnitOfWork
        where T : EmailOption, new()
        where TEntity : IEmailRepository<T>
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
        public EmailUow(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
            : base(workflowInstance, unitOfWorkInstance, queue, keepAlive, container)
        {
        }

        /// <summary>
        /// Implementation of Execute method
        /// </summary>
        protected override void OnExecute()
        {
            EmailResponse result;
            try
            {
                var seedEntity = GetSeedEntity<T>(WorkflowInstance.SeedEntity); 
                using (var repository = Resolve<TEntity>(seedEntity.Context))
                {
                    seedEntity.Context.Container = Container;
                    var model = repository.SendEmail(seedEntity.Model);
                    result = new EmailResponse
                    {
                        Status = ProcessStatus.Completed,
                        Results = model.Results
                    };
                }
            }
            catch (BusinessException exception)
            {
                result = new EmailResponse { Status = ProcessStatus.Error, Results = exception.Errors };               
            }

            UpdateResult(result);
        }

        /// <summary>
        /// Update result/errors to database
        /// </summary>
        /// <param name="result">The result.</param>
        protected void UpdateResult(EmailResponse result)
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cancel the process
        /// </summary>
        protected override void CancelProcess()
        {
            throw new NotImplementedException();
        }
    }
}
