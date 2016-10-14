/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Web.Mvc;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Export Request Model, used as seed entitty
    /// </summary>
    public class ExportRequest : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportRequest"/> class.
        /// </summary>
        public ExportRequest()
        {
            DataMigrationList = new List<DataMigration>();
            Keys = new List<string>();
            FileTypes = EnumUtility.GetItemsList<FileType>();
        }

        /// <summary>
        /// Name - what to export
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Model list
        /// </summary>
        /// <value>The data migration list.</value>
        public IList<DataMigration> DataMigrationList { get; set; }

        /// <summary>
        /// Keys
        /// </summary>
        /// <value>The keys.</value>
        public IList<string> Keys { get; set; }

        /// <summary>
        /// Selected File Type
        /// </summary>
        public FileType FileType { get; set; }

        /// <summary>
        /// File Types - All
        /// </summary>
        public IEnumerable<CustomSelectList> FileTypes { get; set; }

        /// <summary>
        /// Selected export/import option
        /// </summary>
        public string SelectedOption { get; set; }

        /// <summary>
        /// ClientId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// HUB Url
        /// </summary>
        public string HubUrl { get; set; }
    }
}