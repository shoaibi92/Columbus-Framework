/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum for ProcessCommandCode 
    /// </summary>
    public enum ProcessCommandCode
    {
        /// <summary>
        /// Gets or sets UnlockBatchResource 
        /// </summary>	
        [EnumValue("UnlockBatchResource", typeof(EnumerationsResx))]
        UnlockBatchResource = 0,

        /// <summary>
        /// Gets or sets LockBatchResourceShared 
        /// </summary>	
        [EnumValue("LockBatchResourceShared", typeof(EnumerationsResx))]
        LockBatchResourceShared = 1,

        /// <summary>
        /// Gets or sets LockBatchResourceExclusive 
        /// </summary>	
        [EnumValue("LockBatchResourceExclusive", typeof(EnumerationsResx))]
        LockBatchResourceExclusive = 2,
    }
}
