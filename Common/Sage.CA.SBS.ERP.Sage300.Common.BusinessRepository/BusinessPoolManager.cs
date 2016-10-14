/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ACCPAC.Advantage;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Audit;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Entity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository
{
    /// <summary>
    /// This class manages the business session pools.
    /// </summary>
    public static class BusinessPoolManager
    {
        private static readonly ConcurrentDictionary<string, ObjectPool<BusinessEntitySession>> SessionPools =
            new ConcurrentDictionary<string, ObjectPool<BusinessEntitySession>>();

        private static readonly TimeSpan TimeIntervalToClean = TimeSpan.FromMinutes(5);

        private static readonly Timer Timer = new Timer(CleanSessionPool, null, TimeIntervalToClean,
            Timeout.InfiniteTimeSpan);

        #region Public methods

        /// <summary>
        /// Get Session form the pool. This is only used by reports
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="isNew">True if its new from pool else false</param>
        /// <returns>BusinessEntitySession</returns>
        public static IBusinessEntitySession GetSession(Context context, DBLinkType dbLinkType, out bool isNew)
        {
            return GetSession(context, dbLinkType, ObjectPoolType.Default, new BusinessEntitySessionParams(), out isNew);
        }

        /// <summary>
        /// Get Session form the pool
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="objectPoolType">Object Pool Type</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        /// <param name="isNew">True if its new from pool else false</param>
        /// <returns>BusinessEntitySession</returns>
        public static IBusinessEntitySession GetSession(Context context, DBLinkType dbLinkType,
            ObjectPoolType objectPoolType, BusinessEntitySessionParams businessEntitySessionParams, out bool isNew)
        {
            //Create Pool if not exists
            var sessionPool = SessionPools.GetOrAdd(GetSessionKey(context),
                key =>
                    new ObjectPool<BusinessEntitySession>(
                        (ctx, tokenType, applicationIdentifer, programName) =>
                            BusinessEntitySession.InitializeSession(ctx,
                                (DBLinkType) Enum.Parse(typeof (DBLinkType), tokenType), applicationIdentifer,
                                programName)));

            return sessionPool.GetObject(context, dbLinkType.ToString(),
                businessEntitySessionParams.ApplicationIdentifier, businessEntitySessionParams.ProgramName,
                objectPoolType, out isNew);
        }

        /// <summary>
        /// Get NewSession form the pool
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="token">Token for the Session object</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        /// <returns>BusinessEntitySession</returns>
        public static IBusinessEntitySession GetNewSession(Context context, Guid token, DBLinkType dbLinkType,
            BusinessEntitySessionParams businessEntitySessionParams)
        {
            //Create Pool if not exists
            var sessionPool = SessionPools.GetOrAdd(GetSessionKey(context),
                key =>
                    new ObjectPool<BusinessEntitySession>(
                        (ctx, tokenType, applicationIdentifer, programName) =>
                            BusinessEntitySession.InitializeSession(ctx,
                                (DBLinkType) Enum.Parse(typeof (DBLinkType), tokenType), applicationIdentifer,
                                programName)));


            return sessionPool.GetNewObject(context, token, dbLinkType.ToString(),
                businessEntitySessionParams.ApplicationIdentifier, businessEntitySessionParams.ProgramName);
        }

        /// <summary>
        /// Returns true if there is a session associated with context.ContextToken.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        /// <returns></returns>
        public static bool IsSessionAvailable(Context context, DBLinkType dbLinkType,
            BusinessEntitySessionParams businessEntitySessionParams)
        {
            ObjectPool<BusinessEntitySession> pool;
            if (SessionPools.TryGetValue(GetSessionKey(context), out pool))
            {
                return
                    pool.GetUsedObject(context.ContextToken, dbLinkType.ToString(),
                        businessEntitySessionParams.ApplicationIdentifier, businessEntitySessionParams.ProgramName) !=
                    null;
            }
            return false;
        }

        /// <summary>
        /// Returns session associated with context.ContextToken.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="dbLinkType">DBLinkType</param>
        /// <param name="businessEntitySessionParams"></param>
        /// <param name="session">session object</param>
        /// <returns>True if session object exists or not</returns>
        public static bool TryGetSession(Context context, DBLinkType dbLinkType,
            BusinessEntitySessionParams businessEntitySessionParams, out IBusinessEntitySession session)
        {
            session = null;
            ObjectPool<BusinessEntitySession> pool;
            if (SessionPools.TryGetValue(GetSessionKey(context), out pool))
            {
                session = pool.GetUsedObject(context.ContextToken, dbLinkType.ToString(),
                    businessEntitySessionParams.ApplicationIdentifier, businessEntitySessionParams.ProgramName);
                if (session != null)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Destroy sessions which are not in use.
        /// </summary>
        /// <param name="context">Context</param>
        public static void DestroyUnusedSessions(Context context)
        {
            ObjectPool<BusinessEntitySession> pool;
            if (SessionPools.TryGetValue(GetSessionKey(context), out pool))
            {
                pool.DestroyUnusedSessions();
            }
        }

        /// <summary>
        /// Releases session based on context.ContextToken.
        /// </summary>
        /// <param name="context">Context</param>
        public static void ReleaseSession(Context context)
        {
            if (ConfigurationHelper.SessionPerPage)
            {
                Destroy(context);
            }
            else
            {
                ObjectPool<BusinessEntitySession> sessionPool;
                if (SessionPools.TryGetValue(GetSessionKey(context), out sessionPool))
                {
                    sessionPool.Dispose(context.ContextToken);
                }
            }
        }

        #region Destroy Sessions

        /// <summary>
        /// Destroys the session based on passed Token in Context object.
        /// </summary>
        /// <param name="context">Context</param>
        public static void Destroy(Context context)
        {
            ObjectPool<BusinessEntitySession> sessionPool;
            if (SessionPools.TryGetValue(GetSessionKey(context), out sessionPool))
            {
                sessionPool.Destroy(context.ContextToken);
            }
        }


        /// <summary>
        /// Destroys the session based on passed Token in Context object.
        /// This is only used for diagnostics.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="applicationIdentifier"></param>
        public static void Destroy(string sessionId, string applicationIdentifier)
        {
            var list = GetKeys(sessionId);
            foreach (var key in list)
            {
                ObjectPool<BusinessEntitySession> sessionPool;
                if (SessionPools.TryGetValue(key, out sessionPool))
                {
                    sessionPool.Destroy(applicationIdentifier);
                }
            }
        }

        /// <summary>
        /// Destroys the session based on passed Token.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="token">Token</param>
        /// <param name="dbLinkType">DBLink type</param>
        /// <param name="businessEntitySessionParams">BusinessEntitySessionParams</param>
        public static void Destroy(Context context, Guid token, DBLinkType dbLinkType, BusinessEntitySessionParams businessEntitySessionParams)
        {
            ObjectPool<BusinessEntitySession> sessionPool;
            if (SessionPools.TryGetValue(GetSessionKey(context), out sessionPool))
            {
                sessionPool.Destroy(token, dbLinkType.ToString(), businessEntitySessionParams.ApplicationIdentifier, businessEntitySessionParams.ProgramName);
            }
        }

        /// <summary>
        /// Destroys the pool when user is logged out or session is timed out.
        /// </summary>
        /// <param name="sessionId">Session Id</param>
        public static void DestroyPool(string sessionId)
        {
            var list = GetKeys(sessionId);
            foreach (var key in list)
            {
                ObjectPool<BusinessEntitySession> sessionPool;
                if (SessionPools.TryRemove(key, out sessionPool))
                {
                    sessionPool.DestroyPool();
                }
            }
        }

        #endregion


        /// <summary>
        /// Clear the session logs
        /// </summary>
        public static void ClearSessionLogs()
        {
            //Log session details
            if (ConfigurationHelper.AllowSessionLogging)
            {
                Logger.Verbose("ClearSessionLogs started.", LoggingConstants.ModuleGlobal);
                var sessionRepository = ConfigurationHelper.Container.Resolve<ISessionRepository<ISession>>();
                sessionRepository.Delete();
                Logger.Verbose("ClearSessionLogs completed.", LoggingConstants.ModuleGlobal);
            }
        }

        /// <summary>
        /// This method is gets the information about all the sessions.
        /// TODO-This needs to be removed after testing.
        /// </summary>
        /// <returns>InstrumentationData</returns>
        public static InstrumentationData GetInstrumentationData()
        {
            var currentPools = GetCurrentSessionPools().ToList(); // Get all Session Pools

            var result = new InstrumentationData {SessionPools = new List<SessionPool>()};
            foreach (var pool in currentPools)
            {
                var sessionPool = new SessionPool {SessionId = pool.Key, LastUsedDateTime = pool.Value.LastUsedDateTime};

                var sessions = pool.Value.Objects; // Get all Business Entity Session objects

                sessionPool.BusinessEntitySessions = new List<BEntitySession>();
                foreach (var currentSession in sessions.Select(session => session.Value))
                {
                    var entitySession = new BEntitySession
                    {
                        ContextToken = currentSession.Token.ToString(),
                        IsInUse = currentSession.IsInUse,
                        LastUsedDateTime = currentSession.LastUsedDateTime,
                        Description =
                            currentSession.ApplicationIdentifer + "-" + currentSession.ProgramName + "-" +
                            currentSession.TokenType
                    };

                    var entities = currentSession.BusinessEntities; // Get all Business Entity objects

                    entitySession.BusinessEntities = new List<BEntity>();
                    foreach (var currentEntity in entities.Select(entity => entity.Value))
                    {
                        entitySession.BusinessEntities.Add(new BEntity
                        {
                            Name = currentEntity.Name,
                            Description =
                                string.Format("{0}:{1}", currentEntity.Description, currentEntity.CreatedRepositoryName)
                        });
                    }

                    sessionPool.BusinessEntitySessions.Add(entitySession);
                }
                result.SessionPools.Add(sessionPool);
            }
            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get current session pools
        /// TODO-This needs to be removed after testing.
        /// </summary>
        /// <returns></returns>
        private static ConcurrentDictionary<string, ObjectPool<BusinessEntitySession>> GetCurrentSessionPools()
        {
            return SessionPools;
        }

        /// <summary>
        /// Get Session Pool key
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string GetSessionKey(Context context)
        {
            return string.Format("{0}_{1}_{2}_{3}", context.TenantId, context.ProductUserId,
                RemoveInvalidCharacters(context.Company), context.SessionId);
        }

        /// <summary>
        /// Removes Invalid characters
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static string RemoveInvalidCharacters(string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }
            if (val.Contains("_"))
            {
                return val.Replace(@"_", string.Empty);
            }
            return val;
        }

        /// <summary>
        /// Get the keys based on session Id
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        private static List<string> GetKeys(string sessionId)
        {
            return SessionPools.Keys.Where(key => key.Split('_')[3] == sessionId).ToList();
        }


        /// <summary>
        /// Clean Session pools
        /// </summary>
        private static void CleanSessionPool(object obj)
        {
            try
            {
                Logger.Verbose("CleanSessionPool started.", LoggingConstants.ModuleGlobal);
                var sessions = new List<ISession>();

                foreach (var sessionPool in SessionPools)
                {
                    if (sessionPool.Value.LastUsedDateTime.Add(ConfigurationHelper.SessionPoolTimeOut) < DateUtil.GetNowDate())
                    {
                        Logger.Verbose(string.Format("Session removed {0}.", sessionPool.Key),
                            LoggingConstants.ModuleGlobal);
                        //This is allowed in concurrent dictionary. It is fine to remove
                        ObjectPool<BusinessEntitySession> poolTobeRemoved;
                        if (SessionPools.TryRemove(sessionPool.Key, out poolTobeRemoved))
                        {
                            poolTobeRemoved.DestroyPool();
                        }
                        continue;

                    }

                    //Log session details
                    if (ConfigurationHelper.AllowSessionLogging)
                    {
                        sessions.AddRange(
                            sessionPool.Value.Objects.Select(pooledObject => Create(sessionPool, pooledObject)));
                    }
                }

                //Log session details
                if (ConfigurationHelper.AllowSessionLogging)
                {
                    Logger.Verbose("Logging Session Details.", LoggingConstants.ModuleGlobal);
                    var sessionRepository = ConfigurationHelper.Container.Resolve<ISessionRepository<ISession>>();
                    sessionRepository.Insert(sessions);
                }
                Logger.Verbose("CleanSessionPool completed.", LoggingConstants.ModuleGlobal);
            }
            catch (Exception ex)
            {
                Logger.Error("CleanSessionPool failed:", ex);
            }
            finally
            {
                Timer.Change(TimeIntervalToClean, Timeout.InfiniteTimeSpan);
            }
        }

        /// <summary>
        /// Create ISession
        /// </summary>
        /// <param name="sessionPool">Session Pool</param>
        /// <param name="pooledObject">Pooled Object</param>
        /// <returns>ISession</returns>
        private static ISession Create(KeyValuePair<string, ObjectPool<BusinessEntitySession>> sessionPool,
            KeyValuePair<Guid, BusinessEntitySession> pooledObject)
        {
            var views = pooledObject.Value.BusinessEntities;
            var session = ConfigurationHelper.Container.Resolve<ISession>();
            var sessionKeys = sessionPool.Key.Split('_'); //This should alwaus returns 4 keys.
            session.AccpacSessionId = pooledObject.Key.ToString();
            session.TenantId = Guid.Parse(sessionKeys[0]);
            session.UserId = Guid.Parse(sessionKeys[1]);
            session.Company = sessionKeys[2];
            session.SessionId = sessionKeys[3];
            session.IsInUse = pooledObject.Value.IsInUse;
            session.ViewCount = views.Count;
            var message = new StringBuilder();
            foreach (var view in views)
            {
                message.Append(view.Key + "-" + view.Value.CreatedRepositoryName + ",");
            }
            session.Message = message.ToString();
            return session;
        }


        #endregion
    }
}