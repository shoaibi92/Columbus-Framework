/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Data;
using System.IO;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Core.Interfaces.ExportImport;

namespace Sage.CA.SBS.ERP.Sage300.Core.ExportImport
{
    /// <summary>
    /// NPOI implementation of export/import
    /// </summary>
    public class NpoiExportImport : IExportImport
    {
        /// <summary>
        /// Export - returns byte array
        /// </summary>
        /// <param name="dataSet">data set</param>
        /// <returns>byte array</returns>
        public byte[] Export(DataSet dataSet)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transform byte array (which is in a excel format) into dataset
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns>Dataset</returns>
        public DataSet Import(Stream bytes)
        {
            throw new NotImplementedException();
        }
    }
}
