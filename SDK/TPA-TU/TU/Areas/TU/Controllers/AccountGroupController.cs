/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Exceptions;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TPA.TU.Models;
using TPA.TU.Models.Enums;
using TPA.TU.Resources.Forms;
using TPA.Web.Areas.TU.Models;

#endregion

namespace TPA.Web.Areas.TU.Controllers
{
    /// <summary>
    ///  Controller Class for Account Set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AccountGroupController<T> : MultitenantControllerBase<AccountGroupViewModel<T>>
        where T : AccountGroup, new()
    {
        #region Public Variables

        /// <summary>
        /// The controller internal
        /// </summary>
        public AccountGroupControllerInternal<T> ControllerInternal;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountGroupController{T}"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AccountGroupController(IUnityContainer container)
            : base(container, "TUAccountGroup")
        {
        }

        #endregion

        #region Initialize MultitenantControllerBase

        /// <summary>
        /// Initializes the specified request context.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ControllerInternal = new AccountGroupControllerInternal<T>(Context);
        }

        #endregion

        #region Actions

        /// <summary>
        /// Load Account set screen
        /// </summary>
        /// <returns>Account set View</returns>
        public virtual ActionResult Index(string id)
        {
            AccountGroupViewModel<T> model;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    model = ControllerInternal.Get(id);
                    model.UserAccess = ControllerInternal.GetAccessRights();
                }
                else
                {
                    model = new AccountGroupViewModel<T> { UserAccess = ControllerInternal.GetAccessRights() };
                    model = ControllerInternal.LoadCompanyDetails(model);

                }
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.GetFailedMessage, businessException,
                AccountGroupsResx.AccountGroupCode));
            }

            return View(model);
        }

        /// <summary>
        /// Get Account set
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Json object for Account set</returns>
        [HttpPost]
        public virtual JsonNetResult Get(string id)
        {
            ViewModelBase<AccountGroupViewModel<T>> viewModel;

            if (!ValidateModelState(ModelState, out viewModel))
            {
                return JsonNet(viewModel);
            }
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    return JsonNet(ControllerInternal.Get(id));
                }
                var accountGroupcodes = new AccountGroupViewModel<T>();
                return JsonNet(accountGroupcodes);
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.GetFailedMessage, businessException,
              AccountGroupsResx.AccountGroupCode));
            }
        }

        /// <summary>
        /// Add new Account set
        /// </summary>
        /// <param name="model">Account set Model</param>
        /// <returns>Json object for Account set</returns>
        [HttpPost]
        public virtual JsonNetResult Add(T model)
        {
            try
            {
                ViewModelBase<ModelBase> viewModel;
                return ValidateModelState(ModelState, out viewModel)
                    ? JsonNet(ControllerInternal.Add(model))
                    : JsonNet(viewModel);
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.AddFailedMessage, businessException,
                         AccountGroupsResx.AccountGroupCode));
            }
        }

        /// <summary>
        /// Create Account set
        /// </summary>
        /// <returns>AccountGroupViewModel</returns>
        [HttpPost]
        public virtual JsonNetResult Create()
        {
            return JsonNet(ControllerInternal.Create());
        }


        /// <summary>
        /// Update Account set
        /// </summary>
        /// <param name="model">Account set Model</param>
        /// <returns>Json object for Account set</returns>
        [HttpPost]
        public virtual JsonNetResult Save(T model)
        {
            try
            {
                ViewModelBase<ModelBase> viewModel;
                return ValidateModelState(ModelState, out viewModel)
                    ? JsonNet(ControllerInternal.Save(model))
                    : JsonNet(viewModel);
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.SaveFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Update the status of the Account set
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Json object for Account set</returns>
        [HttpPost]
        public virtual JsonNetResult UpdateStatus(T model)
        {
            try
            {
                ViewModelBase<ModelBase> viewModel;
                return ValidateModelState(ModelState, out viewModel)
                    ? JsonNet(ControllerInternal.UpdateStatus(model))
                    : JsonNet(viewModel);
            }
            catch (BusinessException businessException)
            {
                return JsonNet(BuildErrorModelBase(CommonResx.SaveFailedMessage, businessException));
            }
        }

        /// <summary>
        /// Delete Account Set
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Json object for Account set</returns>
        [HttpPost]
        public virtual JsonNetResult Delete(string id)
        {
            try
            {
                return JsonNet(ControllerInternal.Delete(id));
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.DeleteFailedMessage, businessException,
                         AccountGroupsResx.AccountGroupCode));
            }
        }

        /// <summary>
        /// Get the Description of G/L Account
        /// </summary>
        /// <param name="model">Account set </param>
        /// <param name="accountType">accountType</param>
        /// <returns>Description of G/L Account</returns>
        [HttpPost]
        public virtual JsonNetResult GetAccountDescription(T model, AccountType accountType)
        {
            try
            {
                return JsonNet(ControllerInternal.GetAccountDescription(model, accountType));
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.RecordNotFoundMessage, businessException,
                        AccountGroupsResx.DistributionCode, ""));
            }

        }

        /// <summary>
        /// Gets the Description of Currency codes 
        /// </summary>
        /// <param name="model">Currency codes Model</param>
        /// <returns>Description of Currency codes</returns>
        [HttpPost]
        public virtual JsonNetResult GetCurrencyDescription(T model)
        {
            try
            {
                return JsonNet(ControllerInternal.GetCurrencyDescription(model));
            }
            catch (BusinessException businessException)
            {
                return
                    JsonNet(BuildErrorModelBase(CommonResx.RecordNotFoundMessage, businessException,
                     AccountGroupsResx.Currency, ""));
            }

        }

        #endregion

    }
}
