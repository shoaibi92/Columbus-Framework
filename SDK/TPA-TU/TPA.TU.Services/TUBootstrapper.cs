/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using System.ComponentModel.Composition;

namespace TPA.TU.Services
{
    /// <summary>
    /// Account Payable Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport("TU", new[] { BootstrapAppliesTo.Web, BootstrapAppliesTo.Worker, BootstrapAppliesTo.WebApi }, 10)]
    public class TUBootstrapper : IBootstrapperTask
    {
        /// <summary>
        /// Bootstrap activity execution
        /// </summary>
        /// <param name="container">The Unity container</param>
        public void Execute(IUnityContainer container)
        {
            RegisterService(container);
            RegisterRepositories(container);
        }

        private void RegisterService(IUnityContainer container)
        {
            UnityUtil.RegisterType<Interfaces.Services.IAccountGroupService<TU.Models.AccountGroup>, AccountGroupEntityService<TU.Models.AccountGroup>>(container);
        }

        private void RegisterRepositories(IUnityContainer container)
        {
            UnityUtil.RegisterType<IExportImportRepository, BusinessRepository.AccountGroupRepository<Models.AccountGroup>>(container, "tuaccountgroup", new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType(container,
                typeof(Interfaces.BusinessRepository.IAccountGroupEntity<Models.AccountGroup>),
                typeof(BusinessRepository.AccountGroupRepository<TU.Models.AccountGroup>), UnityInjectionType.Default,
                new InjectionConstructor(typeof(Context)));

            UnityUtil.RegisterType(container,
                typeof(Interfaces.BusinessRepository.IAccountGroupEntity<Models.AccountGroup>),
                typeof(BusinessRepository.AccountGroupRepository<Models.AccountGroup>), UnityInjectionType.Session,
                new InjectionConstructor(typeof(Context), typeof(IBusinessEntitySession)));

        }
    }
}
