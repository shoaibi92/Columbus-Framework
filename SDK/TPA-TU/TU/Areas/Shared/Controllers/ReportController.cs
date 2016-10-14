/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using Sage.CA.SBS.ERP.Sage300.Shared.Web.Models;

namespace Sage.CA.SBS.ERP.Sage300.Shared.Web.Controllers
{
    /// <summary>
    /// ReportController
    /// </summary>
    /// <typeparam name="T">Type of Report</typeparam>
    public class ReportController<T> : MultitenantControllerBase<ReportViewModel<T>> where T : GenericReport, new()
    {
        #region Private Member
        private ReportControllerInternal<T> _controllerInternal;
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">IUnityContainer</param>
        public ReportController(IUnityContainer container)
            : base(container)
        {
        }

        #endregion

        /// <summary>
        /// Initializes the request and constructs controller internal
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _controllerInternal = new ReportControllerInternal<T>(Context);
        }


        /// <summary>
        /// Load Report based on report id
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(Guid id)
        {
            var model = _controllerInternal.Get(id);
            return View(model);
        }

        /// <summary>
        /// Execute Report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Execute(T report)
        {
            ViewModelBase<ReportViewModel<T>> viewModel;

            if (!ValidateModelState(ModelState, out viewModel))
            {
                return JsonNet(viewModel);
            }

            try
            {
                var reportViewModel = _controllerInternal.Execute(report);
                return JsonNet(reportViewModel);
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.ReportGenFailedMessage, businessException));
            }
        }
    }
}
