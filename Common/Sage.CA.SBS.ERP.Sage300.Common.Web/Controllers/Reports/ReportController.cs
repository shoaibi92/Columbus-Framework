using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Reports;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Reports;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Reports
{
    /// <summary>
    /// Common Report Controller
    /// </summary>
    /// <typeparam name="T">Report Model</typeparam>
    /// <typeparam name="TViewModel">Report View Model</typeparam>
    /// <typeparam name="TControllerInternal">Report Controller Internal</typeparam>
    /// <typeparam name="TService">Report Service</typeparam>
    public class ReportController<T, TViewModel, TControllerInternal, TService> : MultitenantControllerBase<TViewModel>
        where T : ReportBase, new()
        where TViewModel : ReportViewModel<T>, new()
        where TControllerInternal : ReportControllerInternal<T, TViewModel, TService>
        where TService : IReportService<T>, ISecurityService
    {
        #region Public variables

        /// <summary>
        /// Gets or sets the controller internal.
        /// </summary>
        /// <value>The controller internal.</value>
        public TControllerInternal ControllerInternal { get; set; }

        /// <summary>
        /// The _factory to create controller internal
        /// </summary>
        private readonly System.Func<Context, TControllerInternal> _factoryToCreateControllerInternal;

        #endregion

        #region Constructor

        /// <summary>
        /// Report Controller Constructor for Custom Controller Internal
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="factoryToCreateControllerInternal">The factory to create controller internal.</param>
        /// <param name="screenName">screenName</param>
        public ReportController(IUnityContainer container,
            System.Func<Context, TControllerInternal> factoryToCreateControllerInternal, string screenName)
            : base(container, screenName)
        {
            _factoryToCreateControllerInternal = factoryToCreateControllerInternal;
        }

        #endregion

        #region Initialize MultitenantControllerBase

        /// <summary>
        /// Initialize MultitenantControllerBase
        /// </summary>
        /// <param name="requestContext">Request Context</param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ControllerInternal = _factoryToCreateControllerInternal(Context);
        }

        #endregion

        #region Report methods
        /// <summary>
        /// Returns empty model
        /// </summary>
        /// <returns>ActionResult.</returns>
        public virtual ActionResult Index()
        {
            var model = ControllerInternal.Get();
            return View(model);
        }

        /// <summary>
        /// Execute Report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]

        public virtual JsonNetResult Execute(T report)
        {
            ViewModelBase<TViewModel> viewModel;

            if (!ValidateModelState(ModelState, out viewModel))
            {
                return JsonNet(viewModel);
            }

            try
            {
                var reportViewModel = ControllerInternal.Execute(report);
                return JsonNet(reportViewModel);
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.ReportGenFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Save the default preferences of the user
        /// </summary>
        /// <param name="report">Model</param>
        /// <returns>True, if successful</returns>
        public virtual JsonNetResult SaveUserPreference(T report)
        {
            try
            {
                return JsonNet(ControllerInternal.SaveUserPreferences(report));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.SavePreferenceFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Save the default preferences of the user
        /// </summary>
        /// <returns>True, if successful</returns>
        public virtual JsonNetResult ClearUserPreference()
        {
            try
            {
                return JsonNet(ControllerInternal.DeleteUserPreferences());
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.ClearPreferenceFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Checks if the fiscal year exists in the fiscal calendar
        /// </summary>
        /// <param name="fiscalYear">fiscal Year</param>
        /// <returns>JsonNet</returns>
        public virtual JsonNetResult FiscalYearExists(string fiscalYear)
        {
            try
            {
                return JsonNet(ControllerInternal.FiscalYearExists(fiscalYear));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.ValidateFailedMessage, businessException, fiscalYear));
            }
        }

        /// <summary>
        /// Checks if the fiscal period for the fiscal year exists in the fiscal calendar
        /// </summary>
        /// <param name="fiscalYear">fiscal Year</param>
        /// <param name="fiscalPeriod">fiscal Period</param>
        /// <param name="isGL">is the Application GL?</param>
        /// <returns>JsonNet</returns>
        public virtual JsonNetResult FiscalPeriodExists(string fiscalYear, string fiscalPeriod, bool isGL)
        {
            try
            {
                return JsonNet(ControllerInternal.FiscalPeriodExists(fiscalYear, fiscalPeriod, isGL));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.ValidateFailedMessage, businessException, fiscalPeriod));
            }
        }

        /// <summary>
        /// Upload report template file to server
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public virtual JsonNetResult UploadReportFile()
        {
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            try
            {
                if (curContext.Request.Files.AllKeys.Length > 0)
                {
                    var file = curContext.Request.Files["reportFile"];
                    var fileName = (file != null) ? Path.GetFileName(file.FileName) : null;
                    var dir = GetSage300ReportPath();
                    if (file != null && file.ContentLength > 0 && fileName != null && Directory.Exists(dir))
                    {
                        var path = Path.Combine(dir, fileName);
                        if (!System.IO.File.Exists(path))
                        {
                            file.SaveAs(path);
                        }
                    }
                }
                return null;
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.SaveFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Get the Sage300 ERP report template files path 
        /// </summary>
        /// <returns></returns>
        private string GetSage300ReportPath()
        {
            var configurationKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ACCPAC International, Inc.\\ACCPAC\\Configuration");
            if (configurationKey == null)
            {
                throw new Exception("Cannot open registry key");
            }
            var installDir = configurationKey.GetValue("Programs").ToString();
            var version = BusinessRepository.Utilities.Helper.ApplicationVersion;
            var area = ControllerContext.RouteData.DataTokens["area"];
            var language = GetLanguageString(Context.Language);
            var path = Path.Combine(installDir, area + version, language);
            return path;
        }

        /// <summary>
        /// Convert lanaguage to constant string to match Sage300 ERP installed directory
        /// </summary>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        private string GetLanguageString(string languageCode)
        {
            var str = "ENG";
            var code = languageCode.Substring(0, 2);
            switch (code)
            {
                case "en":
                    str = "ENG";
                    break;
                case "fr":
                    str = "FRA";
                    break;
                case "es":
                    str = "ESN";
                    break;
                case "zh":
                    str = (languageCode == "zh-Hans") ? "CHN" : "CHT";
                    break;
            }
            return str;
        }

        #endregion
    }
}
