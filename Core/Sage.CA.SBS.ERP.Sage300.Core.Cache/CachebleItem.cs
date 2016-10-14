/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Core.Cache
{
    /// <summary>
    /// Class for CachebleItem properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CachebleItem<T>
    {
        /// <summary>
        /// Gets or sets Item 
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets Key 
        /// </summary>
        public string Key { get; set; }
    }
}
