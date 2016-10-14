/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports
{
    /// <summary>
    /// Generic Repository Service
    /// </summary>
    /// <typeparam name="T">Report</typeparam>
    public interface IGenericReportService<T> : IReportService<T>, ISecurityService where T : GenericReport, new()
    {
        /// <summary>
        /// Get Model for Report
        /// </summary>
        /// <param name="id">Report id</param>
        /// <returns>TModel</returns>
        T Get(Guid id);
    }
}