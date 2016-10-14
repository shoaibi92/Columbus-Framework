// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for TransactionType 
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Gets or sets none value
        /// </summary>
        [EnumValue("None", typeof(CommonResx), 1)]
        None = 0,

        /// <summary>
        /// Gets or sets InvoiceSummaryEntered 
        /// </summary>	
        [EnumValue("InvoiceSummaryEntered", typeof(EnumerationsResx), 1)]
        InvoiceSummaryEntered = 12,

        /// <summary>
        /// Gets or sets InvoiceRecurringCharge 
        /// </summary>	
        [EnumValue("InvoiceRecurringCharge", typeof(EnumerationsResx), 1)]
        InvoiceRecurringCharge = 13,

        /// <summary>
        /// Gets or sets DebitNoteSummaryEntered 
        /// </summary>
        [EnumValue("DebitNoteSummaryEntered", typeof(EnumerationsResx), 1)]
        DebitNoteSummaryEntered = 22,

        /// <summary>
        /// Gets or sets DebitNoteAdvanceCreditClaim 
        /// </summary>
        [EnumValue("DebitNoteAdvanceCreditClaim", typeof(EnumerationsResx), 1)]
        DebitNoteAdvanceCreditClaim = 26,

        /// <summary>
        /// Gets or sets CreditNoteSummaryEntered 
        /// </summary>	
        [EnumValue("CreditNoteSummaryEntered", typeof(EnumerationsResx), 1)]
        CreditNoteSummaryEntered = 32,

        /// <summary>
        /// Gets or sets InterestCharge 
        /// </summary>	
        [EnumValue("InterestCharge", typeof(EnumerationsResx), 1)]
        InterestCharge = 40,

        /// <summary>
        /// Gets or sets PaymentPosted 
        /// </summary>
        [EnumValue("PaymentPosted", typeof(EnumerationsResx), 1)]
        PaymentPosted = 51,

        /// <summary>
        /// Gets or sets PrepaymentPosted 
        /// </summary>	
        [EnumValue("PrepaymentPosted", typeof(EnumerationsResx), 1)]
        PrepaymentPosted = 57,

        /// <summary>
        /// Gets or sets AdjustmentPosted 
        /// </summary>	
        [EnumValue("AdjustmentPosted", typeof(EnumerationsResx), 1)]
        AdjustmentPosted = 81,
    }
}
