/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespaces
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Audit;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit
{
    /// <summary>
    /// Interface for database auditing repository
    /// </summary>
    /// <typeparam name="T">IDatabaseAudit</typeparam>
    public interface IDatabaseAuditRepository<T> where T : IDatabaseAudit
    {
        /// <summary>
        /// Log the database audit information
        /// </summary>
        /// <param name="eventType">Type of event</param>
        /// <param name="businessEntity">BusinessEntity invoking event</param>
        void Log (EventType eventType, IBusinessEntity businessEntity);
    }
}