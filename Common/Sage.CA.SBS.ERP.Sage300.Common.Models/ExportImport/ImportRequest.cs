/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Linq;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport
{
    /// <summary>
    /// Export Request Model, used as seed entitty
    /// </summary>
    public class ImportRequest : ModelBase
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public ImportRequest()
        {
            FileTypes = EnumUtility.GetItemsList<FileType>();
            ImportTypes = GetImportTypes();
            IsTitleRecord = true;
        }

        /// <summary>
        /// Name - what to export
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Import Option, will be used by implementor class for the different type of imports
        /// </summary>
        public string ImportOption { get; set; }

        /// <summary>
        /// Keys
        /// </summary>
        public IList<string> Keys { get; set; }

        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Selected File Type
        /// </summary>
        public FileType FileType { get; set; }

        /// <summary>
        /// File Types - All
        /// </summary>
        public IEnumerable<CustomSelectList> FileTypes { get; set; }

        /// <summary>
        /// Selected Import Type : Insert/Update - Update - Insert
        /// </summary>
        public ImportType ImportType { get; set; }

        /// <summary>
        /// Is Title record?
        /// </summary>
        public bool IsTitleRecord { get; set; }

        /// <summary>
        /// Import Types - All : Insert/Update - Update - Insert
        /// </summary>
        public IEnumerable<CustomSelectList> ImportTypes { get; set; }

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

        /// <summary>
        /// Initialize Import Types with default options
        /// </summary>
        /// <returns></returns>
        private IEnumerable<CustomSelectList>  GetImportTypes()
        {
            var allImportTypes = EnumUtility.GetItemsList<ImportType>();
            var listWithoutReplace = from item in allImportTypes where item.Value != ((int)ImportType.Replace).ToString() && item.Value != ((int)ImportType.InsertReplace).ToString() select item;
            return listWithoutReplace;
        }
    }
}