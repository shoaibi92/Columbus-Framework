/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
using Sage.CA.SBS.ERP.Sage300.Core.Web.Controllers;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Login;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Web.Models;

namespace Sage.CA.SBS.ERP.Sage300.Core.Web
{
    /// <summary>
    /// Administrative Bootstrapper Class
    /// </summary>
    [Export(typeof(IBootstrapperTask))]
    [BootstrapMetadataExport(BootstrapModule.Framework, new[] { BootstrapAppliesTo.Web }, 20)]
    public class CoreWebBootstrapper : IBootstrapperTask
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
            #region Core

            //UnityUtil.RegisterType<IController, HomeController>(container, "Home");
            UnityUtil.RegisterType<IController, CommonController>(container, "CoreCommon");
            UnityUtil.RegisterType<IController, FindController>(container, "CoreFind");
            UnityUtil.RegisterType<IController, ExportImportController>(container, "CoreExportImport");
            UnityUtil.RegisterType<IController, TenantController>(container, "CoreTenant");
            UnityUtil.RegisterType<IController, SessionController>(container, "CoreSession");
            UnityUtil.RegisterType<IController, AuthenticationController>(container, "Authentication");

            // Determine Authentication based upon OnPremise vs. Cloud deployment
            if (ConfigurationHelper.IsOnPremise)
            {
                // Performs OnPremise Login
                UnityUtil.RegisterType<IAuthenticationManager, AuthenticationManagerOnPremise>(container, "AuthenticationManager");
            }
            else
            {
                // Performs Sage ID Login
                UnityUtil.RegisterType<IAuthenticationManager, AuthenticationManager>(container, "AuthenticationManager");
            }
            
            UnityUtil.RegisterType<IController, NewTenantController>(container, "CoreNewTenant");

            // UnityUtil.RegisterType<ILogin, LoginViewModel>(container, "LoginModel");

            #endregion
        }

    }
}
