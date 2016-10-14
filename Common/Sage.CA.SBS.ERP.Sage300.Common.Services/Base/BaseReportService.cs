/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Base
{
    /// <summary>
    /// Class BaseReportService.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public abstract class BaseReportService<T, TEntity> : BaseService, IReportService<T>
        where T : ReportBase, new()
        where TEntity : IReportRepository<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context.</param>
        protected BaseReportService(Context context) : base(context)
        {
        }

        /// <summary>
        /// TODO: Not to be used for reports
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UserAccess GetAccessRights()
        {
            return null;
        }

        /// <summary>
        /// Get data for report
        /// </summary>
        /// <returns>T.</returns>
        public virtual T Get()
        {
            using (var reportRepository = Resolve<TEntity>())
            {
                return reportRepository.Get();
            }
        }

        /// <summary>
        /// Execute Report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Guid</returns>
        public virtual Guid Execute(T report)
        {
            using (var reportRepository = Resolve<TEntity>())
            {
                return reportRepository.Execute(report);
            }
        }

        /// <summary>
        /// Saves the User Preference
        /// </summary>
        /// <param name="model">Model to be saved</param>
        /// <returns>True, if successful</returns>
        public bool SaveUserPreference(T model)
        {
            using (var reportRepository = Resolve<TEntity>())
            {
                return reportRepository.SaveUserPreference(model);
            }
        }

        /// <summary>
        /// Deletes the user preference for the current report
        /// </summary>
        /// <returns></returns>
        public bool DeleteUserPreference()
        {
            using (var reportRepository = Resolve<TEntity>())
            {
                return reportRepository.DeleteUserPreference();
            }
        }
    }
}