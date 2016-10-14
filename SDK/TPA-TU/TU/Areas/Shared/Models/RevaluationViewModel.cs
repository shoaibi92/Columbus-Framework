/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models.Revaluation;
using Sage.CA.SBS.ERP.Sage300.Common.Web;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Models
{
    /// <summary>
    /// Revaluation screen viewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RevaluationViewModel<T> : ViewModelBase<T>
        where T : RevaluationEntry, new() 
    {
        /// <summary>
        /// Gets or sets HomeCurrency
        /// </summary>
        public string HomeCurrency { get; set; }

        /// <summary>
        /// Gets or sets IsMultiCurrency
        /// </summary>
        public bool IsMultiCurrency { get; set; }

        /// <summary>
        /// Gets or sets IsOptionalFieldsLicenseAvailable
        /// </summary>
        public bool IsOptionalFieldsLicenseAvailable { get; set; }
    }
}