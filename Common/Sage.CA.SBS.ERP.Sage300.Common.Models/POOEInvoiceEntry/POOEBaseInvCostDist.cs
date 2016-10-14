/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvCostDist
    /// </summary>
    public partial class POOEBaseInvCostDist : ModelBase
    {
        /// <summary>
        /// Gets or sets InvoiceSequenceKey
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal InvoiceSequenceKey { get; set; }

        /// <summary>
        /// Gets or sets LineNumber
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal LineNumber { get; set; }

        /// <summary>
        /// Gets or sets LineSequence
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal LineSequence { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets BillingRate
        /// </summary>
        public decimal BillingRate { get; set; }

        /// <summary>
        /// Gets or sets StoredInDatabaseTable
        /// </summary>
        public AllowedType StoredInDatabaseTable { get; set; }

        /// <summary>
        /// Gets or sets FromPredecessor
        /// </summary>
        public AutoTaxCalculationOnSave FromPredecessor { get; set; }

        /// <summary>
        /// Gets or sets ManualCostDistribution
        /// </summary>
        public long ManualCostDistribution { get; set; }

        /// <summary>
        /// Gets or sets ExtraneousCostDistribution
        /// </summary>
        public long ExtraneousCostDistribution { get; set; }

        /// <summary>
        /// Gets or sets CostDistribution
        /// </summary>
        public long CostDistribution { get; set; }
    }
}
