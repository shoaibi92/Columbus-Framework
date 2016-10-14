/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using System;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports
{
    /// <summary>
    /// Interface IReportRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReportRepository<T> : IRepository, IDisposable where T : ReportBase
    {
        /// <summary>
        /// Get Model for Report
        /// </summary>
        /// <param name="applyUserPreferences">should apply user preferences?</param>
        /// <returns>TModel</returns>
        T Get(bool applyUserPreferences = true);

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