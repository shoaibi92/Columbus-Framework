// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for BillingType 
    /// </summary>
    public enum BillingType
    {
        /// <summary>
        /// Gets or sets  
        /// </summary>	
        [EnumValue("None", typeof(CommonResx))] 
        None = 0,

        /// <summary>
        /// Gets or sets Nonbillable 
        /// </summary>	
        [EnumValue("Nonbillable", typeof(InvoiceResx))]
        Nonbillable = 1,

        /// <summary>
        /// Gets or sets Billable 
        /// </summary>	
        [EnumValue("Billable", typeof(InvoiceResx))]
        Billable = 2,

        /// <summary>
        /// Gets or sets NoCharge 
        /// </summary>	
        [EnumValue("NoCharge", typeof(InvoiceResx))] 
        NoCharge = 3
    }
}
