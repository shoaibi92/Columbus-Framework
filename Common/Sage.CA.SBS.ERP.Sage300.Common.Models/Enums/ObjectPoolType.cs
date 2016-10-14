/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums
{
    /// <summary>
    /// Object pool Type - This only applicable for stateless screens
    /// </summary>
    public enum ObjectPoolType
    {
        /// <summary>
        /// Default
        /// </summary>
        Default,

        /// <summary>
        /// Session will not be pooled. This is only used for few KPI screens (AgedPayableRepository and AgedReceivableRepository).
        /// Session will be destroyed when repository is disposed.
        /// </summary>
        Disable,

        /// <summary>
        /// Session will be pooled per page.
        /// Session must be destroyed from UI (PageUnload event).
        /// This is used in special cases where page lock is required.
        /// </summary>
        PerPage
    }
}
