/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Blob;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Storage.Blob;
using System.ComponentModel.Composition;
using System.Web.Hosting;

namespace Sage.CA.SBS.ERP.Sage300.Common.Services
{
    /// <summary>
    /// Administrative Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport(BootstrapModule.Framework, new[] { BootstrapAppliesTo.Web, BootstrapAppliesTo.Worker, BootstrapAppliesTo.WebApi }, 1)]
    public class CommonBootstrapper : IBootstrapperTask
    {
        /// <summary>
        /// Bootstrap activity execution
        /// </summary>
        /// <param name="container">The Unity container</param>
        public void Execute(IUnityContainer container)
        {
            RegisterCommonTypes(container);
            RegisterLandlordRepository(container);
            RegisterExportImportTypes(container);
            RegisterService(container);
            RegisterRepositories(container);

            if (HostingEnvironment.IsHosted)
            {
                RegisterMenu(container);
            }

            if (ConfigurationHelper.IsOnPremise)
            {
                RegisterOnPremiseTypes(container);
            }
            else
            {
                RegisterAzureTypes(container);
            }
        }

        /// <summary>
        /// Register Menu Types
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        private void RegisterMenu(IUnityContainer container)
        {
            UnityUtil.RegisterType<IMenuService, MenuService>(container);

            UnityUtil.RegisterType<IMenuRepository, MenuRepository>(container, UnityInjectionType.Default,
                new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<IMenuRepository, MenuRepository>(container, UnityInjectionType.Session,
                new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            container.RegisterInstance<IMenuModuleHelperManager>(new MenuModuleHelperManager());
        }

        /// <summary>
        /// Register Common Types
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterCommonTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(ISession), typeof(SessionEntity));
            UnityUtil.RegisterType(container, typeof(IBusinessEntity), typeof(BusinessEntity));
            UnityUtil.RegisterType(container, typeof(IDatabaseAudit), typeof(AzureDatabaseAuditEntity));
        }

        /// <summary>
        /// Registering Entity Framework services
        /// </summary>
        /// <param name="container">IUnity Container</param>
        private static void RegisterLandlordRepository(IUnityContainer container)
        {
            // Use Repository based upon OnPremise vs. Cloud deployment
            if (ConfigurationHelper.IsOnPremise)
            {
                UnityUtil.RegisterType<ILandlordRepository, LandlordRepositoryOnPremise>(container);
            }
            else
            {
                UnityUtil.RegisterType<ILandlordRepository, LandlordRepository>(container);
            }

            UnityUtil.RegisterType<ILandlordService, LandlordService>(container);
        }

        /// <summary>
        /// Register Azure types
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterExportImportTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IExportImport), typeof(Core.ExportImport.EpPlusExportImport));

        }

        /// <summary>
        /// Register Azure types - when executed oncloud.
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterAzureTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IBlobContainerFactory), typeof(AzureBlobContainerFactory));
            //UnityUtil.RegisterType(container, typeof(IQueueFactory), typeof(AzureQueueFactory));
            UnityUtil.RegisterType<ISessionRepository<ISession>, AzureSessionRepository<ISession>>(container);
            UnityUtil.RegisterType<IDatabaseAuditRepository<IDatabaseAudit>, AzureDatabaseAuditRepository<IDatabaseAudit>>(container);
        }

        /// <summary>
        ///  Register types - when executeed on-premise and not oncloud
        /// </summary>
        /// <param name="container"></param>
        private static void RegisterOnPremiseTypes(IUnityContainer container)
        {
            UnityUtil.RegisterType(container, typeof(IBlobContainerFactory), typeof(AzureBlobContainerFactory));
            //UnityUtil.RegisterType(container, typeof(IQueueFactory), typeof(AzureQueueFactory));
            UnityUtil.RegisterType<ISessionRepository<ISession>, SessionRepository<ISession>>(container);
            UnityUtil.RegisterType<IDatabaseAuditRepository<IDatabaseAudit>, DatabaseAuditRepository<IDatabaseAudit>>(container);

        }

        private void RegisterService(IUnityContainer container)
        {
            #region Core

            UnityUtil.RegisterType<ICommonService, CommonService>(container);

            #endregion

            #region Shared

            UnityUtil.RegisterType<IGenericReportService<GenericReport>, GenericReportService<GenericReport>>(container);

            #endregion
        }

        private void RegisterRepositories(IUnityContainer container)
        {
            #region Core

            UnityUtil.RegisterType<ICommonRepository, CommonRepository>(container, UnityInjectionType.Default,
                new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType<ICommonRepository, CommonRepository>(container, UnityInjectionType.Session,
                new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

            #endregion

            #region Shared

            UnityUtil.RegisterType(container, typeof(IGenericReportRepository<GenericReport>),
                typeof(GenericReportRepository<GenericReport>), UnityInjectionType.Default,
                new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(IGenericReportRepository<GenericReport>),
                typeof(GenericReportRepository<GenericReport>), UnityInjectionType.Session,
                new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));


            //Bill To Location
            UnityUtil.RegisterType(container, typeof(ICommonBillToLocationEntity<BillToLocation>), typeof(BillToLocationRepository<BillToLocation>), UnityInjectionType.Default, new InjectionConstructor(typeof(Context)));
            UnityUtil.RegisterType(container, typeof(ICommonBillToLocationEntity<BillToLocation>), typeof(BillToLocationRepository<BillToLocation>), UnityInjectionType.Session, new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));


            #endregion

        }
    }
}
