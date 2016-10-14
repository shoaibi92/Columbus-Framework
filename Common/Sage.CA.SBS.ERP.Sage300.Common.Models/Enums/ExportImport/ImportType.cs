/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Resources;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.ExportImport
{
    /// <summary>
    /// Enum for Type : Insert/Update - Update - Insert
    /// </summary>
    public enum ImportType
    {
        /// <summary>
        /// Insert
        /// </summary>
        [EnumValue("Insert", typeof (EnumerationsResx))] Insert = 0,

        /// <summary>
        /// Update
        /// </summary>
        [EnumValue("Update", typeof (EnumerationsResx))] Update = 1,

        /// <summary>
        /// Insert/Update
        /// </summary>
        [EnumValue("InsertUpdate", typeof (EnumerationsResx))] InsertUpdate = 2,

        /// <summary>
        /// Replace
        /// </summary>
        [EnumValue("Replace", typeof(EnumerationsResx))] Replace = 3,

        /// <summary>
        /// Insert/Replace
        /// </summary>
        [EnumValue("InsertReplace", typeof(EnumerationsResx))] InsertReplace = 4
    }
}