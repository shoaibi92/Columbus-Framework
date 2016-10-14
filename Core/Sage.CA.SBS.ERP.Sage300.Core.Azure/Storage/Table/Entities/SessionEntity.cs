// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Microsoft.WindowsAzure.Storage.Table;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities
{
    /// <summary>
    /// Session Monitoring Entity
    /// </summary>
    public class SessionEntity : TableEntity, ISession
    {
        /// <summary>
        /// Name of the Role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public Guid TenantId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public string SessionId { get; set; }

        /// <summary>
        /// Accpac Session Id
        /// </summary>
        public string AccpacSessionId { get; set; }

        /// <summary>
        /// Whether Session is In Use Or Not
        /// </summary>
        public bool IsInUse { get; set; }

        /// <summary>
        /// View Count
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Set Row Key
        /// </summary>
        internal void SetKeys()
        {
            PartitionKey = GetPartitionKey();
            Role = ConfigurationHelper.RoleName;
            RowKey = string.Format("{0}_{1}_{2}_{3}", TenantId, UserId, Company, AccpacSessionId);
        }

        /// <summary>
        /// Get Partition key
        /// </summary>
        /// <returns></returns>
        public static string GetPartitionKey()
        {
            return string.Format("{0}_{1}_{2}", ConfigurationHelper.DeploymentId, ConfigurationHelper.RoleInstanceId, ConfigurationHelper.ApplicationIdentifier);
        }
    }
}