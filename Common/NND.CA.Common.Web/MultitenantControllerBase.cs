using System.Web;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using NND.CA.Common.Model;

namespace NND.CA.Common.Web
{
    public class MultitenantControllerBase<TViewModel> : BaseController<TViewModel> where TViewModel : new()
    {
        #region Private Members

        /// <summary>
        ///     local member Microsoft IUnityContainer
        /// </summary>
        public IUnityContainer UnityContainerMultiTenantClass;

        #endregion

        #region InitializerClass

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            HttpSession = Session;
            baseModelContext = new BaseModelContext
            {
                ApplicationType = ApplicationType.WebApplication,
                WebSitePath = System.Web.HttpContext.Current.Server.MapPath("~")
            };
            requestContext.HttpContext.Items["BaseModelContext"] = baseModelContext;
            // Set the Context from session.
            //SetContext();
            //SetScreenControls(ScreenFormName);
            //SetUserLanguage();
            //Used in HTML Helpers
            requestContext.HttpContext.Items["ScreenName"] = ScreenFormName;
        }

        #endregion

        #region Constructors

        ///// <summary>
        /////     Initializing Multi tenant ControllerBase
        ///// </summary>
        //protected MultitenantControllerBase()
        //    : this(null, ScreenName.None)
        //{
        //    HttpSession = Session;
        //    HTTPContext = HttpContext;
        //}

        ///// <summary>
        /////     Setting IUnity Container
        ///// </summary>
        ///// <param name="container">IUnity Container</param>
        //protected MultitenantControllerBase(IUnityContainer container)
        //    : this(container, ScreenName.None)
        //{
        //}
        /// <summary>
        ///     Context
        /// </summary>
        /// <value>The context.</value>
        protected BaseModelContext BaseModelContextPropery { get; set; }

        /// <summary>
        ///     Main Constructor setting MS Unitt
        /// </summary>
        /// <param name="container">IUnityContainer Container</param>
        /// <param name="screenNameString">Screen Name</param>
        protected MultitenantControllerBase(IUnityContainer container, string screenNameString)
        {
            UnityContainerMultiTenantClass = container;
            ScreenFormName = screenNameString;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Context
        /// </summary>
        /// <value>The context.</value>
        protected BaseModelContext baseModelContext { get; set; }

        /// <summary>
        ///     ScreenName
        /// </summary>
        /// <value>The name of the screen.</value>
        protected string ScreenFormName { get; }

        /// <summary>
        ///     View Model
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
        ///     User Session is set to HTTP Session, also used for mocking
        /// </summary>
        protected HttpSessionStateBase HttpSession;

        /// <summary>
        ///     The HTTP context
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected HttpContextBase HTTPContext;

        /// <summary>
        ///     The _view model
        /// </summary>
        private TViewModel _viewModel = new TViewModel();

        #endregion
    }
}