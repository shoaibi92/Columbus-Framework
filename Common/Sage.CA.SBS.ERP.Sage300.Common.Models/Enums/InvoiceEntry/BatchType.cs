/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for BatchType 
    /// </summary>
    public enum BatchType
    {
        /// <summary>
        /// Gets or sets Entered 
        /// </summary>	
        [EnumValue("Entered", typeof(InvoiceResx))]
        Entered = 1,

        /// <summary>
        /// Gets or sets Imported 
        /// </summary>	
        [EnumValue("Imported", typeof(InvoiceResx))]
        Imported = 2,

        /// <summary>
        /// Gets or sets Generated 
        /// </summary>	
        [EnumValue("Generated", typeof(InvoiceResx))]
        Generated = 3,

        /// <summary>
        /// Gets or sets Recurring 
        /// </summary>	
        [EnumValue("Recurring", typeof(InvoiceResx))]
        Recurring = 4,

        /// <summary>
        /// Gets or sets External 
        /// </summary>	
        [EnumValue("External", typeof(InvoiceResx))]
        External = 5,

        /// <summary>
        /// Gets or sets Retainage 
        /// </summary>	
        [EnumValue("Retainage", typeof(InvoiceResx))]
        Retainage = 6,
    }
}
