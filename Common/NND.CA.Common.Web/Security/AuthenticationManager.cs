// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Authentication;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities.Constants;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using SageNA.CE.UM.Client;
using SageNA.CE.UMClientInterface;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Manager class for Sage ID
    /// </summary>
    public class AuthenticationManager : AuthenticationManagerBase
    {
        #region Public Methods

        /// <summary>
        /// Login for Sage ID
        /// </summary>
        /// <param name="controller">The controller</param>
        public override void Login(Controller controller = null)
        {
            // Sage ID UM Client
            var umClient = new UMClient();

            // Assign URL
            AuthenticationResult.Url = umClient.StartSignOn(controller).AbsoluteUri;
        }

        /// <summary>
        /// Login Result for Sage ID
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="signOnResult">The sign on result</param>
        /// <param name="container">Container</param>
        public override void LoginResult(Controller controller, string signOnResult, IUnityContainer container)
        {
            // Sage ID UM CLient
            var umClient = new UMClient();

            var userSignOnResult =  umClient.GetSignOnInfo(controller, signOnResult);
            var userTenantInfo = ConvertToUserTenantInfo(userSignOnResult);

            // The login attempt failed, so clean up the session and render the authentication error
            if (userTenantInfo.IsError)
            {
                if (new Guid(signOnResult) == Guid.Empty)
                {
                    Logger.Info("The login attempt failed. SingOnCancelled.", LoggingConstants.ModuleAuthentication);
                    Login(controller);
                    return;
                }

                // Log the error
                Logger.Info(
                    string.Format("The login attempt failed. CE Sign On was not successful. {0}",
                        userTenantInfo.Error == null
                            ? string.Empty
                            : string.Format("Reason: {0}, Message: {1}", userTenantInfo.Error.Reason,
                                userTenantInfo.Error.Message)), LoggingConstants.ModuleAuthentication);

                // Redirect to Error page if there is no active tenants for user
                if (userTenantInfo.ProductUserId != Guid.Empty)
                {
                    var tenants = GetTenantsByProductUserId(userTenantInfo.ProductUserId, container);
                    if (tenants.Any(t => t.Status != (int)TenantStatus.Active))
                    {
                        Logger.Info(
                            string.Format(
                                "No active tenants exist in landlord database for User [ProductUserId='{0}']",
                                userTenantInfo.ProductUserId), LoggingConstants.ModuleAuthentication);

                        AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                        AuthenticationResult.ActionName = "AccountNotAvailable";
                        AuthenticationResult.ControllerName = "Error";
                        AuthenticationResult.RouteValues = new { area = "Core" };
                        return;
                    }
                }

                // Redirect to generic error page
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                AuthenticationResult.ActionName = "Index";
                AuthenticationResult.ControllerName = "Error";
                AuthenticationResult.RouteValues = new { area = "Core" };
                return;
            }

            // Map landlord data 
            ApplyLandlordData(userTenantInfo, container);

            // Display the error if the user has not yet been provisioned (missing in the landlord database)
            if (!userTenantInfo.LoggedInUser.Provisioned)
            {
                Logger.Info(string.Format(
                    "Login failed for user [ProductUserId='{0}']. The user has not been provisioned yet.", userTenantInfo.LoggedInUser.ProductUserId),
                    LoggingConstants.ModuleAuthentication);
                EndSession(controller, true, null);

                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                AuthenticationResult.ActionName = "AccountNotProvisioned";
                AuthenticationResult.ControllerName = "Error";
                AuthenticationResult.RouteValues = new { area = "Core" };
                return;
            }

            // Cache information
            Utilities.Utilities.StoreUserSignOnResult(userTenantInfo);

            var activeTenants = userTenantInfo.Tenants.Where(x => x.Status == TenantStatus.Active).ToList();
            // Let the user select the Tenant if there is more than one active tenants
            if (activeTenants.Count > 1)
            {
                // TODO: May need to cache authentication if tenant is selected elsewhere and does not come back here
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                AuthenticationResult.ActionName = "Index";
                AuthenticationResult.ControllerName = "Tenant";
                AuthenticationResult.RouteValues = new { area = "Core" };
                return;
            }

            // Use the active Tenant if it exists, otherwise use the first tenant from the list
            var defaultTenant = activeTenants.Count == 1 ? activeTenants.First() : userTenantInfo.Tenants.FirstOrDefault();
            if (defaultTenant != null)
            {
                if (defaultTenant.Status != TenantStatus.Active)
                {
                    Logger.Info(string.Format(
                        "Login failed for user [ProductUserId='{0}']. Tenant [ID='{1}'] status is: '{2}'",
                            userTenantInfo.LoggedInUser.ProductUserId, defaultTenant.TenantId, defaultTenant.Status),
                        LoggingConstants.ModuleAuthentication);
                    EndSession(controller, true, null);

                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                    AuthenticationResult.ActionName = "AccountNotAvailable";
                    AuthenticationResult.ControllerName = "Error";
                    AuthenticationResult.RouteValues = new { area = "Core" };
                    return;
                }

                // set the company for selected tenant.
                Utilities.Utilities.SetSelectedTenantToSession(defaultTenant.TenantId, userTenantInfo, container);

                // Destroy the current Pool created for this session. 
                // After destroying, a new pool will be created with new business entity initialized 
                CommonService.DestroyPool(controller.Session.SessionID);

                controller.TempData["umURL"] = userTenantInfo.UserManagementAdminApplicationUrl;

                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
                AuthenticationResult.ActionName = "Index";
                AuthenticationResult.ControllerName = "Home";
                AuthenticationResult.RouteValues = new { tenantAlias = userTenantInfo.SelectedTenant.TenantAlias };
                return;
            }

            // No tenants associated with the user
            Logger.Info(string.Format(
                "Login failed for user [ProductUserId='{0}']. No Tenants are associated with the user",
                    userTenantInfo.LoggedInUser.ProductUserId),
                LoggingConstants.ModuleAuthentication);
            EndSession(controller, true, null);

            AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.RedirectToAction;
            AuthenticationResult.ActionName = "Index";
            AuthenticationResult.ControllerName = "Error";
            AuthenticationResult.RouteValues = new { area = "Core" };
        }

        /// <summary>
        /// End session
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="clear">True to clear the session otherwise false</param>
        /// <param name="context">The context</param>
        /// <remarks>Do specific end session work before calling base method</remarks>
        public override void EndSession(Controller controller, bool clear, Context context)
        {
            // Sage ID UM CLient
            var umClient = new UMClient();
            umClient.EndSession(controller);

            base.EndSession(controller, clear, context);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the signed on CE user's person and tenant information from the user sign on
        /// result that should be stored in the controller's session.  Returns null if that
        /// information could not be retrieved.  It is up to the caller to decide how to
        /// handle that "null" case.
        /// </summary>
        /// <param name="userSignOnResult"></param>
        /// <returns>The signed on CE user's person and tenant information, or null if it
        /// could not be retrieved.</returns>
        private UserTenantInfo ConvertToUserTenantInfo(UserSignOnResult userSignOnResult)
        {
            var userTenantInfo = GetUserTenantInfo(userSignOnResult);

            // If the user sign on result has error.
            if (userTenantInfo.IsError)
            {
                return userTenantInfo;
            }

            // Set Person and Tenant info details to userTenantInfo
            var valuesSet = SetPersonAndTenantInfo(userSignOnResult, userTenantInfo);

            if (!valuesSet)
            {
                // The user should be associated with at least one tenant that has rights to our
                // app (in other words, whose app ID is our app ID).
                // Return null
                return null;
            }

            return userTenantInfo;
        }

        /// <summary>
        /// Users the sign on result is valid.
        /// </summary>
        /// <param name="userSignOnResult">The user sign on result.</param>
        /// <returns>returns validated UserTenantInfo</returns>
        private UserTenantInfo GetUserTenantInfo(UserSignOnResult userSignOnResult)
        {
            var userTenantInfo = new UserTenantInfo();

            if (null == userSignOnResult)
            {
                Logger.Info("UserSignOnResult from logon result is null.", LoggingConstants.ModuleAuthentication );
                userTenantInfo.IsError = true;
                return userTenantInfo;
            }

            userTenantInfo.IsValid = userSignOnResult.IsValid;
            userTenantInfo.IsAuthoritative = userSignOnResult.IsAuthoritative;
            userTenantInfo.ProductUserId = userSignOnResult.User == null
                ? Guid.Empty
                : userSignOnResult.User.ProductUserId;

            if (!userSignOnResult.IsValid)
            {
                Logger.Info(userSignOnResult.SignOnInfoText + " " + userSignOnResult.Reason, LoggingConstants.ModuleAuthentication);

                userTenantInfo.IsError = true;
                userTenantInfo.Error = new Error
                {
                    Message = userSignOnResult.SignOnInfoText,
                    Reason = userSignOnResult.Reason.ToString()
                };
                return userTenantInfo;
            }

            if (null == userSignOnResult.User)
            {
                Logger.Info("UserSignOnResult.User is null.", LoggingConstants.ModuleAuthentication);
                userTenantInfo.IsError = true;
                return userTenantInfo;
            }

            if (null == userSignOnResult.User.PersonInfo)
            {
                Logger.Info("UserSignOnResult.User.PersonInfo is null.", LoggingConstants.ModuleAuthentication);
                userTenantInfo.IsError = true;
                return userTenantInfo;
            }

            if (null == userSignOnResult.User.AppUserAccessInfo)
            {
                Logger.Info("UserSignOnResult.User.AppUserAccessInfo is null.", LoggingConstants.ModuleAuthentication);
                userTenantInfo.IsError = true;
                return userTenantInfo;
            }

            if (userSignOnResult.User.PersonInfo.UserManagementUrl == null)
            {
                Logger.Info("UserSignOnResult.User.PersonInfo.UserManagementUrl is empty.", LoggingConstants.ModuleAuthentication);
                userTenantInfo.IsError = true;
                return userTenantInfo;
            }

            userTenantInfo.UserManagementAdminApplicationUrl = userSignOnResult.User.PersonInfo.UserManagementUrl;

            return userTenantInfo;
        }

        /// <summary>
        /// Gets the person information.
        /// </summary>
        /// <param name="userSignOnResult">The user sign on result.</param>
        /// <param name="userTenantInfo">The user person tenant information.</param>
        /// <returns>True if set, false if not set</returns>
        private bool SetPersonAndTenantInfo(UserSignOnResult userSignOnResult, UserTenantInfo userTenantInfo)
        {
            var ceAppId = new Guid(ConfigurationHelper.GetConfigValue(Constant.ApplicationId));

            var ceTenants =
                userSignOnResult.User.AppUserAccessInfo.Where(appuserAccessInfo => ((appuserAccessInfo.AppId == ceAppId)
                    && (null != appuserAccessInfo.TenantInfo)))
                    .Select(appUserAccess => appUserAccess.TenantInfo)
                    .ToArray();

            // The user should be associated with at least one tenant that has rights to our
            // app (in other words, whose app ID is our app ID).
            if (!ceTenants.Any())
            {
                Logger.Info(string.Format("Failed to retrieve any tenants for product user '{0}' ({1})",
                                        userSignOnResult.User.ProductUserId, 
                                        userSignOnResult.User.PersonInfo.PrimaryEmail), 
                                        LoggingConstants.ModuleAuthentication);
                return false;
            }

            var userInfo = new UserInfo
            {
                FirstName = userSignOnResult.User.PersonInfo.FirstName,
                LastName = userSignOnResult.User.PersonInfo.LastName,
                IsActive = userSignOnResult.User.PersonInfo.IsActive,
                PersonId = userSignOnResult.User.PersonInfo.PersonId,
                UserManagementUrl = userSignOnResult.User.PersonInfo.UserManagementUrl,
                ProductUserId = userSignOnResult.User.ProductUserId
            };

            var tenants =
                ceTenants.Select(
                    ceTenant =>
                        new TenantInfo
                        {
                            TenantId = ceTenant.TenantId,
                            TenantName = ceTenant.TenantName,
                            TenantAlias = ceTenant.TenantId.ToString()//Not using sage customer name as it can have special characters, may not be unique or may be long.
                        }).ToList();

            userTenantInfo.LoggedInUser = userInfo;
            userTenantInfo.Tenants = tenants;

            return true;
        }

        /// <summary>
        /// Get Tenants by product user id
        /// </summary>
        /// <param name="productUserId">Product User ID</param>
        /// <param name="container">Container</param>
        /// <returns>List of Tenants</returns>
        private static IEnumerable<Tenant> GetTenantsByProductUserId(Guid productUserId, IUnityContainer container)
        {
            var context = Utilities.Utilities.GetContext(Guid.Empty, productUserId, container);
            var service = Utilities.Utilities.Resolve<ILandlordService>(context);

            return service.GetTenantsByProductUserId(productUserId);
        }

        /// <summary>
        /// Get the user tenant
        /// </summary>
        /// <param name="tenantId">The sage tenant id.</param>
        /// <param name="productUserId">Product User id</param>
        /// <param name="container">Container</param>
        /// <returns>UserTenant</returns>
        private static UserTenant GetUserTenant(Guid tenantId, Guid productUserId, IUnityContainer container)
        {
            var context = Utilities.Utilities.GetContext(tenantId, productUserId, container);
            var service = Utilities.Utilities.Resolve<ILandlordService>(context);

            return service.Get(productUserId, tenantId);
        }


        /// <summary>
        /// Set tenant status
        /// </summary>
        /// <param name="userTenantInfo">User Person Tenant object</param>
        /// <param name="container">Container</param>
        /// <returns>True if any tenant is active else false.</returns>
        internal void ApplyLandlordData(UserTenantInfo userTenantInfo, IUnityContainer container)
        {
            foreach (var tenant in userTenantInfo.Tenants)
            {
                var landlordUserTenant = GetUserTenant(tenant.TenantId, userTenantInfo.LoggedInUser.ProductUserId, container);

                if (landlordUserTenant != null)
                {
                    // Set user got Provisioned.
                    userTenantInfo.LoggedInUser.Provisioned = true;

                    tenant.Status = (TenantStatus)landlordUserTenant.Tenant.Status;

                    // Set whether the user is first time user.
                    userTenantInfo.LoggedInUser.FirstTimeUser = landlordUserTenant.User.FirstTimeUser;

                    if (tenant.Status != TenantStatus.Active)
                    {
                        Logger.Info(
                            string.Format("Tenant is not active. Tenant Id: {0} , Tenant Status: {1}", tenant.TenantId,
                                tenant.Status), LoggingConstants.ModuleAuthentication);
                    }
                }
                else
                {
                    Logger.Info(
                        string.Format(
                            "User Tenant Mapping is not available. Tenant Id {0}, ProductUserId {1}, User {2} ",
                            tenant.TenantId, userTenantInfo.LoggedInUser.ProductUserId,
                            userTenantInfo.LoggedInUser.FirstName + "" + userTenantInfo.LoggedInUser.LastName),
                        LoggingConstants.ModuleAuthentication);

                    // Set as Mapping Not available.
                    tenant.Status = TenantStatus.None;
                }
            }

            // Filter Tenants collection to contain only records that do exist in the Landlord Database
            userTenantInfo.Tenants = userTenantInfo.Tenants.Where(t => t.Status != TenantStatus.None).ToList();
        }

        #endregion
    }
}