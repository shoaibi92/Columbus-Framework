// Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. 

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for TransactionType 
    /// </summary>
    public enum ARTransactionType
    {
        /// <summary>
        /// Gets or sets InvoiceSummaryEntered 
        /// </summary>	
        [EnumValue("InvoiceItemIssued", typeof(InvoiceResx), 1)]
        InvoiceItemIssued = 11,

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
        /// Gets or sets InvoiceSummaryIssued 
        /// </summary>	
        [EnumValue("InvoiceSummaryIssued", typeof(InvoiceResx), 1)]
        InvoiceSummaryIssued = 14,

        /// <summary>
        /// Gets or sets InvoiceItemEntered 
        /// </summary>	
        [EnumValue("InvoiceItemEntered", typeof(InvoiceResx), 1)]
        InvoiceItemEntered = 15,

        /// <summary>
        /// Gets or sets DebitNoteItemIssued 
        /// </summary>	
        [EnumValue("DebitNoteItemIssued", typeof(InvoiceResx), 1)]
        DebitNoteItemIssued = 21,

        /// <summary>
        /// Gets or sets DebitNoteSummaryEntered 
        /// </summary>
        [EnumValue("DebitNoteSummaryEntered", typeof(InvoiceResx), 1)]
        DebitNoteSummaryEntered = 22,

        /// <summary>
        /// Gets or sets DebitNoteSummaryIssued 
        /// </summary>
        [EnumValue("DebitNoteSummaryIssued", typeof(InvoiceResx), 1)]
        DebitNoteSummaryIssued = 24,

        /// <summary>
        /// Gets or sets DebitNoteItemEntered 
        /// </summary>
        [EnumValue("DebitNoteItemEntered", typeof(InvoiceResx), 1)]
        DebitNoteItemEntered = 25,

        /// <summary>
        /// Gets or sets CreditNoteItemIssued 
        /// </summary>
        [EnumValue("CreditNoteItemIssued", typeof(InvoiceResx), 1)]
        CreditNoteItemIssued = 31,

        /// <summary>
        /// Gets or sets CreditNoteSummaryEntered 
        /// </summary>	
        [EnumValue("CreditNoteSummaryEntered", typeof(InvoiceResx), 1)]
        CreditNoteSummaryEntered = 32,

        /// <summary>
        /// Gets or sets CreditNoteSummaryIssued 
        /// </summary>	
        [EnumValue("CreditNoteSummaryIssued", typeof(InvoiceResx), 1)]
        CreditNoteSummaryIssued = 34,

        /// <summary>
        /// Gets or sets CreditNoteItemEntered 
        /// </summary>	
        [EnumValue("CreditNoteItemEntered", typeof(InvoiceResx), 1)]
        CreditNoteItemEntered = 35,

        /// <summary>
        /// Gets or sets InterestCharge 
        /// </summary>	
        [EnumValue("InterestCharge", typeof(EnumerationsResx), 1)]
        InterestCharge = 40
    }
}
