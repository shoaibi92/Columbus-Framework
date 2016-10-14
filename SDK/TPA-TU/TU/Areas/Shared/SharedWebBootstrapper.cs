/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers;
using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web
{
    /// <summary>
    /// Administrative Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport(BootstrapModule.Framework, new[] { BootstrapAppliesTo.Web }, 20)]
    public class SharedWebBootstrapper : IBootstrapperTask
    {
        /// <summary>
        /// Bootstrap activity execution
        /// </summary>
        /// <param name="container">The Unity container</param>
        public void Execute(IUnityContainer container)
        {
            RegisterController(container);
        }

        private void RegisterController(IUnityContainer container)
        {
            #region Shared

            UnityUtil.RegisterType<IController, ReportController<GenericReport>>(container, "SharedReport");

            #endregion
        }

    }
}
