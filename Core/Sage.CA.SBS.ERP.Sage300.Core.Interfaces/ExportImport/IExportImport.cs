/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Data;
using System.IO;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport
{
    /// <summary>
    /// Interface IExportImport
    /// </summary>
    public interface IExportImport
    {
        /// <summary>
        /// Export method, to return byte array
        /// </summary>
        /// <param name="dataSet">DataSet, with all the tables</param>
        /// <returns>ExportImportResponse, with message and file path</returns>
        byte[] Export(DataSet dataSet);
        
        /// <summary>
        /// Imports the specified file path.
        /// </summary>
        /// <param name="bytes">The file as byte array.</param>
        /// <returns>DataSet.</returns>
        DataSet Import(Stream bytes);
    }
}