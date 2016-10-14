/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Class for FIlter Implementation
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Filter()
        {
            BusinessEntityField = new BusinessEntityItem();
        }

        /// <summary>
        /// Business Entity Field details
        /// </summary>
        /// <value>The business entity field.</value>
        public BusinessEntityItem BusinessEntityField { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public string Operator { get; set; }

        /// <summary>
        /// Filter value
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
}