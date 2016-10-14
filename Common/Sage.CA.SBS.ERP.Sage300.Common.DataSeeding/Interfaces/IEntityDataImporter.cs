/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using System.Data;
using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;

namespace Sage.CA.SBS.ERP.Sage300.Common.DataSeeding.Interfaces
{
    /// <summary>
    /// Interface definition for entity data import API 
    /// </summary>
    public interface IEntityDataImporter
    {
        /// <summary>
        /// Imports seed data
        /// </summary>
        /// <param name="data">DataSet</param>
        /// <returns>ImportResponse</returns>
        ImportResponse Import(DataSet data);
    }
}
