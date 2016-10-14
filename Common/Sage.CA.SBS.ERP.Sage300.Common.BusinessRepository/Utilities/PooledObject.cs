/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// PooledObject - Any class that needs to pool needs to inherit this class
    /// </summary>
    public abstract class PooledObject : IPool
    {

        /// <summary>
        /// Token 
        /// </summary>
        public string ApplicationIdentifer { get; set; }

        /// <summary>
        /// Token 
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// Token 
        /// </summary>
        public Guid Token { get; set; }

        /// <summary>
        /// Token - This determines the extra info about the token 
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Key - Unique Identifier
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// Object pool Type
        /// </summary>
        public ObjectPoolType ObjectPoolType { get; set; }

        /// <summary>
        /// LastUsedDateTime
        /// </summary>
        public DateTime LastUsedDateTime { get; set; }

        /// <summary>
        /// ReturnToPool
        /// </summary>
        public Action<IPool> ReturnToPool { get; set; }

        /// <summary>
        /// True if Pooled object is in use else false
        /// </summary>
        public bool IsInUse
        {
            get { return Token != Guid.Empty; }
        }

        /// <summary>
        /// Reset - Resets the object to its initial state
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// Reset Locks
        /// </summary>
        public virtual void ResetLocks()
        {
        }

        /// <summary>
        /// Unlock
        /// </summary>
        public virtual void Unlock()
        {
        }

        /// <summary>
        /// Reset Session Date
        /// </summary>
        /// <param name="sessionDate">Session Date</param>
        public virtual void ResetSessionDate(DateTime sessionDate)
        {
        }

        /// <summary>
        /// Destroy Release all resources
        /// </summary>
        public abstract void Destroy();

        /// <summary>
        /// Dispose - Returns the object back to the pool
        /// </summary>
        public void Dispose()
        {
            //TODO - This call can be asynchronous
            ReturnToPool(this);
        }
    }
}