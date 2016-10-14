// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using System.Globalization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Mapper.Reports
{
    /// <summary>
    /// GLTransaction Mapper
    /// </summary>
    /// <typeparam name="T">GLSubledgerTransactionReport</typeparam>
    public class GLTransactionMapper<T> : IReportMapper<T> where T : GLSubledgerTransactionReport, new()
    {
        #region Private Properties

        /// <summary>
        /// Context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Report Name
        /// </summary>
        private string _reportName;

        #region Constants

        /// <summary>
        /// Menu ID
        /// </summary>
        private const string MenuId = "<MENU ID>";

        /// <summary>
        /// Program ID
        /// </summary>
        private const string ProgramId = "GP1601";

        /// <summary>
        /// Report GP1610
        /// </summary>
        private const string ReportGp1610 = "GP1610";

        /// <summary>
        /// Report GP1650
        /// </summary>
        private const string ReportGp1650 = "GP1650";

        /// <summary>
        /// Report GP1611
        /// </summary>
        private const string ReportGp1611 = "GP1611";

        /// <summary>
        /// Report GP1651
        /// </summary>
        private const string ReportGp1651 = "GP1651";

        /// <summary>
        /// Report GP1620
        /// </summary>
        private const string ReportGp1620 = "GP1620";

        /// <summary>
        /// Report GP1660
        /// </summary>
        private const string ReportGp1660 = "GP1660";

        /// <summary>
        /// Constant for True 
        /// </summary>
        private const string StringTrue = "1";

        /// <summary>
        /// Constant for False
        /// </summary>
        private const string StringFalse = "0";

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// GLTransaction Mapper Constructor
        /// </summary>
        /// <param name="context">context</param>
        public GLTransactionMapper(Context context)
        {
            _context = context;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Returns report
        /// </summary>
        /// <param name="model">Model to be converted to Report</param>
        /// <returns>Report</returns>
        public virtual Report Map(T model)
        {
            SetReportName(model);
            var report = new Report { ProgramId = ProgramId, MenuId = MenuId, Name = _reportName, Context = _context };

            var funcCurrDecParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.FunctionalCurrencyDecimals, Value = model.FunctionalCurrencyDecimals.ToString(CultureInfo.InvariantCulture) };
            report.Parameters.Add(funcCurrDecParam);

            var toSeqParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.ThroughPostingSequence, Value = model.ThroughPostingSequence.ToString(CultureInfo.InvariantCulture) };
            report.Parameters.Add(toSeqParam);

            var applicationParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.SourceApplication, Value = model.SourceApplication };
            report.Parameters.Add(applicationParam);

            var prefixParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.ReportNamePrefix, Value = model.ReportNamePrefix };
            report.Parameters.Add(prefixParam);

            var multiCurrencyParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.MultiCurrency, Value = model.MultiCurrency ? StringTrue : StringFalse };
            report.Parameters.Add(multiCurrencyParam);

            var seqCaptionParam = new Parameter { Id = GLSubledgerTransactionReport.Fields.PostingSequenceCaption, Value = model.PostingSequenceCaption };
            report.Parameters.Add(seqCaptionParam);

            var seqTitle1Param = new Parameter { Id = GLSubledgerTransactionReport.Fields.PostingSequenceTitle1, Value = model.PostingSequenceTitle1 };
            report.Parameters.Add(seqTitle1Param);

            var seqTitle2Param = new Parameter { Id = GLSubledgerTransactionReport.Fields.PostingSequenceTitle2, Value = model.PostingSequenceTitle2 };
            report.Parameters.Add(seqTitle2Param);

            return report;
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Sets the Report Name
        /// </summary>
        /// <param name="model">GLSubledgerTransactionReport</param>
        private void SetReportName(T model)
        {
            switch (model.ReportFormat)
            {
                case ReportFormat.Detail:
                    switch (model.SortBy)
                    {
                        case SortByType.Account:
                            _reportName = ReportGp1650;
                            if (model.ReportCurrency == CurrencyType.Functional)
                            {
                                _reportName = ReportGp1610;
                            }
                            break;
                        case SortByType.YearAndPeriod:
                            _reportName = ReportGp1660;
                            if (model.ReportCurrency == CurrencyType.Functional)
                            {
                                _reportName = ReportGp1620;
                            }
                            break;
                    }
                    break;
                case ReportFormat.Summary:
                    switch (model.SortBy)
                    {
                        case SortByType.Account:
                            _reportName = ReportGp1651;
                            if (model.ReportCurrency == CurrencyType.Functional)
                            {
                                _reportName = ReportGp1611;
                            }
                            break;
                        case SortByType.YearAndPeriod:
                            _reportName = ReportGp1620;
                            break;
                    }
                    break;
            }
        }

        #endregion
    }
}
