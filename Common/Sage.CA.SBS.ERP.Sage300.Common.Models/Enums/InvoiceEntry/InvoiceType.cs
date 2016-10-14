// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for InvoiceType 
    /// </summary>
    public enum InvoiceType
    {
        /// <summary>
        /// Gets or sets Summary 
        /// </summary>
        [EnumValue("Item", typeof(EnumerationsResx))]
        Item = 1,

        /// <summary>
        /// Gets or sets Summary 
        /// </summary>
        [EnumValue("Summary", typeof (EnumerationsResx))] 	
        Summary = 2,
    }
}
