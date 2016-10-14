/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class MultiSelect.
    /// </summary>
    public class MultiSelect
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool isSelected { get; set; }

        /// <summary>
        /// Gets or sets the value text.
        /// </summary>
        /// <value>The value text.</value>
        public string ValueText { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the value of Disabled.
        /// </summary>
        /// <value>Disabled or not</value>
        public bool Disabled { get; set; }
    }
}