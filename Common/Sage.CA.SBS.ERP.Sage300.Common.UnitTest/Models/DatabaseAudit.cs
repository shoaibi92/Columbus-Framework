/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Models
{
    /// <summary>
    /// Database Audit
    /// </summary>
    public class DatabaseAudit: IDatabaseAudit
    {
        /// <summary> Name of the Role </summary>
        public string Role { get; set; }

        /// <summary> Event date </summary>
        public DateTime EventDate { get; set; }

        /// <summary> Event type </summary>
        /// <remarks> Set by logger of event </remarks>
        public string EventType { get; set; }

        /// <summary> Tenant id </summary>
        public Guid TenantId { get; set; }

        /// <summary> Product user id </summary>
        public Guid ProductUserId { get; set; }

        /// <summary> User id </summary>
        public string UserId { get; set; }

        /// <summary> True if user is an administrator otherwise false </summary>
        public bool IsAdmin { get; set; }

        /// <summary> Company </summary>
        public string Company { get; set; }

        /// <summary> Language (locale) </summary>
        public string Language { get; set; }

        /// <summary> Session date </summary>
        public DateTime SessionDate { get; set; }

        /// <summary> Session id </summary>
        public string SessionId { get; set; }

        /// <summary> Screen Name </summary>
        public string ScreenName { get; set; }

        /// <summary> Repository name </summary>
        public string RepositoryName { get; set; }

        /// <summary> View name </summary>
        public string ViewName { get; set; }

    }
}
