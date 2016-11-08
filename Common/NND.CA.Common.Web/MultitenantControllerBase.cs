// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Utilities;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Class for MultitenantControllerBase methods
    /// </summary>
    /// <typeparam name="TViewModel">The type of the t view model.</typeparam>
    public class MultitenantControllerBase<TViewModel> : BaseController where TViewModel : new()
    {
        const string ScreenCustomizeKey = "aabe0981-a6a7-41af-adbe-fe480422325b";

        #region Properties

        /// <summary>
        /// Context
        /// </summary>
        /// <value>The context.</value>
        protected Context Context { get; set; }

        /// <summary>
        /// ScreenName
        /// </summary>
        /// <value>The name of the screen.</value>
        protected string ScreenFormName { get; private set; }

        /// <summary>
        /// View Model
        /// </summary>
        /// <value>The view model.</value>
        protected TViewModel ViewModel
        {
            get { return _viewModel; }

            set { _viewModel = value; }
        }

        #endregion

        #region Global Variables

        /// <summary>
        /// User Session is set to HTTP Session, also used for mocking
        /// </summary>
        protected HttpSessionStateBase HttpSession;

        /// <summary>
        /// The HTTP context
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected HttpContextBase HTTPContext;

        /// <summary>
        /// The _view model
        /// </summary>
        private TViewModel _viewModel = new TViewModel();

        /// <summary>
        /// The container
        /// </summary>
        public IUnityContainer Container;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializing Multi tenant ControllerBase
        /// </summary>
        protected MultitenantControllerBase()
            : this(null, ScreenName.None)
        {
            HttpSession = Session;
            HTTPContext = HttpContext;
        }

        /// <summary>
        /// Setting IUnity Container
        /// </summary>
        /// <param name="container">IUnity Container</param>
        protected MultitenantControllerBase(IUnityContainer container)
            : this(container, ScreenName.None)
        {
        }

        /// <summary>
        /// Setting IUnity Container
        /// </summary>
        /// <param name="container">IUnity Container</param>
        /// <param name="screenName">Screen Name</param>
        protected MultitenantControllerBase(IUnityContainer container, string screenName)
        {
            Container = container;
            ScreenFormName = screenName;
        }

        /// <summary>
        /// Setting HTTPContext and  HTTPSession
        /// </summary>
        /// <param name="session">HTTP Session</param>
        /// <param name="context">HTTP Context</param>
        public MultitenantControllerBase(HttpSessionStateBase session, HttpContextBase context)
            : this(null, ScreenName.None)
        {
            HTTPContext = context;
            HttpSession = session;
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Run the action asynchronously
        /// </summary>
        /// <param name="action"></param>
        protected void RunAsync(Action action)
        {
            Task.Run(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    Logger.Error("RunAsync failed", LoggingConstants.ApplicationError, Context, ex);
                }
            });
        }

        /// <summary>
        /// User Identity
        /// </summary>
        /// <value>The identity.</value>
        protected virtual CustomIdentity Identity
        {
            get { return HttpContext.User.Identity as CustomIdentity; }
        }

        /// <summary>
        /// To Initialize Request Context
        /// </summary>
        /// <param name="requestContext">Request Context</param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            HttpSession = Session;
            Context = new Context { ApplicationType = ApplicationType.WebApplication, WebSitePath = System.Web.HttpContext.Current.Server.MapPath("~") };
            requestContext.HttpContext.Items["Context"] = Context;
            // Set the Context from session.
            SetContext();
            SetScreenControls(ScreenFormName);
            SetUserLanguage();
            //Used in HTML Helpers
            requestContext.HttpContext.Items["ScreenName"] = ScreenFormName;
        }

        /// <summary>
        /// Executes an action on change of context
        /// </summary>
        /// <param name="filterContext">Action Executing Context</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            if (request.Form["ContextToken"] != null)
            {
                Context.ContextToken = Guid.Parse(request.Form["ContextToken"]);
            }
            else
            {
                var queryStringToken = request.QueryString["ContextToken"];
                if (!string.IsNullOrEmpty(queryStringToken))
                {
                    Context.ContextToken = Guid.Parse(queryStringToken);
                }
            }
            if (request.Form["ScreenName"] != null)
            {
                Context.ScreenContext.ScreenName = request.Form["ScreenName"];
            }
            if (request.ContentType.ToLower().Contains("application/json"))
            {
                string contextToken = null;
                string screenName = null;

                if (filterContext.HttpContext.Request.Headers != null)
                {
                    // Read the Context Token and Screen Name from Request Headers
                    contextToken = filterContext.HttpContext.Request.Headers["ContextToken"];
                    screenName = filterContext.HttpContext.Request.Headers["ScreenName"];

                    if (!string.IsNullOrEmpty(contextToken))
                    {
                        Context.ContextToken = Guid.Parse(contextToken);
                    }
                    if (!string.IsNullOrEmpty(screenName))
                    {
                        Context.ScreenContext.ScreenName = screenName;
                    }
                }

                if (string.IsNullOrEmpty(contextToken) || string.IsNullOrEmpty(screenName))
                {
                    filterContext.HttpContext.Request.InputStream.Position = 0;

                    string json;
                    if (request.RequestType == "GET")
                    {
                        json = HttpUtility.UrlDecode(request.QueryString.ToString());
                    }
                    else
                    {
                        using (var reader = new StreamReader(filterContext.HttpContext.Request.InputStream))
                        {
                            json = reader.ReadToEnd();
                        }
                    }

                    var dataContext = Utilities.Utilities.DeserializeJson<Context>(json);
                    if (dataContext != null)
                    {
                        if (dataContext.ContextToken != Guid.Empty)
                        {
                            Context.ContextToken = dataContext.ContextToken;
                        }
                        if (dataContext.ScreenName != null)
                        {
                            Context.ScreenContext.ScreenName = dataContext.ScreenName;
                        }
                    }
                }
            }
            else
            {
                if (request.Form["ContextToken"] != null)
                {
                    Context.ContextToken = Guid.Parse(request.Form["ContextToken"]);
                }
                else
                {
                    var queryStringToken = request.QueryString["ContextToken"];
                    if (!string.IsNullOrEmpty(queryStringToken))
                    {
                        Context.ContextToken = Guid.Parse(queryStringToken);
                    }
                }
                if (request.Form["ScreenName"] != null)
                {
                    Context.ScreenContext.ScreenName = request.Form["ScreenName"];
                }
            }
            if (Context.ContextToken == Guid.Empty)
            {
                Context.ContextToken = Guid.NewGuid();
            }

        }

        /// <summary>
        /// Authorization based on Authorization Context
        /// </summary>
        /// <param name="filterContext">Authorization Context</param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Context.ProductUserId != Guid.Empty)
            {
                // Check if the route data for tenant and company has been changed and is different from that of session
                // If different redirect to error page
                var tenantAlias = Convert.ToString(filterContext.RouteData.Values["tenantAlias"]);
                var controllerName = Convert.ToString(filterContext.RouteData.Values["controller"]);

                bool validTenant = true;

                if (ConfigurationHelper.IsOnPremise)
                {
                    // Check if the route data for tenant and company has been changed and is different for on premise
                    // If different redirect to error page
                    if (tenantAlias != AreaConstants.Core.OnPremiseTenantAlias)
                    {
                        validTenant = false;
                    }
                }
                else
                {
                    // Check if the route data for tenant and company has been changed and is different from that of session
                    // If different redirect to error page
                    if (controllerName != "Authenticate" && controllerName != "Tenant")
                    {
                        if (Context.TenantAlias != tenantAlias)
                        {
                            validTenant = false;
                        }
                    }
                }

                //If tenant is invalid.
                if (!validTenant)
                {
                    Logger.Info(string.Format("Tenant Alias ({0}) not matches the user tenant. ", tenantAlias), LoggingConstants.ModuleController);

                    filterContext.Result =
                        new RedirectToRouteResult(new RouteValueDictionary
                                {
                                    {"area", "Core"},
                                    {"controller", "Error"},
                                    {"action", "Index"}
                                });
                }

                if (!ConfigurationHelper.IsOnPremise)
                {
                    filterContext.HttpContext.User =
                      new CustomPrincipal(new CustomIdentity(Context.ProductUserId.ToString(), string.Empty, true, true));
                }

            }

            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// JsonNet Result
        /// </summary>
        /// <typeparam name="T">Base type</typeparam>
        /// <param name="viewmodel">View Model</param>
        /// <returns>JsonNetResult.</returns>
        protected JsonNetResult JsonNet<T>(T viewmodel)
        {
            return Utilities.Utilities.JsonNet(viewmodel);
        }

        /// <summary>
        /// Build model for user error or warning message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="businessException">Business Exception</param>
        /// <param name="args">Optional Arguments</param>
        /// <returns>View Model</returns>
        protected ViewModelBase<ModelBase> BuildErrorOrWarningModelBase(string message, BusinessException businessException,
            params object[] args)
        {
            ReformatErrorMessageDates(businessException);
            var viewModelBase = new ViewModelBase<ModelBase>
                {
                    UserMessage =
                        new UserMessage
                        {
                            IsSuccess = false,
                            Message = string.Format(message, args)
                        }
                };

            var isWarning = businessException.Errors != null && businessException.Errors.All(x => x.Priority == Priority.Warning);

            if (isWarning)
            {
                viewModelBase.UserMessage.Warnings = businessException.Errors;
            }
            else
            {
                viewModelBase.UserMessage.Errors = businessException.Errors;
            }

            return viewModelBase;
        }

        /// <summary>
        /// Build model for user error message
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="businessException">Business Exception</param>
        /// <param name="args">Optional Arguments</param>
        /// <returns>View Model</returns>
        protected ViewModelBase<ModelBase> BuildErrorModelBase(string message, BusinessException businessException,
            params object[] args)
        {
            ReformatErrorMessageDates(businessException);
            var modelBase = new ViewModelBase<ModelBase>
            {
                UserMessage =
                    new UserMessage
                    {
                        IsSuccess = false,
                        Errors = businessException.Errors,
                        Message = string.Format(message, args)
                    },
            };

            return modelBase;
        }

        /// <summary>
        /// Build model for user error message
        /// </summary>
        /// <param name="businessException">Business Exception</param>
        /// <returns></returns>
        protected ViewModelBase<ModelBase> BuildErrorModelBase(BusinessException businessException)
        {
            ReformatErrorMessageDates(businessException);
            var modelBase = new ViewModelBase<ModelBase>
            {
                UserMessage =
                    new UserMessage
                    {
                        IsSuccess = false,
                        Errors = businessException.Errors
                    },
            };

            return modelBase;
        }

        /// <summary>
        /// Build model for user error message
        /// </summary>
        /// <param name="model"></param>
        /// <param name="message">Message</param>
        /// <param name="businessException">Business Exception</param>
        /// <param name="args">Optional Arguments</param>
        /// <returns>View Model</returns>
        protected ViewModelBase<T> BuildErrorModelBase<T>(T model, string message, BusinessException businessException,
            params object[] args) where T : ModelBase, new()
        {
            ReformatErrorMessageDates(businessException);
            var modelBase = new ViewModelBase<T>
            {
                Data = model,
                UserMessage =
                    new UserMessage
                    {
                        IsSuccess = false,
                        Errors = businessException.Errors,
                        Message = string.Format(message, args)
                    }
            };

            return modelBase;
        }

        /// <summary>
        /// Build model for user error message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="message"></param>
        /// <param name="errors"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected ViewModelBase<T> BuildErrorModelBase<T>(T model, string message, List<EntityError> errors,
            params object[] args) where T : ModelBase, new()
        {
            var modelBase = new ViewModelBase<T>
            {
                Data = model,
                UserMessage =
                    new UserMessage { IsSuccess = false, Errors = errors, Message = string.Format(message, args) }
            };

            return modelBase;
        }

        /// <summary>
        /// Validate model state
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <param name="viewModel">View Model</param>
        /// <returns>Is Model Valid</returns>
        protected bool ValidateModelState(ModelStateDictionary modelState, out ViewModelBase<TViewModel> viewModel)
        {
            viewModel = null;
            return ValidateModel(modelState, ref viewModel);
        }

        /// <summary>
        /// Validate model state
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <param name="viewModel">View Model</param>
        /// <param name="ignoreProperties">Properties to ignore</param>
        /// <returns>Is Model Valid</returns>
        protected bool ValidateModelState(ModelStateDictionary modelState, out ViewModelBase<TViewModel> viewModel, params string[] ignoreProperties)
        {
            viewModel = null;
            foreach (var ignoreProperty in ignoreProperties)
            {
                modelState.Remove(ignoreProperty);
            }
            return ValidateModel(modelState, ref viewModel);
        }



        /// <summary>
        /// Validate model state
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <param name="viewModel">View Model</param>
        /// <returns>Is Model Valid</returns>
        protected bool ValidateModelState(ModelStateDictionary modelState, out ViewModelBase<ModelBase> viewModel)
        {
            viewModel = null;
            return ValidateModel(modelState, ref viewModel);
        }


        /// <summary>
        /// Validate model state
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <param name="viewModel">View Model</param>
        /// <param name="ignoreProperties">Properties to ignore</param>
        /// <returns>Is Model Valid</returns>
        protected bool ValidateModelState(ModelStateDictionary modelState, out ViewModelBase<ModelBase> viewModel, params string[] ignoreProperties)
        {
            viewModel = null;
            foreach (var ignoreProperty in ignoreProperties)
            {
                modelState.Remove(ignoreProperty);
            }
            return ValidateModel(modelState, ref viewModel);
        }

        private static bool ValidateModel(ModelStateDictionary modelState, ref ViewModelBase<ModelBase> viewModel)
        {
            if (modelState.IsValid)
            {
                return true;
            }

            var errors =
                modelState.Values.SelectMany(e => e.Errors)
                    .Select(item => new EntityError { Message = item.ErrorMessage })
                    .ToList();

            viewModel = new ViewModelBase<ModelBase> { UserMessage = new UserMessage { IsSuccess = false, Errors = errors } };

            return false;
        }

        private static bool ValidateModel(ModelStateDictionary modelState, ref ViewModelBase<TViewModel> viewModel)
        {
            if (modelState.IsValid)
            {
                return true;
            }

            var errors =
                modelState.Values.SelectMany(e => e.Errors)
                    .Select(item => new EntityError { Message = item.ErrorMessage })
                    .ToList();

            viewModel = new ViewModelBase<TViewModel> { UserMessage = new UserMessage { IsSuccess = false, Errors = errors } };

            return false;
        }



        /// <summary>
        /// To Verify the session date
        /// </summary>
        /// <returns>SessionDateWarning</returns>
        protected SessionDateWarning VerifySessionDate()
        {

            var userService = Context.Container.Resolve<ICommonService>(new ParameterOverride("context", Context));
            return userService.VerifySessionDate();
        }

        protected List<Control> GetScreenPreferences()
        {
            var commonService = Context.Container.Resolve<ICommonService>(new ParameterOverride("context", Context));
            var key = Context.ScreenContext.ScreenName + "_" + ScreenCustomizeKey;
            var value = commonService.GetUserPreference(key);
            return (string.IsNullOrEmpty(value)) ? null : JsonSerializer.DeserializeCompressed<List<Control>>(value);
        }

        /// <summary>
        /// Get Resource manager based on xml configuration file, for plugin menu system localization
        /// </summary>
        /// <returns></returns>
        protected System.Resources.ResourceManager[] GetResourceManagers()
        {
            const string path = "/bootstrapper/menuresx/add[@assembly and @name ]";
            const string searhPattern = "*bootstrapper.xml";

            var webPath = System.Web.HttpContext.Current.Server.MapPath("~");
            var doc = new XmlDocument();
            var resManagers = new List<System.Resources.ResourceManager>();

            string[] files = Directory.GetFiles(webPath, searhPattern);

            foreach (var bootStrapperFile in files)
            {
                try
                {
                    doc.Load(bootStrapperFile);
                    var node = doc.SelectSingleNode(path);
                    if (node != null)
                    {
                        if (node.Attributes != null && !string.IsNullOrEmpty(node.Attributes["assembly"].Value))
                        {
                            var assemblyName = node.Attributes["assembly"].Value;
                            var menuName = node.Attributes["name"].Value;
                            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(a => a.GetName().Name == assemblyName);
                            if (assembly != null)
                            {
                                var resxType = assembly.GetType(assemblyName + "." + menuName);
                                if (resxType != null && resxType.GetProperty("ResourceManager") != null)
                                {
                                    var resManager = (System.Resources.ResourceManager)resxType.GetProperty("ResourceManager").GetValue(this, null);
                                    resManagers.Add(resManager);
                                }
                            }
                        }
                    }
                }
                catch (Exception) //suppresses any errors, not break application
                {
                    return null;
                }
            }
            return resManagers.ToArray();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set Context
        /// </summary>
        private void SetContext()
        {
            var signOnResult = Utilities.Utilities.GetStoredUserSignOnResult();

            Context.SessionId = HttpSession.SessionID;
            Context.Container = Container;

            // This should be executed only when we have complete Tenant information
            if (signOnResult != null && signOnResult.SelectedTenant != null)
            {
                if (signOnResult.LoggedInUser != null)
                {
                    Context.ProductUserId = signOnResult.LoggedInUser.ProductUserId;

                    //TODO: To check if the user is first time user.
                    //var firstTimeUser = signOnResult.LoginUserInfo.FirstTimeUser;
                }

                Context.TenantId = signOnResult.SelectedTenant.TenantId;
                Context.TenantAlias = signOnResult.SelectedTenant.TenantAlias;
                Context.ApplicationUserId = signOnResult.SelectedTenant.ApplicationUserId;
                Context.Company = signOnResult.SelectedTenant.Company;

                //Set Session Date
                Context.SessionDate = new DateTime(GetSessionDate());
            }

            Context.ScreenContext = new ScreenContext
            {
                ScreenName = ScreenFormName,
                Screen = Customization.Customization.GetInstance().GetScreen(Context, ScreenFormName)
            };
        }

        /// <summary>
        /// Set User Language
        /// </summary>
        private void SetUserLanguage()
        {
            // Get user agent culture
            var culture = GetUserAgentCulture();
            var cultureName = culture.Name;

            SessionUtility.Provider.Set(Shared.UserPreferredLanguage, cultureName);

            // Saving culture in cookie to load user specific language in Tenant selection page
            Utilities.Utilities.SetCookie(HttpContext, Constant.UserCultureCookie, cultureName);

            Context.Language = cultureName;

            if (Context != null)
            {
                CommonUtil.SetCulture(Context.Language);
            }
        }

        /// <summary>
        /// Gets user agent Culture 
        /// </summary>
        /// <returns>Culture name</returns>
        private CultureInfo GetUserAgentCulture()
        {
            const string defaultCulture = "en-US";

            var userCultures = Request.UserLanguages;
            var userCulture = userCultures == null || string.IsNullOrWhiteSpace(userCultures[0])
                ? defaultCulture
                : userCultures[0];

            try
            {
                return new CultureInfo(userCulture);
            }
            catch (CultureNotFoundException)
            {
                return new CultureInfo(defaultCulture);
            }
        }

        /// <summary>
        /// Get Session Date from cookie
        /// </summary>
        /// <returns></returns>
        private long GetSessionDate()
        {
            const string sessionDateFromat = "M'/'d'/'yyyy H:m:s";

            var cookie = HttpContext.Request.Cookies[Constant.SessionCookieName];
            var today = DateUtil.GetNowDate();

            if (cookie == null)
            {
                return today.Ticks;
            }
            var dateTimes = cookie.Value.Split('|');

            if (dateTimes.Length != 2)
            {
                return today.Ticks;
            }

            var sessionDate = DateUtil.GetDate(dateTimes[0], DateUtil.GetNowDate(), sessionDateFromat);
            return sessionDate.Ticks;
        }

        /// <summary>
        /// Set screen controls
        /// </summary>
        /// <param name="screenName">screen name</param>
        private void SetScreenControls(string screenName)
        {
            //Add screen controls for customization
            if (screenName != ScreenName.None && screenName != ScreenName.Home && screenName != ScreenName.Login)
            {
                if (Context.ScreenContext.Screen == null)
                {
                    Context.ScreenContext.Screen = new Screen();
                }
                Context.ScreenContext.Screen.Name = screenName;
                try
                {
                    var controls = GetScreenPreferences();
                    Context.ScreenContext.Screen.Controls = controls;
                }
                catch (Exception)
                {
                    //do nothing, suppresses any errors, not break application
                }
            }
        }
        /// <summary>
        /// Reformats dates found in error messages using Current user culture.
        /// </summary>
        /// <param name="exception"></param>
        private void ReformatErrorMessageDates(BusinessException exception)
        {
            if (exception == null)
                return;

            //Get current app pool user culture. The ACCPAC layer should be using the same, so use it for parsing
            var appPoolUserCulture = Utilities.Utilities.GetUserDefaultCultureInfo();

            //Do not do anything if formats are the same
            if (appPoolUserCulture == null ||
                appPoolUserCulture.DateTimeFormat.ShortDatePattern == DateUtil.DateFormat)
                return;

            var pattern = string.Format(@"(\d+){0}(\s?\d+){0}(\d+)", appPoolUserCulture.DateTimeFormat.DateSeparator);

            foreach (var error in exception.Errors)
            {
                error.Message = Regex.Replace(error.Message, pattern, delegate(Match match)
                {
                    //If match found, try to parse the date using app pool user culture, and format it using current user culture
                    DateTime dt;
                    if (DateTime.TryParseExact(match.Value, appPoolUserCulture.DateTimeFormat.ShortDatePattern, appPoolUserCulture, DateTimeStyles.AllowWhiteSpaces, out dt))
                    {
                        return DateUtil.GetShortDate(dt, string.Empty);
                    }
                    return match.Value;
                });
            }
        }


        #endregion
    }
}