/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Web;
using Sage.CA.SBS.ERP.Sage300.Core.Cache;

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class PsuedoSessionProvider : ISessionCacheProvider
    {   
        /// <summary>
        /// Stores All the keys
        /// </summary>
        private static IList<string> _keys;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PsuedoSessionProvider()
        {
            if (_keys == null)
            {
                _keys = new List<string>();
            }
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        public void Set<T>(string key, T data)
        {
            if (!_keys.Contains(key))
            {
                _keys.Add(key);
            }
            CacheHelper.Set(key,data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string key) 
        {
            return CacheHelper.Get<T>(key);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            CacheHelper.Remove(key);
        }

        /// <summary>
        /// Search for matching Keys and Remove the stored item form cache
        /// </summary>
        /// <param name="keyValueToMatch"></param>
        public void RemoveAllByMatchingKey(string keyValueToMatch)
        {
            var keyCount = _keys.Count;
            for (var i = 0; i < keyCount; i++)
            {
                var key = _keys[i];
                if (key.Contains(keyValueToMatch))
                {
                    _keys.Remove(key);
                    keyCount--;
                }
            }
        }
    }
}