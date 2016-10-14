// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Proration model
    /// </summary>
    public class Proration : ModelBase
    {
        /// <summary>
        /// Gets or sets LineRevision
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal LineRevision { get; set; }

        /// <summary>
        /// Gets or sets Contract
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Contract { get; set; }

        /// <summary>
        /// Gets or sets Project
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string Project { get; set; }

        /// <summary>
        /// Gets or sets CostCategory
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string CostCategory { get; set; }

        /// <summary>
        /// Gets or sets CostClass
        /// </summary>
        public CostClass CostClass { get; set; }

        /// <summary>
        /// Gets or sets ItemNumber
        /// </summary>
        [StringLength(24, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        [StringLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ItemDescription { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets ManuallyProratedAmount
        /// </summary>
        public decimal ManuallyProratedAmount { get; set; }

        /// <summary>
        /// Gets or sets AmountRemaining
        /// </summary>
        public string AmountRemaining { get; set; }

        /// <summary>
        /// Gets or sets BillingType
        /// </summary>
        public BillingType BillingType { get; set; }

        /// <summary>
        /// Gets or sets BillingRate
        /// </summary>
        public decimal BillingRate { get; set; }

        /// <summary>
        /// Gets or sets BillingCurrency
        /// </summary>
        [StringLength(3, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Gets or sets ARItemNumber
        /// </summary>
        [StringLength(16, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ARItemNumber { get; set; }

        /// <summary>
        /// Gets or sets ARUnitOfMeasure
        /// </summary>
        [StringLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public string ARUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets ProjectType
        /// </summary>
        public ProjectType ProjectType { get; set; }

        /// <summary>
        /// Gets or sets AccountingMethod
        /// </summary>
        public AccountingMethod AccountingMethod { get; set; }

        /// <summary>
        /// Gets or sets IsAmountEditable
        /// </summary>
        public bool IsAmountEditable { get; set; }
    }
}
