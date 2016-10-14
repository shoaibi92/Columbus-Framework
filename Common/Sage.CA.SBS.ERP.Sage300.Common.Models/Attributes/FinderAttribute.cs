/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Attributes
{
    /// <summary>
    /// Finder Attribute
    /// </summary>
    public class FinderAttribute : Attribute
    {
        /// <summary>
        /// Order of the finder
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Default value of the finder
        /// </summary>
        public bool Default { get; set; }

        /// <summary>
        /// Attributes required to display (style)
        /// </summary>
        public string Attributes { get; set; }

        /// <summary>
        /// True if hidden else false
        /// </summary>
        public bool Hidden { get; set; }
    }
}