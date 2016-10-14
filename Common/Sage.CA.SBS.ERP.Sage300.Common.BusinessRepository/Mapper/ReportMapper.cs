/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper
{
    /// <summary>
    /// Report Mapper
    /// </summary>
    /// <typeparam name="T">Report</typeparam>
    internal class ReportMapper<T> : IReportMapper<T> where T : GenericReport
    {
        #region Private Properties

        private readonly Context _context;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public ReportMapper(Context context)
        {
            _context = context;
        }

        #endregion

        /// <summary>
        /// Maps the model to T
        /// </summary>
        /// <param name="model">Report model</param>
        /// <returns>Report model</returns>
        public Report Map(T model)
        {
            var report = new Report
            {
                ProgramId = model.ProgramId,
                MenuId = model.MenuId,
                Name = model.Name,
                Context = _context,
                Parameters = new List<Parameter>()
            };

            foreach (var parameter in model.Parameters)
            {
                var newParameter = parameter.Clone();
                newParameter.Value = parameter.Value;
                report.Parameters.Add(newParameter);
            }
            return report;
        }
    }
}