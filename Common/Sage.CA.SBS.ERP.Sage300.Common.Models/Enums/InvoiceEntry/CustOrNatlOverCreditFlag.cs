// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for CustOrNatlOverCreditFlag 
    /// </summary>
    public enum CustOrNatlOverCreditFlag
    {
        /// <summary>
        /// Gets or sets Neitherovercreditlimit 
        /// </summary>	
        Neitherovercreditlimit = 0,
        /// <summary>
        /// Gets or sets Customerovercreditlimit 
        /// </summary>	
        Customerovercreditlimit = 1,
        /// <summary>
        /// Gets or sets Nationalovercreditlimit 
        /// </summary>	
        Nationalovercreditlimit = 2,
        /// <summary>
        /// Gets or sets Bothovercreditlimit 
        /// </summary>	
        Bothovercreditlimit = 3,
    }
}
