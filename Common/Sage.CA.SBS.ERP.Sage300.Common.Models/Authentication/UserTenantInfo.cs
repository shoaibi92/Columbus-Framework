/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication
{
    /// <summary>
    /// User Tenant Information used to setup the CE logged in information.
    /// </summary>
    public class UserTenantInfo
    {
        /// <summary>
        /// Error if any
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Is User Valid
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Is User Authoritative
        /// </summary>
        public bool IsAuthoritative { get; set; }

        /// <summary>
        /// CE product user id
        /// </summary>
        public Guid ProductUserId { get; set; }

        /// <summary>
        /// The signed on CE user's person information (associated with Sage ID).
        /// </summary>
        public UserInfo LoggedInUser { get; set; }

        /// <summary>
        /// The signed on CE user's currently selected tenant's information.
        /// </summary>
        public TenantInfo SelectedTenant { get; set; }

        /// <summary>
        /// An enumerable list of the all tenants that the signed on CE user is associated
        /// with.  The user is associated with at least one tenant.
        /// </summary>
        public IEnumerable<TenantInfo> Tenants { get; set; }

        /// <summary>
        /// Error if any
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// The URL of the user management admin portal
        /// </summary>
        public string UserManagementAdminApplicationUrl { get; set; }
    }
}