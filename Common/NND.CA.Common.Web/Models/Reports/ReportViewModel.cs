using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Reports
{
    /// <summary>
    /// Reports View Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReportViewModel<T> : ViewModelBase<T> where T : ReportBase, new()
    {
        /// <summary>
        /// Report Token
        /// </summary>
        /// <value>The report token.</value>
        public Guid ReportToken { get; set; }

        /// <summary>
        /// Report Token List
        /// </summary>
        /// <value>The report token.</value>
        public List<Guid> ReportTokenList { get; set; }

    }
}
