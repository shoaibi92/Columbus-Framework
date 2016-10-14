// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit
{
    /// <summary>
    ///  Interface Session Monitoring
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        Guid TenantId { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        Guid UserId { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        string Company { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        string SessionId { get; set; }

        /// <summary>
        /// Accpac Session Id
        /// </summary>
        string AccpacSessionId { get; set; }

        /// <summary>
        /// Whether Session is In Use Or Not
        /// </summary>
        bool IsInUse { get; set; }

        /// <summary>
        /// View Count
        /// </summary>
        int ViewCount { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        string Message { get; set; }
    }
}
