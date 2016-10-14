/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of properties for OrderBy
    /// </summary>
    public class OrderBy
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>The name of the property.</value>
        public String PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>The sort direction.</value>
        public SortDirection SortDirection { get; set; }
    }

    /// <summary>
    /// Enums for Sort Direction
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// The ascending
        /// </summary>
        Ascending = 0, // ascending is the default value

        /// <summary>
        /// The descending
        /// </summary>
        Descending = 1
    }
}