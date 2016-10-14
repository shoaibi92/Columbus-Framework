/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvPaymentSchedule 
    ///  </summary>
    public partial class POOEBaseInvPaymentSchedule : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "InvoiceSequenceKey", ResourceType = typeof(InvoiceResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets PaymentNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PaymentNumber", ResourceType = typeof(InvoiceResx))]
        public decimal PaymentNumber { get; set; }

        /// <summary>
        /// Gets or sets StoredInDatabaseTable
        /// </summary>
        [IgnoreExportImport]
        public AllowedType StoredInDatabaseTable { get; set; }

        /// <summary>
        /// Gets or sets BaseForDiscount
        /// </summary>
        [Display(Name = "BaseForDiscount", ResourceType = typeof(InvoiceResx))]
        public decimal BaseForDiscount { get; set; }

        /// <summary>
        /// Gets or sets DiscountDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DiscountDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? DiscountDate { get; set; }

        /// <summary>
        /// Gets or sets DiscountPercentage
        /// </summary>
        [Display(Name = "DiscPercent", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets DiscountAmount
        /// </summary>
        [Display(Name = "DiscAmount", ResourceType = typeof(InvoiceResx))]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Gets or sets DueBase
        /// </summary>
        [Display(Name = "DueBase", ResourceType = typeof(InvoiceResx))]
        public decimal DueBase { get; set; }

        /// <summary>
        /// Gets or sets DueDate
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DueDate", ResourceType = typeof(InvoiceResx))]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets PercentageDue
        /// </summary>
        [Display(Name = "PercentageDue", ResourceType = typeof(InvoiceResx))]
        public decimal PercentageDue { get; set; }

        /// <summary>
        /// Gets or sets AmountDue
        /// </summary>
        [Display(Name = "AmountDue", ResourceType = typeof(InvoiceResx))]
        public decimal AmountDue { get; set; }

        /// <summary>
        /// Gets or sets Payment
        /// </summary>
        public long Payment { get; set; }
    }
}
