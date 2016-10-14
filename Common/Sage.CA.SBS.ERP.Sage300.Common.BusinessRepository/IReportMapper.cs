/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// Mapper for Report
    /// </summary>
    /// <typeparam name="T">Type of ReportBase</typeparam>
    public interface IReportMapper<T> where T : ReportBase
    {
        /// <summary>
        /// Return report
        /// </summary>
        /// <param name="model">Model to be converted to Report</param>
        /// <returns>Report</returns>
        Report Map(T model);
    }
}