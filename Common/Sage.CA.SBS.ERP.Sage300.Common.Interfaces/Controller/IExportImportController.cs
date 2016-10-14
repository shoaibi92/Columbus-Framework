/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Web.Mvc;

using Sage.CA.SBS.ERP.Sage300.Common.Models.ExportImport;
using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Controller
{
    /// <summary>
    /// Export Import interface for controller internal
    /// </summary>
    public interface IExportImportController
    {
        /// <summary>
        /// Get All the Export/Import Options
        /// </summary>
        /// <param name="isExport">true for export</param>
        /// <returns>Export/Import Options</returns>
        IEnumerable<CustomSelectList> Options(bool isExport = false);

        /// <summary>
        /// Get all the details of all the items for the selected options, which has to be exported
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Request data with item details filled</returns>
        ExportRequest ExportItems(ExportRequest request);

        /// <summary>
        /// Export - add to queue
        /// </summary>
        /// <param name="request">request data</param>
        /// <returns>response data</returns>
        ExportResponse Export(ExportRequest request);

        /// <summary>
        /// Get default value for request object
        /// </summary>
        /// <param name="name">screen/module name being exported</param>
        /// <param name="importOption">selected option</param>
        /// <returns></returns>
        ImportRequest GetDefaultImportRequest(string name, string importOption);

        /// <summary>
        /// Import - add to queue
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ImportResponse Import(ImportRequest request);

        /// <summary>
        /// Get Status - Export
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Status Model</returns>
        ExportResponse ExportStatus(ExportResponse request);

        /// <summary>
        /// Get Status - Import
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Status Model</returns>
        ImportResponse ImportStatus(ImportResponse request);
    }
}