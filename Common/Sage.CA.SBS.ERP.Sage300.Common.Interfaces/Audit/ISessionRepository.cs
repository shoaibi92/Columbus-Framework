// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit
{
    /// <summary>
    /// Interface Session Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISessionRepository<T> where T : ISession
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entities">T</param>
        void Insert(List<T> entities);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete();
    }
}