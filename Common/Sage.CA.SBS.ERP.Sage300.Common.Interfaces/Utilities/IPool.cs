/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Utilities
{
    /// <summary>
    /// Interface IPool
    /// </summary>
    public interface IPool : IDisposable
    {
        /// <summary>
        /// Token - This determines whether the object is in use or not
        /// </summary>
        /// <value>The token.</value>
        Guid Token { get; set; }

        /// <summary>
        /// Token - This determines the extra info about the token
        /// </summary>
        /// <value>The type of the token.</value>
        string TokenType { get; set; }

        /// <summary>
        /// Application Identifier
        /// </summary>
        string ApplicationIdentifer { get; set; }

        /// <summary>
        /// Program Name
        /// </summary>
        string ProgramName { get; set; }

        /// <summary>
        /// Key - Unique Identifier
        /// </summary>
        /// <value>The key.</value>
        Guid Key { get; set; }

        /// <summary>
        /// LastUsedDateTime for that pool object
        /// </summary>
        /// <value>The last used date time.</value>
        DateTime LastUsedDateTime { get; set; }

        /// <summary>
        /// Object pool Type
        /// </summary>
        ObjectPoolType ObjectPoolType { get; set; }

        /// <summary>
        /// ReturnToPool
        /// </summary>
        /// <value>The return to pool.</value>
        Action<IPool> ReturnToPool { get; set; }

        /// <summary>
        /// True if Pooled object is in use else false
        /// </summary>
        /// <value><c>true</c> if this instance is in use; otherwise, <c>false</c>.</value>
        bool IsInUse { get; }

        /// <summary>
        /// Reset - Resets the object to its initial state
        /// </summary>
        void Reset();

        /// <summary>
        /// Reset Locks
        /// </summary>
        void ResetLocks();

        /// <summary>
        /// Unlock 
        /// </summary>
        void Unlock();

        /// <summary>
        /// Reset Session Date
        /// </summary>
        /// <param name="sessionDate">Session Date</param>
        void ResetSessionDate(DateTime sessionDate);

        /// <summary>
        /// Destroy Release all resources
        /// </summary>
        void Destroy();
    }
}