// Copyright (c) 2015 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Interface for the UserTenant Resolver of the current session
    /// </summary>
    public interface IUserTenantResolver
    {
        /// <summary>
        /// Finds the corresponding UserTenantInfo for the current session, creating it if necessary
        /// </summary>
        /// <param name="container">The Unity container</param>
        /// <param name="context">The current context</param>
        /// <param name="company">The Org ID of the company (optional)</param>
        /// <param name="userId">The 300 User ID signing in (optional)</param>
        /// <param name="password">The unencrypted password for the user</param>
        /// <returns>The corresponding UserTenantInfo for the current session </returns>
        Common.Models.Authentication.UserTenantInfo ResolveUserTenant(Microsoft.Practices.Unity.IUnityContainer container, Common.Models.Context context, string company, string userId, string password);
    }
}
    