using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Queue;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.Workflow;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.UnitOfWork
{
    /// <summary>
    /// Deletes blob which are older.
    /// </summary>
    public class DeleteBlobUow : BaseUnitOfWork
    {
        /// <summary>
        /// Constructor to initialize base class BaseUnitOfWork
        /// </summary>
        /// <param name="workflowInstance">WorkFlowInstance</param>
        /// <param name="unitOfWorkInstance">UnitOfWorkInstance</param>
        /// <param name="queue">Azure Queue</param>
        /// <param name="keepAlive">KeepAlive</param>
        /// <param name="container">Unity Container</param>
        public DeleteBlobUow(WorkflowInstance workflowInstance, UnitOfWorkInstance unitOfWorkInstance, IQueue queue,
            Action keepAlive, IUnityContainer container)
            : base(workflowInstance, unitOfWorkInstance, queue, keepAlive, container)
        {
        }

        /// <summary>
        /// Deleting all blobs
        /// </summary>
        protected override void OnExecute()
        {
            var repository = Container.Resolve<ILandlordService>();

            foreach (var tenant in repository.GetTenants())
            {
                var containerFactory = Container.Resolve<IBlobContainerFactory>();
                var container = containerFactory.GetBlobContainer(tenant.TenantId.ToString().ToLowerInvariant());
                container.DeleteBlobs(TimeSpan.FromMinutes(ConfigurationHelper.BlobTimeOut));
                Logger.Info(string.Format("Blobs deleted for Tenant :{0}", tenant.InternalName), LoggingConstants.ModuleWorkerRole);
            }
        }

        /// <summary>
        /// This method is not implemented
        /// </summary>
        /// <returns></returns>
        protected override ProgressMeter GetProgressStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented
        /// </summary>
        protected override void CancelProcess()
        {
            throw new NotImplementedException();
        }
    }
}
