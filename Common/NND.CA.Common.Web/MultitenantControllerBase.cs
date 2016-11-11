using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;
using NND.CA.Common.Model;

namespace NND.CA.Common.Web
{
    public class MultitenantControllerBase<TViewModel> : BaseController<TViewModel> where TViewModel : new()
    {
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
        /// <param name="screenNameString">Screen Name</param>
        protected MultitenantControllerBase(IUnityContainer container, string screenNameString)
        {
            Container = container;
            ScreenFormName = screenNameString;
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

        public static JsonNetResult JsonNet<T>(T viewmodel)
        {
            var testObject = new JsonNetResult();
            return testObject;
        }
    }
}
