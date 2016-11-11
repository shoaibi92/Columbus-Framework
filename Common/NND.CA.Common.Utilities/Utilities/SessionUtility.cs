/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Session Helper
    /// </summary>
    public static class SessionUtility
    {
        private static readonly ISessionCacheProvider Instance;

        static SessionUtility()
        {
            Instance = ConfigurationHelper.Container.Resolve<ISessionCacheProvider>();
        }

        /// <summary>
        /// Get the provider.
        /// </summary>
        public static ISessionCacheProvider Provider
        {
            get { return Instance; }
        }
    }
}
