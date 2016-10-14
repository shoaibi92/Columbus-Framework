/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities
{
    /// <summary>
    /// Class ObjectPool.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : class, IPool
    {
        #region Private Fields

        /// <summary>
        /// The _objects
        /// </summary>
        private readonly ConcurrentDictionary<Guid, T> _objects;

        /// <summary>
        /// The _object generator
        /// </summary>
        private readonly Func<Context, string, string, string, T> _objectGenerator;

        /// <summary>
        /// The _return to pool action
        /// </summary>
        private readonly Action<IPool> _returnToPoolAction;

        /// <summary>
        /// The _sync root
        /// </summary>
        private readonly Object _syncRoot = new Object();

        #endregion

        /// <summary>
        /// Maximum pool count
        /// </summary>
        /// <value>The maximum size of the pool.</value>
        public int MaximumPoolSize { get; private set; }

        /// <summary>
        /// Maximum number of concurrent sessions allowed per user. If it is -1 then no restrictions.
        /// </summary>
        /// <value>The maximum size of the pool.</value>
        public int MaxAllowedSessions { get; private set; }

        /// <summary>
        /// Is Session Pool Enabled
        /// </summary>
        public bool SessionPoolEnabled { get; private set; }
        
        /// <summary>
        /// Last Used Date Time
        /// </summary>
        public DateTime LastUsedDateTime { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objectGenerator">Function to generate object</param>
        /// <exception cref="System.ArgumentNullException">objectGenerator</exception>
        public ObjectPool(Func<Context, string, string, string, T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objects = new ConcurrentDictionary<Guid, T>();
            MaximumPoolSize = ConfigurationHelper.MaxSessionPoolSize;
            SessionPoolEnabled = ConfigurationHelper.SessionPoolEnabled;
            MaxAllowedSessions = ConfigurationHelper.MaxAllowedSessions;
            _objectGenerator = objectGenerator;
            _returnToPoolAction = ReturnObjectToPool;
            LastUsedDateTime = DateUtil.GetNowDate();
        }

        #region Public Methods

        /// <summary>
        /// Get object from the pool
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="tokenType">Token type</param>
        /// <param name="programName">Program Name</param>
        /// <param name="objectPoolType">ObjectPoolType</param>
        /// <param name="isNew">True if its new from pool else false</param>
        /// <param name="applicationIdentifer">Applcation Identifier</param>
        /// <returns>T</returns>
        public T GetObject(Context context, string tokenType, string applicationIdentifer, string programName, ObjectPoolType objectPoolType, out bool isNew)
        {
            isNew = false;
            T obj;
            LastUsedDateTime = DateUtil.GetNowDate();
            //if (context.ContextToken == Guid.Empty)
            //{
            //    throw new ArgumentException("context.ContextToken is empty.");
            //}
            lock (_syncRoot)
            {
                obj = GetUsedObjectFromPool(context.ContextToken, tokenType, applicationIdentifer, programName);
                if (obj == null)
                {
                    isNew = true;
                    if (objectPoolType != ObjectPoolType.PerPage)
                    {
                        obj = GetUnUsedObjectFromPool(context.ContextToken, tokenType, applicationIdentifer, programName);
                    }
                    if (obj == null)
                    {
                        obj = AddObject(context, context.ContextToken, tokenType, applicationIdentifer, programName, objectPoolType);
                    }
                }
                obj.ResetSessionDate(context.SessionDate);
            }
            return obj;
        }

        /// <summary>
        /// Get new object from the pool
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="token">Token</param>
        /// <param name="tokenType">Token type</param>
        /// <param name="applicationIdentifer">Application Identifier</param>
        /// <param name="programName">Program Name</param>
        /// <returns>T</returns>
        public T GetNewObject(Context context, Guid token, string tokenType, string applicationIdentifer, string programName)
        {
            LastUsedDateTime = DateUtil.GetNowDate();
            lock (_syncRoot)
            {
                return AddObject(context, token, tokenType, applicationIdentifer, programName, ObjectPoolType.Default);
            }
        }

        /// <summary>
        /// Get the object under use. 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tokenType"></param>
        /// <param name="applicationIdentifer">Application Identifer</param>
        /// <param name="programName">Program Name</param>
        /// <returns></returns>
        public T GetUsedObject(Guid token, string tokenType, string applicationIdentifer, string programName)
        {
            LastUsedDateTime = DateUtil.GetNowDate();
            lock (_syncRoot)
            {
                return GetUsedObjectFromPool(token, tokenType, applicationIdentifer, programName);
            }
        }

        /// <summary>
        /// Destroy sessions which are not in use.
        /// </summary>
        public void DestroyUnusedSessions()
        {
            lock (_syncRoot)
            {
                foreach (var obj in _objects.Where(obj => !obj.Value.IsInUse))
                {
                    RemoveObject(obj.Key);
                }
            }
        }
              
        /// <summary>
        /// Dispose the object. Return the object to the pool.
        /// </summary>
        /// <param name="token">The token.</param>
        public void Dispose(Guid token)
        {
            lock (_syncRoot)
            {
                //There can be multiple session objects based on db type, application identifer, program name
                foreach (var obj in _objects.Values.Where(pooledObject => pooledObject.Token == token))
                {
                    obj.Dispose();
                }
            }
        }

        #region Destroy

        /// <summary>
        /// Removes all the objects from the pool
        /// </summary>
        public void DestroyPool()
        {
            lock (_syncRoot)
            {
                foreach (var obj in _objects)
                {
                    Destroy(obj.Value);
                }
                _objects.Clear();
            }
        }

        /// <summary>
        /// Removes all the objects from the pool based on application identifer
        /// </summary>
        /// <param name="applicationIdentifier">applicationIdentifier</param>
        public void Destroy(string applicationIdentifier)
        {
            lock (_syncRoot)
            {
                foreach (var obj in _objects.Where(o => o.Value.ApplicationIdentifer == applicationIdentifier))
                {
                    RemoveObject(obj.Key);
                }
            }
        }

        /// <summary>
        /// Destroy the object from the pool.
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="tokenType">TokenType</param>
        /// <param name="applicationIdentifer">ApplicationIdentifier</param>
        /// <param name="programName">ProgramName</param>
        public void Destroy(Guid token, string tokenType, string applicationIdentifer, string programName)
        {
            lock (_syncRoot)
            {
                var objectToDestory =
                    _objects.Values.SingleOrDefault(
                        obj =>
                            obj.Token == token && obj.TokenType == tokenType &&
                            obj.ApplicationIdentifer == applicationIdentifer &&
                            obj.ProgramName == programName);
                if (objectToDestory != null)
                {
                    RemoveObject(objectToDestory.Key);
                }
            }
        }

        /// <summary>
        /// Destroys all the objects from the pool based on token
        /// </summary>
        public void Destroy(Guid token)
        {
            lock (_syncRoot)
            {
                foreach (var obj in _objects.Where(obj => obj.Value.Token == token))
                {
                    RemoveObject(obj.Key);
                }
            }
        }

        #endregion

        /// <summary>
        /// Return object to pool.
        /// This is called when object is disposed.
        /// </summary>
        /// <param name="objectToReturnToPool">IPool object</param>
        public void ReturnObjectToPool(IPool objectToReturnToPool)
        {
            lock (_syncRoot)
            {
                var sessionPerPage = ConfigurationHelper.SessionPerPage ||
                                     objectToReturnToPool.ObjectPoolType == ObjectPoolType.PerPage;
                if (!sessionPerPage)
                {
                    objectToReturnToPool.Token = Guid.Empty;
                }

                objectToReturnToPool.Reset();

                if (!SessionPoolEnabled)
                {
                    //Applicable only for worker, report and web api.
                    RemoveObject(objectToReturnToPool.Key);
                }
                else
                {
                    //Only when current object is released there is a chance that pool size can be adjusted.
                    if (!objectToReturnToPool.IsInUse)
                    {
                        //Applicable for web role
                        AdjustPoolSize(objectToReturnToPool.ApplicationIdentifer, objectToReturnToPool.TokenType,
                            objectToReturnToPool.ProgramName);
                    }
                }
            }
        }

        /// <summary>
        /// True if Session Pool is in use else false
        /// </summary>
        public bool IsSessionPoolInUse()
        {
            return _objects.Values.Any(obj => obj.IsInUse);
        }

        /// <summary>
        /// Return all business entity sessions
        /// </summary>
        /// <returns>ConcurrentDictionary&lt;Guid, T&gt;.</returns>
        public ConcurrentDictionary<Guid, T> Objects
        {
            get { return _objects; }
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Get object from pool with the specified token
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="tokenType">Token Type</param>
        /// <param name="applicationIdentifer">Application Identifier</param>
        /// <param name="programName">Program Name</param>
        /// <returns>T</returns>
        private T GetUsedObjectFromPool(Guid token, string tokenType, string applicationIdentifer, string programName)
        {
            var obj =
                _objects.Values.SingleOrDefault(
                    pooledObject =>
                        pooledObject.Token == token && pooledObject.TokenType == tokenType &&
                        pooledObject.ApplicationIdentifer == applicationIdentifer &&
                        pooledObject.ProgramName == programName);
            if (obj != null)
            {
                obj.LastUsedDateTime = DateUtil.GetNowDate();
            }
            return obj;
        }

        /// <summary>
        /// Get unused object from pool
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="tokenType">Token Type</param>
        /// <param name="applicationIdentifer">Application Identifer</param>
        /// <param name="programName">Program Name</param>
        /// <returns>T</returns>
        private T GetUnUsedObjectFromPool(Guid token, string tokenType, string applicationIdentifer, string programName)
        {
            T obj =
                _objects.Values.FirstOrDefault(
                    pooledObject => !pooledObject.IsInUse 
                        && pooledObject.TokenType == tokenType
                        && pooledObject.ApplicationIdentifer == applicationIdentifer
                        && pooledObject.ProgramName == programName);
            if (obj != null)
            {
                obj.ResetLocks();
                obj.LastUsedDateTime = DateUtil.GetNowDate();
                obj.Token = token;
            }
            return obj;
        }

        /// <summary>
        /// Adds a new object in pool
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="token">Token</param>
        /// <param name="tokenType">Token Type</param>
        /// <param name="programName">Program Name</param>
        /// <param name="objectPoolType">ObjectPoolType</param>
        /// <param name="applicationIdentifer">ApplicationIdentifer</param>
        /// <returns>T</returns>
        private T AddObject(Context context, Guid token, string tokenType, string applicationIdentifer, string programName, ObjectPoolType objectPoolType)
        {
            if (MaxAllowedSessions > 0 && MaxAllowedSessions <= _objects.Count)
            {
                throw new SessionOverflowException();
            }
            T obj = _objectGenerator(context, tokenType, applicationIdentifer, programName);
            obj.ReturnToPool = _returnToPoolAction;
            obj.Token = token;
            obj.TokenType = tokenType;
            obj.Key = Guid.NewGuid();
            obj.ObjectPoolType = objectPoolType;
            obj.LastUsedDateTime = DateUtil.GetNowDate();
            obj.ApplicationIdentifer = applicationIdentifer;
            obj.ProgramName = programName;
            _objects.TryAdd(obj.Key, obj);
            Trace.WriteLine(String.Format(
                "ObjectPool: Session [{2}] added to pool - Token - {0}/{1}, Total Count - {3}", obj.Token, obj.TokenType,
                obj.Key, _objects.Count));
            return obj;
        }

        /// <summary>
        /// Remove Object
        /// </summary>
        /// <param name="key">Key</param>
        private void RemoveObject(Guid key)
        {
            T objectToRemove;
            if (_objects.TryRemove(key, out objectToRemove))
            {
                Destroy(objectToRemove);
            }
        }

        /// <summary>
        /// Adjust pool size
        /// </summary>
        /// <param name="applicationIdentifier">Remove based on application identifier</param>
        /// <param name="tokenType"></param>
        /// <param name="programName"></param>
        private void AdjustPoolSize(string applicationIdentifier, string tokenType, string programName)
        {
            if (MaximumPoolSize == -1)
            {
                return;
            }
            var numberOfobjectsToDestroy =
                _objects.Count(
                    o =>
                        !o.Value.IsInUse && o.Value.ApplicationIdentifer == applicationIdentifier &&
                        o.Value.ProgramName == programName && o.Value.TokenType == tokenType) - MaximumPoolSize;
            if (numberOfobjectsToDestroy > 0)
            {
                var keys =
                    _objects.Values.Where(
                        pooledObject =>
                            !pooledObject.IsInUse && pooledObject.ApplicationIdentifer == applicationIdentifier &&
                            pooledObject.ProgramName == programName && pooledObject.TokenType == tokenType)
                        .OrderBy(pooledObject => pooledObject.LastUsedDateTime)
                        .Select(pooledObject => pooledObject.Key)
                        .Take(numberOfobjectsToDestroy);

                foreach (var key in keys)
                {
                    RemoveObject(key);
                }
            }
        }

        /// <summary>
        /// Destroy pooled object
        /// </summary>
        /// <param name="objectToDestroy">IPool object</param>
        private void Destroy(IPool objectToDestroy)
        {
            objectToDestroy.Destroy();
            Trace.WriteLine(string.Format("ObjectPool:Session destroyed : {0}", objectToDestroy.Key));
        }

        #endregion
    }
}