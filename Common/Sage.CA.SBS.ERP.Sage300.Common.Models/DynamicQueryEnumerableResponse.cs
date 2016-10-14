/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of IEnumerable items for a Dynamic Query
    /// </summary>
    /// <typeparam name="T">Base type</typeparam>
    public class DynamicQueryEnumerableResponse<T> : ApplicationModelBase where T : ApplicationModelBase
    {
        /// <summary>
        /// This constructor initializes the Items and Errors lists to be empty.
        /// This avoids the problem of serializing null collections.
        /// </summary>
        public DynamicQueryEnumerableResponse()
        {
            Items = new List<T>();
            Errors = new List<EntityError>();
            Filters = new Dictionary<string, string>();
            CurrencySymbol = string.Empty;
        }

        /// <summary>
        /// Gets or sets the Currency Symbol
        /// </summary>
        /// <value>The currency symbol</value>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the items
        /// </summary>
        /// <value>The items</value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        /// <value>The errors</value>
        public List<EntityError> Errors { get; set; }

        /// <summary>
        /// Gets or sets the filters
        /// </summary>
        /// <value>The filters</value>
        public Dictionary<string, string> Filters { get; set; }
    }
}