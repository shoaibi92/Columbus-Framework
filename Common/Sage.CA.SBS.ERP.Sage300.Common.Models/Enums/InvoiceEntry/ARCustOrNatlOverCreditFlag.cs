// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for CustOrNatlOverCreditFlag 
    /// </summary>
    public enum ARCustOrNatlOverCreditFlag
    {
        /// <summary>
        /// Gets or sets Neitherovercreditlimit 
        /// </summary>	
        [EnumValue("NeitherOverCreditLimit", typeof(InvoiceResx), 1)]
        NeitherOverCreditLimit = 0,

        /// <summary>
        /// Gets or sets Customerovercreditlimit 
        /// </summary>	
        [EnumValue("CustomerOverCreditLimit", typeof(InvoiceResx), 1)]
        CustomerOverCreditLimit = 1,

        /// <summary>
        /// Gets or sets Nationalovercreditlimit 
        /// </summary>	
        [EnumValue("NationalOverCreditLimit", typeof(InvoiceResx), 1)]
        NationalOverCreditLimit = 2,

        /// <summary>
        /// Gets or sets Bothovercreditlimit 
        /// </summary>	
        [EnumValue("BothOverCreditLimit", typeof(InvoiceResx), 1)]
        BothOverCreditLimit = 3,
    }
}
