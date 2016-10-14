// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for BatchStatus 
    /// </summary>
    public enum BatchStatus
    {
        /// <summary>
        /// Gets or sets Open 
        /// </summary>	
        [EnumValue("Open", typeof(InvoiceResx))]
        Open = 1,

        /// <summary>
        /// Gets or sets Posted 
        /// </summary>	
        [EnumValue("Posted", typeof(InvoiceResx))]
        Posted = 3,

        /// <summary>
        /// Gets or sets Deleted 
        /// </summary>	
        [EnumValue("Deleted", typeof(InvoiceResx))]
        Deleted = 4,

        /// <summary>
        /// Gets or sets PostInProgress 
        /// </summary>	
        [EnumValue("PostInProgress", typeof(InvoiceResx))]
        PostInProgress = 5,

        /// <summary>
        /// Gets or sets ReadyToPost 
        /// </summary>	
        [EnumValue("ReadyToPost", typeof(InvoiceResx))]
        ReadyToPost = 7,
    }
}
