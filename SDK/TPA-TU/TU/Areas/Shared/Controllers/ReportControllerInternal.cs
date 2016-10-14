/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Models;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers
{
    /// <summary>
    /// ReportControllerInternal
    /// </summary>
    /// <typeparam name="T">Report type</typeparam>
    public class ReportControllerInternal<T> : InternalControllerBase<IGenericReportService<T>>
        where T : GenericReport, new()
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public ReportControllerInternal(Context context)
            : base(context)
        {
        }

        #endregion

        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="id">Id of the report</param>
        /// <returns>ReportViewModel</returns>
        internal ReportViewModel<T> Get(Guid id)
        {
            return new ReportViewModel<T>
            {
                Data = Service.Get(id),
            };
        }

        /// <summary>
        /// Save Report details
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>ReportViewModel</returns>
        internal ReportViewModel<T> Execute(T report)
        {
            return new ReportViewModel<T>
            {
                ReportToken = Service.Execute(report),
                UserMessage = new UserMessage {IsSuccess = true}
            };
        }
    }
}