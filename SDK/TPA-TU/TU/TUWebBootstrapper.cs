/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Controller;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using TPA.TU.Models;
using TPA.Web.Areas.TU.Controllers;
using TPA.Web.Areas.TU.Controllers.Finder;
using Constants=TPA.Web.Areas.TU.Constants;

namespace TPA.Web
{
    /// <summary>
    /// Administrative Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport("TU", new[] { BootstrapAppliesTo.Web }, 20)]
    public class TUWebBootstrapper : IBootstrapperTask
    {
        /// <summary>
        /// Bootstrap activity execution
        /// </summary>
        /// <param name="container">The Unity container</param>
        public void Execute(IUnityContainer container)
        {
            RegisterController(container);
            RegisterFinder(container);
            RegisterExportImportController(container);
        }

        private void RegisterController(IUnityContainer container)
        {
            UnityUtil.RegisterType<IController, AccountGroupController<AccountGroup>>(container, "TUAccountGroup");
        }

        private void RegisterFinder(IUnityContainer container)
        {
            UnityUtil.RegisterType<IFinder, FindAccountGroupControllerInternal<AccountGroup>>(container, Constants.Constants.TUAccountGroup, new InjectionConstructor(typeof(Context)));
        }

        private void RegisterExportImportController(IUnityContainer container)
        {
            UnityUtil.RegisterType<IExportImportController, AccountGroupControllerInternal<AccountGroup>>(container, Constants.Constants.TUAccountGroupExportImport, new InjectionConstructor(typeof(Context)));
        }
    }
}
