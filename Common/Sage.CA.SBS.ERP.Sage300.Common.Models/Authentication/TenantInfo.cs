// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication
{
    /// <summary>
    /// Tenant Information model
    /// </summary>
    public class TenantInfo 
    {
        /// <summary>
        /// Tenant Id
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// Application User Id
        /// </summary>
        public string ApplicationUserId { get; set; }

        /// <summary>
        /// Tenant Status - active or locked/suspended
        /// </summary>
        public TenantStatus Status { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Tenant Name
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// Tenant Alias name
        /// </summary>
        public string TenantAlias { get; set; }

        /// <summary>
        /// List of organizations for a Tenant
        /// </summary>
        public List<Organization> Organizations { get; set; }
    }
}