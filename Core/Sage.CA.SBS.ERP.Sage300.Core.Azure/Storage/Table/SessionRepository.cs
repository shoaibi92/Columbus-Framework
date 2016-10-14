// /* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table.Entities;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

namespace Sage.CA.SBS.ERP.Sage300.Core.Azure.Storage.Table
{
    public class SessionRepository<T>: ISessionRepository<T> where T : ISession
    {
        private List<T> _sessionList;

        /// <summary>
        /// insert session entities information to logger
        /// </summary>
        /// <param name="entities"></param>
        public void Insert(List<T> entities)
        {
            _sessionList = entities;
            foreach (var entity in entities)
            {
                var sessionEntity = entity as SessionEntity;
                Log("Insert", sessionEntity);
            }
        }

        /// <summary>
        /// delete session entites information to logger
        /// </summary>
        public void Delete()
        {
            if (_sessionList != null) 
            { 
                foreach (var entity in _sessionList)
                {
                    var sessionEntity = entity as SessionEntity;
                    Log("Delete", sessionEntity);
                }
            }
        }

        /// <summary>
        /// log the session information to logger
        /// </summary>
        /// <param name="action">action: insert or delete</param>
        /// <param name="sessionEntity">Session Entity</param>
        private void Log(string action, SessionEntity sessionEntity)
        {
            try
            {
                Task.Run(() => FireAndForget(action,sessionEntity));
            }
            catch
            {
            }

        }

        /// <summary>
        /// Fire and forget async routine to log the seeion audit information to the local logger
        /// </summary>
        /// <param name="action">opeartion action</param>
        /// <param name="sessionEntity">BusinessEntity invoking event</param>
        private void FireAndForget(string action, SessionEntity sessionEntity)
        {
            if (sessionEntity != null)
            {
                var message =
                    @"Session Date: '{0}', Accpac Session ID: '{1}', Session ID: '{2}', Tenant ID: '{3}', View Count: '{4}', Company Name: '{5}', In Use: '{6}', Message: '{7}', Action: '{8}'";
                message = string.Format(message, DateTime.UtcNow.ToShortDateString(), sessionEntity.AccpacSessionId,
                    sessionEntity.SessionId, sessionEntity.TenantId, sessionEntity.ViewCount, sessionEntity.Company,
                    sessionEntity.IsInUse, sessionEntity.Message, action);
                Logger.Verbose(message, LoggingConstants.ModuleSessionAudit);
            }
        }
    }
}
