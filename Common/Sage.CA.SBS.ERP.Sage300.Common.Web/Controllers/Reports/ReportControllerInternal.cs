// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using CSModel = Sage.CA.SBS.ERP.Sage300.CS.Models;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Reports
{
    /// <summary>
    /// Report Controller Internal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <typeparam name="TService"></typeparam>
    public class ReportControllerInternal<T, TViewModel, TService> : InternalControllerBase<TService>
        where T : ReportBase, new()
        where TViewModel : ReportViewModel<T>, new()
        where TService : IReportService<T>, ISecurityService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ReportControllerInternal(Context context)
            : base(context)
        {
        }

        /// <summary>
        /// Get Report
        /// </summary>
        /// <returns>ReportViewModel</returns>
        public virtual TViewModel Get()
        {
            return new TViewModel
            {
                Data = Service.Get()
            };
        }

        /// <summary>
        /// Execute  Report details
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Updated posting Journal report view model</returns>
        public virtual TViewModel Execute(T report)
        {
            return new TViewModel
            {
                ReportToken = Service.Execute(report),
                UserMessage = new UserMessage { IsSuccess = true }
            };

        }

        /// <summary>
        /// Save the default preferences of the user
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>True, if successful</returns>
        public virtual TViewModel SaveUserPreferences(T model)
        {
            bool isSuccess = Service.SaveUserPreference(model);
            return new TViewModel
            {
                UserMessage = new UserMessage { IsSuccess = isSuccess, Message = isSuccess ? CommonResx.SavePreferenceMessage : CommonResx.SavePreferenceFailedMessage }
            };
        }

        /// <summary>
        /// Deletes the default preferences of the user
        /// </summary>
        /// <returns>True, if successful</returns>
        public virtual TViewModel DeleteUserPreferences()
        {
            var isDeleted = Service.DeleteUserPreference();
            if (isDeleted)
            {
                var viewModel = new TViewModel
                {
                    UserMessage = new UserMessage { IsSuccess = true, Message = CommonResx.ClearPreferenceSaveMessage },
                    Data = Get().Data
                };

                return viewModel;
            }
            else
            {
                var errorList = new List<EntityError>();
                var entityError = new EntityError
                {
                    Message = CommonResx.ClearPreferenceFailedMessage,
                    Priority = Priority.Error
                };
                errorList.Add(entityError);
                var viewModel = new TViewModel
                {
                    UserMessage = new UserMessage { IsSuccess = false, Errors = errorList }
                };
                return viewModel;
            }

        }

        #region Fiscal Calendar Validations



        /// <summary>
        /// Checks if the fiscal year exists in the fiscal calendar
        /// </summary>
        /// <param name="fiscalYear">fiscal Year</param>
        /// <returns>TViewModel</returns>
        public virtual TViewModel FiscalYearExists(string fiscalYear)
        {
            var fiscalCalendarService =
                Context.Container.Resolve<IFiscalCalendarService<CSModel.FiscalCalendar>>(new ParameterOverride("context", Context));
            var isSuccess = fiscalCalendarService.IsValid(fiscalYear);
            var viewModel = new TViewModel
            {
                UserMessage = new UserMessage { IsSuccess = isSuccess },
            };
            if (!isSuccess)
            {
                viewModel.UserMessage.Message = string.Format(CommonResx.InvalidFiscalYear, fiscalYear);
            }
            return viewModel;
        }

        /// <summary>
        /// Checks if the fiscal period for the fiscal year exists in the fiscal calendar
        /// </summary>
        /// <param name="fiscalYear">fiscal Year</param>
        /// <param name="fiscalPeriod">fiscal Period</param>
        /// <param name="isGL">is the Application GL?</param>
        /// <returns>TViewModel</returns>
        public virtual TViewModel FiscalPeriodExists(string fiscalYear, string fiscalPeriod, bool isGL)
        {
            var fiscalCalendarService =
                Context.Container.Resolve<IFiscalCalendarService<CSModel.FiscalCalendar>>(new ParameterOverride("context", Context));
            var isSuccess = fiscalCalendarService.FiscalPeriodExists(fiscalYear, fiscalPeriod, isGL);
            var viewModel = new TViewModel
            {
                UserMessage = new UserMessage { IsSuccess = isSuccess },
            };
            if (!isSuccess)
            {
                viewModel.UserMessage.Message = string.Format(CommonResx.InvalidFiscalPeriod, fiscalPeriod, fiscalYear);
            }
            return viewModel;
        }

        #endregion

    }
}
