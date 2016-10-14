/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Web.Mvc;
using System.Web.Optimization;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web
{
    /// <summary>
    /// Class for register Area
    /// </summary>
    public class SharedAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Gets Area name
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Shared";
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
            context.MapRoute("Shared_Tenant", "{tenantAlias}/Shared/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
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
