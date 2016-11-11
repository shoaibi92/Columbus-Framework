/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLIntegration.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLIntegration;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLIntegration;
using System.Web.Mvc;
using System.Web.Routing;

#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.GLIntegration
{
    /// <summary>
    /// Class for Base G/L Integration Controller methods
    /// </summary>
    /// <typeparam name="TRef">G/L Reference Integration</typeparam>
    /// <typeparam name="TViewModel">G/L Integration ViewModel(TRef)</typeparam>
    /// <typeparam name="TControllerInternal">G/L Integration Controller Internal(TRef, TViewModel, TRefService)</typeparam>
    /// <typeparam name="TRefService">Base G/L Reference Integration Service Interface</typeparam>
    public class BaseGLIntegrationController<TRef, TViewModel, TControllerInternal, TRefService> : MultitenantControllerBase<TViewModel>
        where TRef : BaseGLReferenceIntegration, new()
        where TViewModel : BaseGLIntegrationViewModel<TRef>, new()
        where TControllerInternal : BaseGLIntegrationControllerInternal<TRef, TViewModel, TRefService>
        where TRefService : IBaseGLReferenceIntegrationService<TRef>, ISecurityService
    {
        #region Private variables

        /// <summary>
        /// The _factory to create controller internal
        /// </summary>
        private readonly System.Func<Context, TControllerInternal> _factoryToCreateControllerInternal;

        #endregion

        #region Public variables

        /// <summary>
        /// Gets or sets the controller internal.
        /// </summary>
        /// <value>The controller internal.</value>
        public TControllerInternal ControllerInternal { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// GL Integration Controller constructor
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="factoryToCreateControllerInternal">The factory to create controller internal.</param>
        /// <param name="screenName">screenName</param>
        public BaseGLIntegrationController(IUnityContainer container,
            System.Func<Context, TControllerInternal> factoryToCreateControllerInternal, string screenName)
            : base(container, screenName)
        {
            _factoryToCreateControllerInternal = factoryToCreateControllerInternal;
        }

        #endregion

        #region Initialize MultitenantControllerBase

        /// <summary>
        /// Initialize Multitenant Controller Base
        /// </summary>
        /// <param name="requestContext">Request Context</param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ControllerInternal = _factoryToCreateControllerInternal(Context);
        }

        #endregion

        #region Overiable Public methods

        /// <summary>
        /// Get G/L Source Codes
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>JsonNetResult.</returns>
        [HttpPost]
        public virtual JsonNetResult GetGLSourceCodes(TViewModel model, int pageNumber, int pageSize)
        {
            try
            {
                return JsonNet(ControllerInternal.GetGLSourceCodes(model, pageNumber, pageSize));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Get G/L Posting Sequences
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>JsonNetResult.</returns>
        [HttpPost]
        public virtual JsonNetResult GetGLPostingSequences(TViewModel model, int pageNumber, int pageSize)
        {
            try
            {
                return JsonNet(ControllerInternal.GetGLPostingSequences(model, pageNumber, pageSize));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Get G/L References
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>JsonNetResult.</returns>
        [HttpPost]
        public virtual JsonNetResult GetReferences(TViewModel model, int pageNumber, int pageSize)
        {
            try
            {
                return JsonNet(ControllerInternal.GetReferences(model, pageNumber, pageSize));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }

        /// <summary>
        /// Get G/L Reference Integration List
        /// </summary>
        /// <param name="model">G/L Integration view model</param>
        /// <returns>JsonNetResult</returns>
        [HttpPost]
        public virtual JsonNetResult GetReferenceList(TViewModel model)
        {
            try
            {
                return JsonNet(ControllerInternal.GetReferences(model));
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(EnumUtility.GetStringValue(Priority.Error), businessException));
            }
        }


        /// <summary>
        /// Update G/L Reference Integration
        /// </summary>
        /// <param name="model">G/L Reference Integration</param>
        /// <returns>JsonNetResult</returns>
        [HttpPost]
        public virtual JsonNetResult UpdateReferenceIntegration(TRef model)
        {
            try
            {
                return JsonNet(ControllerInternal.UpdateReferenceIntegration(model));
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.SaveFailedMessage, businessException));
            }
        }
        #endregion

    }
}
