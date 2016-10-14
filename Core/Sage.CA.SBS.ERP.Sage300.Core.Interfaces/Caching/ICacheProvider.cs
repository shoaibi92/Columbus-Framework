/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.Caching
{
    /// <summary>
    /// Interface for ICacheProvider properties
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Sets data
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="data">Data</param>
        void Set<T>(string key, T data);

        /// <summary>
        /// Gets data based on key
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// Removes based on key
        /// </summary>
        /// <param name="key">Key</param>
        void Remove(string key);

    }
}
