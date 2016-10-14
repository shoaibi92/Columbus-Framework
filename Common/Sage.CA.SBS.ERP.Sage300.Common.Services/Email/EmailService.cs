/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Email;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Microsoft.Practices.Unity;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Email
{
    /// <summary>
    /// Class EmailService
    /// </summary>
    /// <typeparam name="T">Where type of T is Email</typeparam>
    /// <typeparam name="TEntity">Where type of TEntity is IEmailRepository</typeparam>
    public abstract class EmailService<T, TEntity> : BaseService, IEmailService<T>
        where T : EmailOption, new()
        where TEntity : IEmailRepository<T>, ISecurity
    {
        /// <summary>
        /// workFlowKind
        /// </summary>
        private readonly WorkFlowKind _workFlowKind;

        /// <summary>
        /// Constructor for Email Service 
        /// </summary>
        /// <param name="context">Current business entity context</param>
        /// <param name="workFlowKind">The work flow instance identifier.</param>
        protected EmailService(Context context, WorkFlowKind workFlowKind)
            : base(context)
        {
            _workFlowKind = workFlowKind;
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="model">Model base</param>
        /// <returns>The work flow instance identifier.</returns>
        public virtual int SendEmail(T model)
        {
            var queue = QueueFactory.Create();
            var workflowManager = WorkflowManagerFactory.Create(queue, Context.Container);
            //Serialize the payload
            string seed = GetSeed(model);
            //Create the provisioning workflow
            var instance = workflowManager.CreateAndQueueFirstUnitOfWork(Context.ProductUserId, Context.TenantId, (int)_workFlowKind, seed, null);
            return instance.WorkflowInstanceId;
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
