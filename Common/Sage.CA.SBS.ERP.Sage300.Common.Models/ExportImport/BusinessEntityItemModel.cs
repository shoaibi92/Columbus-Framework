/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Class BusinessEntityItems.
    /// </summary>
    public class BusinessEntityItems
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessEntityItems"/> class.
        /// </summary>
        public BusinessEntityItems()
        {
            Items = new List<BusinessEntityItem>();
            //By Default - everything has to be printed (Export/Import)
            Print = true;
        }

        /// <summary>
        /// Name of the business entity
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Description of the business entity fields
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// All business entity fields
        /// </summary>
        /// <value>The items.</value>
        public IList<BusinessEntityItem> Items { get; set; }

        /// <summary>
        /// Should be printed or no - by default yes
        /// </summary>
        /// <value><c>true</c> if print; otherwise, <c>false</c>.</value>
        public bool Print { get; set; }

        /// <summary>
        /// Filter String - all the filters
        /// </summary>
        /// <value>The filter.</value>
        public string Filter { get; set; }
    }
}