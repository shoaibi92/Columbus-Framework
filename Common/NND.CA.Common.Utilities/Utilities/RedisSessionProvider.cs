/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities
{
    /// <summary>
    /// Session Helper Methods
    /// </summary>
    public class RedisSessionProvider : ISessionCacheProvider
    {

        /// <summary>
        /// Save to session object
        /// </summary>
        /// <param name="key"></param>
        /// <param name="model"></param>
        /// <typeparam name="T"></typeparam>
        public void Set<T>(string key, T model)
        {
            System.Web.HttpContext.Current.Session[key] = JsonSerializer.SerializeWithCompression(model);
        }

        /// <summary>
        /// Get data from Session
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var val = System.Web.HttpContext.Current.Session[key];
            if (val == null)
            {
                return default(T);
            }
            return JsonSerializer.DeserializeCompressed<T>(val.ToString());
        }

        /// <summary>
        /// Delete from Session
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            System.Web.HttpContext.Current.Session.Remove(key);
        }

        /// <summary>
        /// Search for matching Keys and Remove the stored item form cache
        /// </summary>
        /// <param name="keyValueToMatch"></param>
        public void RemoveAllByMatchingKey(string keyValueToMatch)
        {
            var keyscollection = System.Web.HttpContext.Current.Session.Keys;
            for (var i = 0; i < keyscollection.Count; i++)
            {
                var key = keyscollection[i];
                if (key.Contains(keyValueToMatch))
                {
                    System.Web.HttpContext.Current.Session.Remove(key);
                }
            }
        }
    }
}