/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports
{
    /// <summary>
    /// Interface IReportService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReportService<T> where T : ReportBase, new()
    {
        /// <summary>
        /// Get Model for Report
        /// </summary>
        /// <returns>TModel</returns>
        T Get();

        /// <summary>
        /// Execute report
        /// </summary>
        /// <param name="model">TModel</param>
        /// <returns>tReport</returns>
        Guid Execute(T model);

        /// <summary>
        /// Saves the User Preference
        /// </summary>
        /// <param name="model">Model to be saved</param>
        /// <returns>True, if successful</returns>
        bool SaveUserPreference(T model);

        /// <summary>
        /// Deletes the User Preference to database
        /// </summary>
        /// <returns>True if save is successful, else False</returns>
        bool DeleteUserPreference();

    }
}