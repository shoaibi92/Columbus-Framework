/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Services.Base;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Services.Reports
{
    /// <summary>
    /// Report service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericReportService<T> : BaseService, IGenericReportService<T> where T : GenericReport, new()
    {
        #region Constructor

        /// <summary>
        /// To set Context
        /// </summary>
        /// <param name="context">Context</param>
        public GenericReportService(Context context) : base(context)
        {
        }

        #endregion

        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="id">Report Id</param>
        /// <returns>Report</returns>
        public T Get(Guid id)
        {
            using (var reportRepository = Resolve<IGenericReportRepository<T>>())
            {
                return reportRepository.Get(id);
            }
        }

        /// <summary>
        /// This method is not implemented
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save Report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Guid</returns>
        public Guid Execute(T report)
        {
            using (var reportRepository = Resolve<IGenericReportRepository<T>>())
            {
                return reportRepository.Execute(report);
            }
        }

        /// <summary>
        /// Save User Preferences
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveUserPreference(T model)
        {
            using (var reportRepository = Resolve<IGenericReportRepository<T>>())
            {
                return reportRepository.SaveUserPreference(model);
            }
        }

        /// <summary>
        /// Delets the user preference
        /// </summary>
        /// <returns></returns>
        public bool DeleteUserPreference()
        {
            using (var reportRepository = Resolve<IGenericReportRepository<T>>())
            {
                return reportRepository.DeleteUserPreference();
            }
        }

        /// <summary>
        /// TODO: TO be implemented
        /// </summary>
        /// <returns></returns>
        public UserAccess GetAccessRights()
        {
           return null;
        }

    }
}