// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.InvoiceEntry
{
    /// <summary>
    /// Enum LockBatchSwitch
    /// </summary>
    public enum LockBatchSwitch
    {
        /// <summary>
        /// The unlock batch resource
        /// </summary>
        UnlockBatchResource = 0,

        /// <summary>
        /// The lock batch resource shared
        /// </summary>
        LockBatchResourceShared = 1,

        /// <summary>
        /// The lock batch resource exclusive
        /// </summary>
        LockBatchResourceExclusive = 2,
    }
}