/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.GLTransaction.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.GLTransaction;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Models.GLTransaction;
using System.Web.Routing;


#endregion


namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Controllers.GLTransaction
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRef"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <typeparam name="TControllerInternal"></typeparam>
    /// <typeparam name="TRefService"></typeparam>
    public class BaseGLTransactionController<TRef, TViewModel, TControllerInternal, TRefService> : MultitenantControllerBase<TViewModel>
        where TRef : BaseGLTransaction, new()
        where TViewModel : BaseGLTransactionViewModel<TRef>, new()
        where TControllerInternal : BaseGLTransactionControllerInternal<TRef, TViewModel, TRefService>
        where TRefService : IBaseGLTransactionService<TRef>, ISecurityService
    {

        /// <summary>
        /// The _factory to create controller internal
        /// </summary>
        private readonly System.Func<Context, TControllerInternal> _factoryToCreateControllerInternal;
     
        #region Constructor
        /// <summary>
        /// Gets or sets the controller internal.
        /// </summary>
        /// <value>The controller internal.</value>
        public TControllerInternal ControllerInternal { get; set; }


        /// <summary>
        /// GL Integration Controller constructor
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="factoryToCreateControllerInternal">The factory to create controller internal.</param>
        /// <param name="screenName">screenName</param>
        public BaseGLTransactionController(IUnityContainer container,
            System.Func<Context, TControllerInternal> factoryToCreateControllerInternal, ScreenName screenName)
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


    }
}
