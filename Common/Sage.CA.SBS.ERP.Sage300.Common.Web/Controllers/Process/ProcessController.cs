/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Process;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Process;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.Process
{
    /// <summary>
    /// Class ProcessController.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TViewModel">The type of the t view model.</typeparam>
    /// <typeparam name="TControllerInternal">The type of the t controller internal.</typeparam>
    /// <typeparam name="TService">The type of the t service.</typeparam>
    public class ProcessController<T, TViewModel, TControllerInternal, TService> : MultitenantControllerBase<TViewModel>
        where T : ModelBase, new()
        where TViewModel : ProcessViewModel<T>, new()
        where TControllerInternal : ProcessControllerInternal<T, TViewModel, TService>
        where TService : IProcessService<T>, ISecurityService
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
        /// Account Group controller constructor
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="factoryToCreateControllerInternal">The factory to create controller internal.</param>
        /// <param name="screenName">screenName</param>
        public ProcessController(IUnityContainer container,
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

        #region process related controller methods

        /// <summary>
        /// Returns empty model
        /// </summary>
        /// <returns>ActionResult.</returns>
        public virtual ActionResult Index()
        {
            try
            {
                var userAccess = ControllerInternal.GetAccessRights();
                if (!userAccess.SecurityType.HasFlag(SecurityType.Inquire))
                {
                    return View(AreaConstants.Core.Error, null);
                }
                var model = ControllerInternal.Get();
                return View(model);
            }
            catch (BusinessException businessException)
            {
                return View(AreaConstants.Core.Error, businessException.Errors);
            }
            catch
            {
                return View(AreaConstants.Core.Error, null);
            }
        }

        /// <summary>
        /// Get thes model
        /// </summary>
        /// <returns>JsonNetResult.</returns>
        public virtual JsonNetResult Get()
        {
            try
            {
                return JsonNet(ControllerInternal.Get());
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Process Action
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>JsonNetResult.</returns>
        [HttpPost]

        public JsonNetResult Process(TViewModel model)
        {
            try
            {
                return JsonNet(ControllerInternal.Process(model.Data));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Polling - Get Status
        /// </summary>
        /// <param name="tokenId">work flow instance</param>
        /// <returns>mpdel with progress meter</returns>
        [HttpPost]

        public async Task<JsonNetResult> Progress(int tokenId)
        {
            try
            {
                return JsonNet(await ControllerInternal.ProgressAsync(tokenId));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Cancel the process
        /// </summary>
        /// <param name="tokenId">work flow instance</param>
        /// <returns>Cancel status</returns>
        [HttpPost]

        public async Task<JsonNetResult> Cancel(int tokenId)
        {
            try
            {
                var result = await ControllerInternal.CancelAsync(tokenId);
                return JsonNet(result);
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        #endregion
    }
}