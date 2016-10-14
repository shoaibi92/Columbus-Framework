// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Table;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities
{
    /// <summary>
    /// Azure database auditing entity (will be written to WAD table)
    /// </summary>
    public class AzureDatabaseAuditEntity : TableEntity, IDatabaseAudit
    {
        /// <summary> Name of the Role </summary>
        /// <remarks> Azure specific property </remarks>
        public string Role { get; set; }

        /// <summary> Event date </summary>
        /// <remarks> DateUtil.GetUtcNowDate() </remarks>
        public DateTime EventDate { get; set; }

        /// <summary> Event type </summary>
        /// <remarks> Set by logger of event </remarks>
        public string EventType { get; set; }

        /// <summary> Tenant id </summary>
        /// <remarks> Get from Context.TenantId </remarks>
        public Guid TenantId { get; set; }

        /// <summary> Product user id </summary>
        /// <remarks> Get from Context.ProductUserId </remarks>
        public Guid ProductUserId { get; set; }

        /// <summary> User id </summary>
        /// <remarks> Get from Context.ApplicationUserId </remarks>
        public string UserId { get; set; }

        /// <summary> True if user is an administrator otherwise false </summary>
        /// <remarks> Get from BusinessEntitySession.IsAdmin </remarks>
        public bool IsAdmin { get; set; }

        /// <summary> Company </summary>
        /// <remarks> Get from Context.Company </remarks>
        public string Company { get; set; }

        /// <summary> Language (locale) </summary>
        /// <remarks> Get from Context.Language </remarks>
        public string Language { get; set; }

        /// <summary> Session date </summary>
        /// <remarks> Get from BusinessEntitySession.SessionDate </remarks>
        public DateTime SessionDate { get; set; }

        /// <summary> Session id </summary>
        /// <remarks> Get from Context.SessionId </remarks>
        public string SessionId { get; set; }

        /// <summary> Screen Name </summary>
        /// <remarks> Get from Context.ScreenContext.ScreenName </remarks>
        public string ScreenName { get; set; }

        /// <summary> Repository name </summary>
        /// <remarks> Get from BusinessEntity.CreatedRepositoryName </remarks>
        public string RepositoryName { get; set; }

        /// <summary> View name </summary>
        /// <remarks> Get from BusinessEntity.Name </remarks>
        public string ViewName { get; set; }

        /// <summary> Get Partition key </summary>
        /// <returns> Partition keys for Azure properties/columns</returns>
        /// <remarks> Changes every minute for better WAD load balancing and query performance</remarks>
        internal string GetPartitionKey()
        {
            var dateTime = EventDate.AddMinutes(-1);
            var partitionDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);

            return GetTicks(partitionDateTime);
        }

        /// <summary> Set Keys for Azure Table </summary>
        internal void SetKeys()
        {
            // PartitionKey changes every minute for better WAD load balancing and query performance
            PartitionKey = GetPartitionKey();
            // RowKey is unique after prefixing with tenant and product user (both guids)
            RowKey = string.Format("{0}_{1}_{2}_{3}", TenantId, ProductUserId, GetTicks(EventDate), Guid.NewGuid());

            // Additional property for Azure
            Role = ConfigurationHelper.RoleName;
        }

        /// <summary> Get Ticks </summary>
        /// <param name="dateTime">Date Time to be used to return ticks</param>
        /// <returns> String of ticks based upon entered date</returns>
        private static string GetTicks(DateTime dateTime)
        {
            return dateTime.ToUniversalTime().Ticks.ToString("d19", CultureInfo.InvariantCulture);
        }


    }
}