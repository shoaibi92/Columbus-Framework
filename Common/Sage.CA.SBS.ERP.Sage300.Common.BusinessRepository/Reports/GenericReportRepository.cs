/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Base;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Reports
{
    /// <summary>
    /// Generic repository to process all reports defined in xml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericReportRepository<T> : BaseReportRepository<T>, IGenericReportRepository<T>
        where T : GenericReport, new()
    {
        private static Models.Reports.Reports _reports;
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        public GenericReportRepository(Context context) : base(context, new ReportMapper<T>(context), string.Empty)
        {
            LoadReports();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="session">Session</param>
        public GenericReportRepository(Context context, IBusinessEntitySession session)
            : base(context, new ReportMapper<T>(context), session)
        {
            LoadReports();
        }

        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="id">Report Id</param>
        /// <returns>Report</returns>
        public virtual T Get(Guid id)
        {
            return GetInternal(id);
        }

        /// <summary>
        /// Save Report - Save the report parameters in the cache
        /// </summary>
        /// <param name="model">Report</param>
        /// <returns>Report</returns>
        public override Guid Execute(T model)
        {
            //Get the original model
            var originalReport = GetInternal(model.Id);

            //populate values in the original report from the model
            foreach (var parameter in originalReport.Parameters)
            {
                if (parameter.Hide)
                {
                    parameter.Value = GetParameterValue(parameter.Id);
                }
                else
                {
                    parameter.Value =
                        model.Parameters.Where(pmt => pmt.Id == parameter.Id).Select(pmt => pmt.Value).FirstOrDefault();
                }
            }
            return base.Execute(originalReport);
        }

        /// <summary>
        /// Get Report from xml configuration
        /// </summary>
        /// <param name="id">Id of the report</param>
        /// <returns>Report</returns>
        private T GetInternal(Guid id)
        {
            var model = _reports.ReportList.Find(rpt => rpt.Id == id);
            if (model == null)
            {
                return null;
            }
            var report = new T();
            report.Id = model.Id;
            report.ProgramId = model.ProgramId;
            report.MenuId = model.MenuId;
            report.Name = model.Name;
            report.Label = model.Label.Clone();
            report.Parameters = new List<Parameter>();
            foreach (var parameter in model.Parameters)
            {
                var newParameter = parameter.Clone();
                if (parameter.Control != null)
                {
                    newParameter.Control = parameter.Control.Clone();
                }
                if (parameter.Label != null)
                {
                    newParameter.Label = parameter.Label.Clone();
                }
                report.Parameters.Add(newParameter);
            }
            return report;
        }

        /// <summary>
        /// Get paramter values for hidden ones
        /// </summary>
        /// <param name="parameterId">Id of the parameter</param>
        /// <returns>value</returns>
        private string GetParameterValue(string parameterId)
        {
            switch (parameterId)
            {
                case "MULTCURN?":
                case "MULTCURN":
                    return Convert.ToString(Session.IsMultiCurrency, CultureInfo.InvariantCulture);
                case "FUNCCURN":
                    return Session.HomeCurrency;
                case "CMPNAME":
                    return Session.CompanyName;
                case "GS": //Does the user have a license to use G/L Security?
                    return
                        Convert.ToString(Convert.ToInt16(Session.IsLicenseOk("GS", string.Empty),
                            CultureInfo.InvariantCulture));
            }
            return string.Empty;
        }

        /// <summary>
        /// Read the reports xml file and populate Reports
        /// </summary>
        /// <returns>Reports</returns>
        private static Models.Reports.Reports ReadXml()
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var filePath = folderPath + @"\Reports\Report.xml";
            return CommonUtil.DeSerialize<Models.Reports.Reports>(new Uri(filePath).LocalPath);
        }

        /// <summary>
        /// Load Reports
        /// Remove Static constructor to solve unity issue
        /// </summary>
        private static void LoadReports()
        {
            if (_reports != null) return;

            lock (SyncRoot)
            {
                if (_reports == null)
                {
                    _reports = ReadXml();
                }
            }
        }

        /// <summary>
        /// Creates business entites
        /// </summary>
        /// <returns></returns>
        protected override IBusinessEntity CreateBusinessEntities()
        {
            throw new NotImplementedException();
        }
    }
}