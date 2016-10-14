// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for TaxAmountControl 
    /// </summary>
    public enum TaxAmountControl
    {
        /// <summary>
        /// Gets or sets Enter 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Enter", typeof(InvoiceResx), 0)]
        Enter = 0,

        /// <summary>
        /// Gets or sets Calculate 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Calculate", typeof(InvoiceResx), 1)]
        Calculate = 1,

        /// <summary>
        /// Gets or sets Distribute 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Distribute", typeof(InvoiceResx), 2)]
        Distribute = 2,
    }
}
