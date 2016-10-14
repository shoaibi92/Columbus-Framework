// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;

namespace Sage.CA.SBS.ERP.Sage300.Common.Audit.Session
{
    public class SessionRepository<T>: ISessionRepository<T> where T : ISession
    {
        /// <summary>
        /// This implement is not implemented 
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(List<T> entities)
        {
            //Don't do anything
        }

        /// <summary>
        /// This implement is not implemented 
        /// </summary>
        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
