/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class GridSchemaModelField.
    /// </summary>
    public class GridSchemaModelField : ModelBase
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public string field { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GridSchemaModelField"/> is editable.
        /// </summary>
        /// <value><c>true</c> if editable; otherwise, <c>false</c>.</value>
        public bool editable { get; set; }
    }
}