// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

#region

using System;
using System.ComponentModel.DataAnnotations;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.GLIntegration;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration
{
    /// <summary>
    /// Classs for Base Integration Options
    /// </summary>
    public class BaseGLIntegrationOptions : ModelBase
    {

        /// <summary>
        /// Gets or sets Options Record Key 
        /// </summary>
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [StringLength(6, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Key]
        public string IntegrationOptionsKey { get; set; }

        /// <summary>
        /// Gets or sets Date Last Maintained 
        /// </summary>
        [ValidateDateFormat(ErrorMessageResourceName = "DateFormat", ErrorMessageResourceType = typeof(AnnotationsResx))]
        public DateTime DateLastMaintained { get; set; }

        /// <summary>
        /// Gets or sets Defer G/L Transactions/Batches
        /// </summary>
        [Display(Name = "CreateGLTransactions", ResourceType = typeof(GLIntegrationResx))]
        public DeferGLTransactions DeferGLTransactions { get; set; }

        /// <summary>
        /// Gets or sets Create G/L Transactions By 
        /// </summary>
        [Display(Name = "CreateGLTransactionsBy", ResourceType = typeof(GLIntegrationResx))]
        public CreateGLTransactionsBy CreateGLTransactionsBy { get; set; }

        /// <summary>
        /// Gets or sets Consolidate G/L Transactions/Batches 
        /// </summary>
        [Display(Name = "ConsolidateGLBatches", ResourceType = typeof(GLIntegrationResx))]
        public ConsolidateGLTransactions ConsolidateGLTransactions { get; set; }

        /// <summary>
        /// Gets or sets Last Invoice Posting Sequence to G/L 
        /// </summary>
        [Display(Name = "InvoicePostingSequence", ResourceType = typeof(GLIntegrationResx))]
        public decimal LastInvoicePostingSeqToGL { get; set; }

        /// <summary>
        /// Gets or sets Last Revaluation Posting Sequence to G/L 
        /// </summary>
        [Display(Name = "RevaluationPostingSequence", ResourceType = typeof(GLIntegrationResx))]
        public decimal LastRevalPostingSeqToGL { get; set; }

        /// <summary>
        /// Gets or sets Last Adjustment Posting Sequence to G/L 
        /// </summary>
        [Display(Name = "AdjustmentPostingSequence", ResourceType = typeof(GLIntegrationResx))]
        public decimal LastAdjPostingSeqToGL { get; set; }

        /// <summary>
        /// Gets or sets G/L Source Code Invoice 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Invoice", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeInvoice { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Debit Note 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "DebitNote", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeDebitNote { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Credit Note 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "CreditNote", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeCreditNote { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Interest 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Interest", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeInterest { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Discount 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Discount", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeDiscount { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Revaluation 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Revaluation", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeRevaluation { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Adjustment 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Adjustment", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeAdjustment { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Consolidation 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Consolidation", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeConsolidation { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Prepayment 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Prepayment", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodePrepayment { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Rounding 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "Rounding", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodeRounding { get; set; }

        /// <summary>
        /// Gets or sets GL Source Code Payment Reversal 
        /// </summary>
        [StringLength(2, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(AnnotationsResx))]
        [Display(Name = "PaymentReversal", ResourceType = typeof(GLIntegrationResx))]
        public string GLSrcCodePaymentReversal { get; set; }
    }
}
