/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Collections;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Web;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models
{
    /// <summary>
    /// Revaluation History screen viewmodel
    /// </summary>
    /// <typeparam name="T">RevaluationHistory</typeparam>
    public class RevaluationHistoryViewModel<T> : ViewModelBase<T> where T : RevaluationHistory, new()
    {

        /// <summary>
        /// RateOperator list
        /// </summary>
        public IEnumerable RateOperators
        {
            get { return EnumUtility.GetItems<RateOperator>(); }
        }

        /// <summary>
        /// RateOverridden list
        /// </summary>
        public IEnumerable RateOverriddens
        {
            get { return EnumUtility.GetItems<RateOverridden>(); }
        }

        /// <summary>
        /// RevaluationMethod list
        /// </summary>
        public IEnumerable RevaluationMethods
        {
            get { return EnumUtility.GetItems<RevaluationMethod>(); }
        }

        /// <summary>
        /// Currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Currency code description
        /// </summary>
        public string CurrencyCodeDescription { get; set; }

    }
}