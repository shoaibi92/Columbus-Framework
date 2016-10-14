/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Gets all detail about Session Pools
    /// </summary>
    public class InstrumentationData
    {
        /// <summary>
        /// Gets or sets the session pools.
        /// </summary>
        /// <value>The session pools.</value>
        public List<SessionPool> SessionPools { get; set; }

        /// <summary>
        /// TotalSessionCount
        /// </summary>
        public int TotalSessionCount
        {
            get
            {
                return SessionPools.Aggregate(0, (current, sessionPool) => current + sessionPool.BusinessEntitySessions.Count);
            }
        }
    }

    /// <summary>
    /// Class SessionPool.
    /// </summary>
    public class SessionPool
    {
        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>The session identifier.</value>
        public string SessionId { get; set; }
        
        /// <summary>
        /// Last Used Date Time
        /// </summary>
        public DateTime LastUsedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the business entity sessions.
        /// </summary>
        /// <value>The business entity sessions.</value>
        public List<BEntitySession> BusinessEntitySessions { get; set; }
    }

    /// <summary>
    /// Class BEntitySession.
    /// </summary>
    public class BEntitySession
    {
        /// <summary>
        /// Gets or sets the context token.
        /// </summary>
        /// <value>The context token.</value>
        public string ContextToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is in use.
        /// </summary>
        /// <value><c>true</c> if this instance is in use; otherwise, <c>false</c>.</value>
        public bool IsInUse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is destroyed.
        /// </summary>
        /// <value><c>true</c> if this instance is destroyed; otherwise, <c>false</c>.</value>
        public bool IsDestroyed { get; set; }

        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of business entities.
        /// </summary>
        /// <value>The business entitys.</value>
        public List<BEntity> BusinessEntities { get; set; }

        /// <summary>
        /// Last Used Date Time
        /// </summary>
        public DateTime LastUsedDateTime { get; set; }

    }

    /// <summary>
    /// Class BEntity.
    /// </summary>
    public class BEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}