// Copyright (c) 2015 Sage Software, Inc.  All rights reserved.

using System;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// UserTenant Resolver for cloud deployments
    /// </summary>
    public class UserTenantResolver : IUserTenantResolver
    {
        /// <summary>
        /// Finds the corresponding UserTenantInfo for the current session, creating it if necessary
        /// </summary>
        /// <param name="container">The Unity container</param>
        /// <param name="context">The current context</param>
        /// <param name="company">The Org ID of the company</param>
        /// <param name="userId">Currently unused</param>
        /// <param name="password">Currently unused</param>
        /// <returns>The corresponding UserTenantInfo for the current session </returns>
        public UserTenantInfo ResolveUserTenant(IUnityContainer container, Context context, string company, string userId, string password)
        {
            throw new NotImplementedException();
        }
    }
}