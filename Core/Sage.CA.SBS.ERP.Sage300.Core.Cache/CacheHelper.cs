/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Core.Cache.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Caching;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using System;

namespace Sage.CA.SBS.ERP.Sage300.Core.Cache
{
    /// <summary>
    /// Helper For Cache 
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        /// ICache Provider
        /// </summary>
        private static readonly ICacheProvider DefaultCacheProvider;

        /// <summary>
        /// Set the default provider based on deployment
        /// </summary>
        static CacheHelper()
        {
            var cacheProviderTypeName = ConfigurationHelper.SageCacheProvider;

            try
            {
                // TODO: Try catch has to removed after testing.

                // This Is A Valid Configuration Option (Not Exceptional) - Not Throwing CacheInitializationException
                if (string.IsNullOrWhiteSpace(cacheProviderTypeName))
                {
                    Logger.Info("InMemoryCacheProvider Activated", "Common");
                    DefaultCacheProvider = InMemoryCacheProvider.Instance;
                    return;
                }

                var cacheProviderType = Type.GetType(cacheProviderTypeName, false);

                if (cacheProviderType == null) throw new CacheInitializationException("Caching Provider Not Found.");

                Logger.Info(String.Format("Cache : {0}", cacheProviderType.FullName), "Common");

                DefaultCacheProvider = Activator.CreateInstance(cacheProviderType) as ICacheProvider;

                if (DefaultCacheProvider == null) throw new CacheInitializationException("Caching Provider Not Activated.");

            }
            catch (Exception exception)
            {
                Logger.Info("Exception when Initalizing cache." + exception.Message + " " + exception.InnerException, "CacheHelper");

                Logger.Info("InMemoryCacheProvider Activated", "Common");

                DefaultCacheProvider = InMemoryCacheProvider.Instance;
            }
        }

        /// <summary>
        /// Gets data based on key
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return DefaultCacheProvider.Get<T>(key);
        }

        /// <summary>
        /// Sets data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public static void Set<T>(string key, T value)
        {
            DefaultCacheProvider.Set(key, value);
        }

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            DefaultCacheProvider.Remove(key);
        }
    }
}



