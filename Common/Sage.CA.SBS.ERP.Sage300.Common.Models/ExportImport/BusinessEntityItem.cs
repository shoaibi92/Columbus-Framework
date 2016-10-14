/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Class BusinessEntityItem.
    /// </summary>
    public class BusinessEntityItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessEntityItem"/> class.
        /// </summary>
        public BusinessEntityItem()
        {
            //By default Print (export/Import)
            Print = true;
        }

        /// <summary>
        /// Id of the business entity fields
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Name of the business entity fields
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Description of the business entity fields
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Value of the business entity fields
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }

        /// <summary>
        /// Data Type of the business entity fields
        /// </summary>
        /// <value>The type of the data.</value>
        public string DataType { get; set; }

        /// <summary>
        /// Print or no for the business entity fields
        /// </summary>
        /// <value><c>true</c> if print; otherwise, <c>false</c>.</value>
        public bool Print { get; set; }

        /// <summary>
        /// Presentation list with all allowed item
        /// </summary>
        /// <value>The presentation list.</value>
        public IList<CustomSelectList> PresentationList { get; set; }
    }
}