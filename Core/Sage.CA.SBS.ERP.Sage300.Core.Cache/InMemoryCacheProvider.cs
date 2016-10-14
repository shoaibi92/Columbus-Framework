/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Caching;
using System;
using System.Runtime.Caching;

namespace Sage.CA.SBS.ERP.Sage300.Core.Cache
{
    /// <summary>
    /// Class for InMemoryCacheProvider
    /// </summary>
    public sealed class InMemoryCacheProvider : ICacheProvider, IDisposable
    {
        /// <summary>
        /// The in memory cache
        /// </summary>
        private static readonly Lazy<InMemoryCacheProvider> InMemoryCache = new Lazy<InMemoryCacheProvider>(() => new InMemoryCacheProvider(DefaultCacheExpirationTimeinMinutes));
        private static readonly Lazy<InMemoryCacheProvider> InMemoryCacheOneDay = new Lazy<InMemoryCacheProvider> (() => new InMemoryCacheProvider(OneDayExpirationTime));
        /// <summary>
        /// Default CacheExpiration 
        /// </summary>
        private const int DefaultCacheExpirationTimeinMinutes = 30;
        private const int OneDayExpirationTime = 1440;

        private bool _disposed;
        private MemoryCache _cache;

        /// <summary>
        /// Prevents a default instance of the <see cref="InMemoryCacheProvider"/> class from being created.
        /// </summary>
        private InMemoryCacheProvider(int minutes)
        {
            _defaultCacheItemPolicy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromMinutes(minutes),
                
                // when item got removed from the cache, call back event will dispose the item immediately.
                RemovedCallback = args =>
                {
                    // Check if the items is disposable.
                    var value = args.CacheItem.Value as IDisposable;
                    if (value != null)
                    {
                        // dispose the item.
                        value.Dispose();
                    }
                }
            };

            _cache = MemoryCache.Default;
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static InMemoryCacheProvider Instance
        {
            get
            {
                return InMemoryCache.Value;
            }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static InMemoryCacheProvider InstanceOneDay
        {
            get
            {
                return InMemoryCacheOneDay.Value;
            }
        }

        /// <summary>
        /// Cache Item Policy
        /// </summary>
        private readonly CacheItemPolicy _defaultCacheItemPolicy;

        /// <summary>
        /// Sets data
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        public void Set<T>(string key, T data)
        {
            _cache.Set(new CacheItem(key, data), _defaultCacheItemPolicy);
        }

        /// <summary>
        /// Gets data based on key
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="key">Key</param>
        public void Remove(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _cache.Remove(key);
            }
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
                if (_cache != null)
                {
                    _cache.Dispose();
                    _cache = null;
                    _disposed = true;
                }
            }
        }

        /// <summary>
        /// We want the remove object to be disposed only once the static object instance loses scope.
        /// </summary>
        ~InMemoryCacheProvider()
        {
            Dispose(true);
        }
    }
}
