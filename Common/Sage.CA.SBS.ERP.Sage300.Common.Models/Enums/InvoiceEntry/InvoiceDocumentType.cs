/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for InvoiceDocumentType 
    /// </summary>
    public enum InvoiceDocumentType
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

    }
}
