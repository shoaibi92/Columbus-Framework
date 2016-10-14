// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for RetainageExchangeRate 
    /// </summary>
    public enum RetainageExchangeRate
    {
        /// <summary>
        /// Gets or sets UseOriginalDocumentExchangeRate 
        /// </summary>	
        [EnumValue("RetainageExchangeRate_UseOriginalDocumentExchangeRate", typeof(InvoiceResx), 0)]
        UseOriginalDocumentExchangeRate = 0,

        /// <summary>
        /// Gets or sets UseCurrentExchangeRate 
        /// </summary>	
        [EnumValue("RetainageExchangeRate_UseCurrentExchangeRate", typeof(InvoiceResx), 1)]
        UseCurrentExchangeRate = 1,
    }
}
