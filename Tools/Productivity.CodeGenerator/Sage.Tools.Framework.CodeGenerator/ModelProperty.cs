/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

// THIS CLASS IS OBSOLETE AND WILL SOON BE REMOVED

namespace Sage.Tools.Framework.CodeGenerator
{
    /// <summary>
    /// Model Property
    /// </summary>
    public class ModelProperty
    {
        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public int MaxLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is key field.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is key field; otherwise, <c>false</c>.
        /// </value>
        public bool IsKeyField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required field.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is required field; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequiredField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is field input capital letter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is field input capital letter; otherwise, <c>false</c>.
        /// </value>
        public bool IsFieldInputCapitalLetter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is field input alpha numeric.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is field input alpha numeric; otherwise, <c>false</c>.
        /// </value>
        public bool IsFieldInputAlphaNumeric { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is field input alpha numeric.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is field input alpha numeric; otherwise, <c>false</c>.
        /// </value>
        public bool IsFieldInputNumeric { get; set; }
    }
}
