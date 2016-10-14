/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespaces

using System;
using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table
{
    /// <summary>
    /// Database auditing entity (non-cloud version in that data goes to debug window only)
    /// </summary>
    /// <typeparam name="T">IDatabaseAudit</typeparam>
    public class DatabaseAuditRepository<T> : IDatabaseAuditRepository<T> where T : IDatabaseAudit
    {
        /// <summary>
        /// Log the database audit information
        /// </summary>
        /// <param name="eventType">Type of event</param>
        /// <param name="businessEntity">BusinessEntity invoking event</param>
        public void Log(EventType eventType, IBusinessEntity businessEntity)
        {
            try
            {
                // Fire and forget async routine to log the database audit information in the local logger
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

            // Log message
            var message = @"Event Date: '{0}', Event Type: '{1}', Product User ID: '{2}', " +
                "IsAdmin: '{3}', Language: '{4}', Session Date: '{5}', Session ID: '{6}', " +
                "Screen Name: '{7}', Repository Name: '{8}', View Name: '{9}'";

            // Replace tokens and output to logger
            message = string.Format(message, DateTime.UtcNow.ToShortDateString(), eventType, context.ProductUserId,
                session.IsAdmin, context.Language, context.SessionDate.ToShortDateString(), context.SessionId,
                context.ScreenContext.ScreenName, businessEntity.CreatedRepositoryName, businessEntity.Name);
            Logger.Verbose(message, LoggingConstants.ModuleDatabaseAudit, context);
        }

    }
}
