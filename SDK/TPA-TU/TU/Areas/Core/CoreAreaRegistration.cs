/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Web.Mvc;
using System.Web.Optimization;

namespace Sage.CA.SBS.ERP.Sage300.Core.Web
{
    /// <summary>
    /// Class for Core Area registration
    /// </summary>
    public class CoreAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets Area Name
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Core";
            }
        }

        /// <summary>
        /// Registers Area 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            RegisterRoutes(context);
            RegisterBundles();
        }

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="context"></param>
        private void RegisterRoutes(AreaRegistrationContext context)
        {
            //Maps Login action
            context.MapRoute("Core_AuthenticationLogin", "Core/Authentication/Login",
                new { area = "Core", controller = "Authentication", action = "Login" });

            // Maps LoginResult action
            context.MapRoute("Core_AuthenticationLoginResult", "Core/Authentication/LoginResult/{id}",
                new { area = "Core", controller = "Authentication", action = "LoginResult", id = UrlParameter.Optional });

            // Maps OnPremise Authentication LoginResult Action
            context.MapRoute("Core_AuthenticationLoginResultOnPremise", "Core/Authentication/LoginResultOnPremise",
                new { area = "Core", controller = "Authentication", action = "LoginResultOnPremise" });

            // Maps OnPremise Authentication ChangePassword Action
            context.MapRoute("Core_AuthenticationChangePassword", "Core/Authentication/ChangePassword",
                new { area = "Core", controller = "Authentication", action = "ChangePassword" });

            // Maps Logout action called when signout
            context.MapRoute("Core_AuthenticationLogout", "Core/Authentication/Logout/{id}",
                new { area = "Core", controller = "Authentication", action = "Logout", id = UrlParameter.Optional });

            // Maps Clear action 
            context.MapRoute("Core_AuthenticationClear", "Core/Authentication/Clear/{id}",
                new { area = "Core", controller = "Authentication", action = "Clear", id = UrlParameter.Optional });

            // Maps Error view
            context.MapRoute("Core_Error", "Core/Error/{action}",
                new { area = "Core", controller = "Error", action = "Index", id = UrlParameter.Optional });

            // Maps Tenant selection view
            context.MapRoute("Core_TenantView", "Core/Tenant/{action}",
                new { area = "Core", controller = "Tenant", action = "", id = UrlParameter.Optional });

            // Maps all Core area actions for a specified tenant & company
            context.MapRoute("Core_Tenant", "{tenantAlias}/Core/{controller}/{action}/{id}",
                new { area = "Core", action = "Index", id = UrlParameter.Optional });
        }

        /// <summary>
        /// Register bundles
        /// </summary>
        private void RegisterBundles()
        {
            BundleRegistration.RegisterBundles(BundleTable.Bundles);
        }
    }
}
