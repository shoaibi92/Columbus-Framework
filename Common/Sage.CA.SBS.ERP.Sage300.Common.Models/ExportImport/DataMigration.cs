/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Data Migration class used for export Import
    /// </summary>
    public class DataMigration : ModelBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DataMigration()
        {
            Items = new List<BusinessEntityField>();
            Filters = new List<IList<Filter>>();
            //By Default - everything has to be printed (Export/Import)
            Print = true;
        }

        /// <summary>
        /// Name of the business entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the business entity fields
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// All business entity fields as GridField
        /// </summary>
        public IList<BusinessEntityField> Items { get; set; }

        /// <summary>
        /// Should be printed or no - by default yes
        /// </summary>
        public bool Print { get; set; }

        /// <summary>
        /// Filters objects - all the filters
        /// </summary>
        public IList<IList<Filter>> Filters { get; set; }

        /// <summary>
        /// Filter String - all the filters
        /// </summary>
        public string FilterString { get; set; }

        /// <summary>
        /// Filter String - all the filters
        /// </summary>
        public bool Export { get; set; }
    }
}