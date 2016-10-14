/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region Namespaces
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Audit
{
    /// <summary>
    ///  Enumerations for database auditing event types
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// Get event
        /// </summary>
        Get = 1,

        /// <summary>
        /// Insert event
        /// </summary>
        Insert = 2,

        /// <summary>
        /// Update event
        /// </summary>
        Update = 3,

        /// <summary>
        /// Delete event
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Post event
        /// </summary>
        Post = 5,

        /// <summary>
        /// Process event
        /// </summary>
        Process = 6,

        /// <summary>
        /// FilterDelete event
        /// </summary>
        FilterDelete = 7



    }
}
