/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespace

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.POOEInvoiceEntry
{
    /// <summary>
    /// Model class for POOEBaseInvPstCostDistribs
    /// </summary>
    public partial class POOEBaseInvPstCostDistribs : ModelBase
    {
        /// <summary>
        /// Gets or sets INVISEQ
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal InvIseq { get; set; }

        /// <summary>
        /// Gets or sets INVHSEQ
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal InvHseq { get; set; }

        /// <summary>
        /// Gets or sets InvoiceCostSequence
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal InvoiceCostSequence { get; set; }

        /// <summary>
        /// Gets or sets LineSequence
        /// </summary>
        [Key]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public decimal LineSequence { get; set; }

        /// <summary>
        /// Gets or sets OperationToPost
        /// </summary>
        public int OperationToPost { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets BillingRate
        /// </summary>
        public decimal BillingRate { get; set; }
    }
}
