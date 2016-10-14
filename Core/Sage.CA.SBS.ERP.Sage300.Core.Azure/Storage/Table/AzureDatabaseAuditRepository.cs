// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table
{
    /// <summary>
    /// Database auditing entity (cloud version in that data goes to WAD table)
    /// </summary>
    /// <typeparam name="T">IDatabaseAudit</typeparam>
    public class AzureDatabaseAuditRepository<T> : AzureBaseRepository, IDatabaseAuditRepository<T> where T : IDatabaseAudit
    {
        #region Private variables
        /// <summary> Database audit table name for WAD </summary>
        private const string TableName = "DatabaseAuditTable";
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public AzureDatabaseAuditRepository()
            : base(TableName)
        {
        }

        /// <summary>
        /// Log the database audit information
        /// </summary>
        /// <param name="eventType">Type of event</param>
        /// <param name="businessEntity">BusinessEntity invoking event</param>
        public void Log(EventType eventType, IBusinessEntity businessEntity)
        {
            try
            {
                // Fire and forget async routine to log the database audit information in the WAD table
                Task.Run(() => FireAndForget(eventType, businessEntity));
            }
            catch
            {
                // Ignore any errors as audit is fire and forget   
            }
        }

        /// <summary>
        /// Fire and forget async routine to log the database audit information to the local logger
        /// </summary>
        /// <param name="eventType">Type of event</param>
        /// <param name="businessEntity">BusinessEntity invoking event</param>
        private void FireAndForget(EventType eventType, IBusinessEntity businessEntity)
        {
            // Locals
            var context = businessEntity.Context;
            var session = businessEntity.Session;

            // Create entity object for addition to WAD
            var logData = new AzureDatabaseAuditEntity()
            {
                EventDate = DateTime.UtcNow,
                EventType = eventType.ToString(),
                TenantId = context.TenantId,
                ProductUserId = context.ProductUserId,
                UserId = context.ApplicationUserId,
                IsAdmin = session.IsAdmin,
                Company = context.Company,
                Language = context.Language,
                SessionDate = context.SessionDate,
                SessionId = context.SessionId,
                ScreenName = context.ScreenContext.ScreenName.ToString(),
                RepositoryName = businessEntity.CreatedRepositoryName,
                ViewName = businessEntity.Name
            };

            // Sets the PartitionKey, RowKey and Role
            logData.SetKeys();

            // Azure table operation to do async insert
            CloudTable.ExecuteAsync(TableOperation.Insert(logData));
        }

    }
}