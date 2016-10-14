/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */
// This is a duplicate of BatchType except for recurring and Generated code. This batch 
//type is being used by AR invoicebatch and because there is a common class for this model we have for time being added this model hereusing Sage.CA.SBS.ERP.Sage300.Common.Resources;
//this  enum will be removed once we figure out a solution to move fields a level below.
using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for BatchType 
    /// </summary>
    public enum ARBatchType
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
        [EnumValue("Recurring", typeof(InvoiceResx))]
        Recurring = 3,

        /// <summary>
        /// Gets or sets Recurring 
        /// </summary>	
        [EnumValue("Generated", typeof(InvoiceResx))]
        Generated = 4,

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
