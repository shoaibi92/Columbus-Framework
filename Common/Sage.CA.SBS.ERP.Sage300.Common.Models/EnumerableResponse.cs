/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of IEnumerable items
    /// </summary>
    /// <typeparam name="T">Base type</typeparam>
    public class EnumerableResponse<T> : ModelBase where T : ModelBase
    {
        /// <summary>
        /// This constructor initializes the Items and Errors lists to be empty.
        /// This avoids the problem of serializing null collections.
        /// </summary>
        public EnumerableResponse()
        {
            Items = new List<T>();
            Errors = new List<EntityError>();
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Gets or sets the total results count.
        /// </summary>
        /// <value>The total results count.</value>
        public int TotalResultsCount { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<EntityError> Errors { get; set; }

        /// <summary>
        /// CachedListCount
        /// </summary>
        public int CachedListCount { get; set; }
    }
}