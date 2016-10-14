// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using TPA.TU.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace TPA.TU.Models.Enums
{
    /// <summary>
    /// Enum for DefaultTaxAmountControl 
    /// </summary>
    public enum DefaultTaxAmountControl
    {
        /// <summary>
        /// Gets or sets Enter 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Enter", typeof(EnumerationsResx), 0)]
        Enter = 0,

        /// <summary>
        /// Gets or sets Calculate 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Calculate", typeof(EnumerationsResx), 1)]
        Calculate = 1,

        /// <summary>
        /// Gets or sets Distribute 
        /// </summary>	
        [EnumValue("DefaultTaxAmountControl_Distribute", typeof(EnumerationsResx), 2)]
        Distribute = 2,
    }
}
