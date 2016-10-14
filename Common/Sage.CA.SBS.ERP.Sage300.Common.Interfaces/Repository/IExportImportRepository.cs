/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using System;
using System.Data;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// Export Import Related method (repository)
    /// </summary>
    public interface IExportImportRepository : IRepository, IDisposable
    {
        /// <summary>
        /// Extract data for the model and export
        /// </summary>
        /// <param name="request">Export Request details</param>
        /// <returns>byte array</returns>
        DataSet Export(ExportRequest request);

        /// <summary>
        /// Import
        /// </summary>
        /// <param name="dataSet">Data Set (all the tables)</param>
        /// <param name="request">Import Request</param>
        /// <returns>Import Response</returns>
        ImportResponse Import(DataSet dataSet, ImportRequest request);
    }
}
