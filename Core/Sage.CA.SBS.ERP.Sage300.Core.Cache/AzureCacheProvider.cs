// /* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Microsoft.ApplicationServer.Caching;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Caching;
using System;
using P = Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Sage.CA.SBS.ERP.Sage300.Core.Cache
{
    /// <summary>
    /// Class for AzureCacheProvider methods
    /// </summary>
    internal sealed class AzureCacheProvider : ICacheProvider, IDisposable
    {
        private readonly DataCache _defaultCacheProvider;
        private DataCacheFactory _cacheFactory;
        private bool _disposed;

        /// <summary>
        /// Initialize AzureCacheProvider
        /// </summary>
        public AzureCacheProvider()
        {
            _cacheFactory = new DataCacheFactory();
            _defaultCacheProvider = _cacheFactory.GetDefaultCache();
        }

        /// <summary>
        /// Sets Cache
        /// </summary>
        /// <typeparam name="T">Base data</typeparam>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        public void Set<T>(string key, T data)
        {
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() => { _defaultCacheProvider.Put(key, data); });
        }

        /// <summary>
        /// Gets data
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T cachedData = default(T);
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() => { cachedData = (T) _defaultCacheProvider.Get(key); });

            return cachedData;
        }

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="key">Key</param>
        public void Remove(string key)
        {
            var retryStrategy = new P.Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
            P.RetryPolicy retryPolicy = new P.RetryPolicy<P.StorageTransientErrorDetectionStrategy>(retryStrategy);
            retryPolicy.ExecuteAction(() => { _defaultCacheProvider.Remove(key); });
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Setting dispose
        /// </summary>
        /// <param name="disposing">Disposing value</param>
        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (_cacheFactory != null)
                {
                    _cacheFactory.Dispose();
                    _cacheFactory = null;
                    _disposed = true;
                }
            }
        }

        /// <summary>
        /// We want the cachefactory object to be disposed only once the static object instance loses scope.
        /// </summary>
        ~AzureCacheProvider()
        {
            Dispose(true);
        }
    }
}