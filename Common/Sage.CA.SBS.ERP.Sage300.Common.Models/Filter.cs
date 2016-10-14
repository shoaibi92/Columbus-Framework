/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Filter class for finder
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        public Filter()
        {
            Field = new GridField();
        }

        /// <summary>
        /// GridField, which will have field/column/property details
        /// </summary>
        /// <value>The field.</value>
        public GridField Field { get; set; }

        /// <summary>
        /// Operator details (=, &lt;, &gt;, etc)
        /// </summary>
        /// <value>The operator.</value>
        public Operator Operator { get; set; }

        /// <summary>
        /// Value (which will be applied as filter)
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }

        /// <summary>
        /// Filter is not applied if Value is null or empty and ApplyFilterIfNull is set to false.
        /// If ApplyFilterIfNull is set to true, filter will always be applied.
        /// </summary>
        /// <value>The value.</value>
        public bool ApplyFilterIfNull { get; set; }
    }
}