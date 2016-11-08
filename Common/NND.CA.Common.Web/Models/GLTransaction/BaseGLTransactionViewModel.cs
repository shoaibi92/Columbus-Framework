/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLTransaction;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLTransaction
{
    /// <summary>
    /// View Model Class for Base G/L Integration
    /// </summary>
    /// <typeparam name="T">Base GL Reference Integration</typeparam>
    public class BaseGLTransactionViewModel<T> : ReportViewModel<T> where T : BaseGLTransaction, new()
    {
        /// <summary>
        /// Get Defer G/L Transactions
        /// </summary>
        public IEnumerable<CustomSelectList> SortedByLists
        {
            get { return EnumUtility.GetItemsList<Common.Models.Enums.GLTransaction.SortBy>(); }
        }

        
        /// <summary>
        /// Get the List of Separator Options
        /// </summary>
        public IEnumerable ReportFormatListEnumerable
        {
            get { return EnumUtility.GetItems<Separator>(); }
        }

        
    }


}
