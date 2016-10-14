/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for DocumentType 
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Gets or sets Invoice 
        /// </summary>	
        [EnumValue("DocumentType_Invoice", typeof(InvoiceResx), 1)]
        Invoice = 1,

        /// <summary>
        /// Gets or sets DebitNote 
        /// </summary>	
        [EnumValue("DocumentType_DebitNote", typeof(InvoiceResx), 2)]
        DebitNote = 2,

        /// <summary>
        /// Gets or sets CreditNote 
        /// </summary>	
        [EnumValue("DocumentType_CreditNote", typeof(InvoiceResx), 3)]
        CreditNote = 3,

        /// <summary>
        /// Gets or sets Interest 
        /// </summary>	
        [EnumValue("DocumentType_Interest", typeof(InvoiceResx), 4)]
        Interest = 4,

        /// <summary>
        /// Retainage Invoice
        /// </summary>
        [EnumValue("DocumentType_RetainageInvoice", typeof(InvoiceResx), 5)]
        RetainageInvoice = 5,

        /// <summary>
        /// Retainage Debit Note
        /// </summary>
        [EnumValue("DocumentType_RetainageDebitNote", typeof(InvoiceResx), 6)]
        RetainageDebitNote = 6,

        /// <summary>
        /// Retainage Credit Note
        /// </summary>
        [EnumValue("DocumentType_RetainageCreditNote", typeof(InvoiceResx), 7)]
        RetainageCreditNote = 7,

        /// <summary>
        /// Gets or sets Prepayment 
        /// </summary>	
        [EnumValue("DocumentType_Prepayment", typeof(InvoiceResx), 10)]
        Prepayment = 10,

        /// <summary>
        /// Gets or sets Payment 
        /// </summary>	
        [EnumValue("DocumentType_Payment", typeof(InvoiceResx), 11)]
        Payment = 11
    }
}
