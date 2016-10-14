/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Globalization;
using System.Threading;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
namespace Sage.CA.SBS.ERP.Sage300.Workflow
{
    /// <summary>
    /// BaseUnitOfWork
    /// </summary>
    public abstract class BaseUnitOfWork
    {
        /// <summary>
        /// The _keep alive
        /// </summary>
        private readonly Action _keepAlive;

        /// <summary>
        /// The container
        /// </summary>
        protected readonly IUnityContainer Container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="workflowInstance">The workflow instance.</param>
        /// <param name="unitOfWorkInstance">The unit of work instance.</param>
        /// <param name="queue">The queue.</param>
        /// <param name="keepAlive">The keep alive.</param>
        /// <param name="container">The container.</param>
        /// <remarks>Derived classes that are longer running should make sure to add a keepAlive to their constructor so the
        /// keep alive call back can be passed in and prevent message hidden lease from expiring. See JobListResponseUOW
        /// as an example</remarks>
        protected BaseUnitOfWork(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
        {
            WorkflowInstance = workflowInstance;
            UnitOfWorkInstance = unitOfWorkInstance;
            Queue = queue;
            _keepAlive = keepAlive;

            if (Container == null)
                Container = container;
        }

        /// <summary>
        /// OnExecute
        /// </summary>
        protected abstract void OnExecute();

        /// <summary>
        /// OnExecute
        /// </summary>
        /// <returns>ProgressMeter.</returns>
        protected abstract ProgressMeter GetProgressStatus();

        /// <summary>
        /// OnExecute
        /// </summary>
        protected abstract void CancelProcess();

        /// <summary>
        /// KeepAlive
        /// </summary>
        /// <value>The keep alive.</value>
        protected Action KeepAlive
        {
            get
            {
                Action keepAlive = () => { if (_keepAlive != null) _keepAlive(); };
                return keepAlive;
            }
        }

        /// <summary>
        /// Queue
        /// </summary>
        /// <value>The queue.</value>
        protected IQueue Queue { get; private set; }

        /// <summary>
        /// WorkflowInstance
        /// </summary>
        /// <value>The workflow instance.</value>
        protected WorkflowInstance WorkflowInstance { get; private set; }

        /// <summary>
        /// UnitOfWorkInstance
        /// </summary>
        /// <value>The unit of work instance.</value>
        protected UnitOfWorkInstance UnitOfWorkInstance { get; private set; }

        /// <summary>
        /// Execute
        /// </summary>
        public void Execute()
        {
            OnExecute();
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <returns>ProgressMeter.</returns>
        public ProgressMeter GetExecutionStatus()
        {
            return GetProgressStatus();
        }

        /// <summary>
        /// Execute
        /// </summary>
        public void Cancel()
        {
            CancelProcess();
        }

        /// <summary>
        /// Resolve T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <returns>T.</returns>
        protected T Resolve<T>(Context context)
        {
            return Container.Resolve<T>(UnityInjectionType.Default, new ParameterOverride("context", context));
        }

        /// <summary>
        /// Resolve T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Named Mapping</param>
        /// <param name="context">The context.</param>
        /// <returns>T.</returns>
        protected T Resolve<T>(string name, Context context)
        {
            return Container.Resolve<T>(name.ToLowerInvariant(), new ParameterOverride("context", context));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seedEntityId"></param>
        /// <returns></returns>
        protected Seed<T> GetSeedEntity<T>(string seedEntityId) where T : ModelBase
        {
            var seedEntity = SerializationUtil.StringToType<Seed<T>>(seedEntityId);
            CommonUtil.SetCulture(seedEntity.Context.Language);

            seedEntity.Context.ContextToken = CommonUtil.StringToGuid(WorkflowInstance.WorkflowInstanceId.ToString(CultureInfo.InvariantCulture));

            return seedEntity;
        }
    }
}