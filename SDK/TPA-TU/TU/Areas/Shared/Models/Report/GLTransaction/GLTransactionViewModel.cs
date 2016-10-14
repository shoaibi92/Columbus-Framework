// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved.

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using System.Collections;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models.Report.GLTransaction
{
    /// <summary>
    /// GLTransaction ViewModel
    /// </summary>
    /// <typeparam name="T">GLSubledgerTransactionReport</typeparam>
    public class GLTransactionViewModel<T> : Common.Web.Models.Reports.ReportViewModel<T> where T : GLSubledgerTransactionReport, new()
    {
        /// <summary>
        /// To get ReportFormat list from Enum
        /// </summary>
        public IEnumerable ReportFormatList
        {
            get
            {
                return EnumUtility.GetItems<ReportFormat>();
            }
        }

        /// <summary>
        /// To get SortBy list from Enum
        /// </summary>
        public IEnumerable SortByList
        {
            get
            {
                return EnumUtility.GetItems<SortByType>();
            }
        }

        /// <summary>
        /// To get CurrencyType list from Enum
        /// </summary>
        public IEnumerable CurrencyTypeList
        {
            get
            {
                return EnumUtility.GetItems<CurrencyType>();
            }
        }

        /// <summary>
        /// To get SortBy for French 
        /// </summary>
        public string SortByText
        {
            get
            {
                return EnumUtility.GetStringValue(SortByType.Account);
            }
        }
    }
}