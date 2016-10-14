/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports
{
    /// <summary>
    /// GenericReportRepository interface
    /// </summary>
    /// <typeparam name="T">Report</typeparam>
    public interface IGenericReportRepository<T> : IReportRepository<T> where T : GenericReport, new()
    {
        /// <summary>
        /// Get Model for Report
        /// </summary>
        /// <param name="id">Report id</param>
        /// <returns>TModel</returns>
        T Get(Guid id);
    }
}