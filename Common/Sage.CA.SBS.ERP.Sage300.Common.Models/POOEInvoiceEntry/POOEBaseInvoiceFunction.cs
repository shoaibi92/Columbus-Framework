/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvoiceFunction
    /// </summary>
    public partial class POOEBaseInvoiceFunction : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets SequenceToRetrieve
        /// </summary>
        public decimal SequenceToRetrieve { get; set; }

        /// <summary>
        /// Gets or sets Vendor
        /// </summary>
        [StringLength(12, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets ReceiptNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ReceiptNumber { get; set; }

        /// <summary>
        /// Gets or sets ReturnNumber
        /// </summary>
        [StringLength(22, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ReturnNumber { get; set; }

        /// <summary>
        /// Gets or sets NewTermsCodeEntered
        /// </summary>
        public AutoTaxCalculationOnSave NewTermsCodeEntered { get; set; }

        /// <summary>
        /// Gets or sets ScheduleCalculationMethod
        /// </summary>
        public ScheduleCalculationMethod ScheduleCalculationMethod { get; set; }

        /// <summary>
        /// Gets or sets PredecessorTimestamp
        /// </summary>
        [StringLength(24, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string PredecessorTimestamp { get; set; }

        /// <summary>
        /// Gets or sets Function
        /// </summary>
        public int Function { get; set; }
    }
}
