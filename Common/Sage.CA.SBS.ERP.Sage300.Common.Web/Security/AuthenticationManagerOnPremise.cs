// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Base;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.AS.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Landlord;
using Sage.CA.SBS.ERP.Sage300.Common.Resources;
using Sage.CA.SBS.ERP.Sage300.Common.Services;
using Sage.CA.SBS.ERP.Sage300.Core.Logging;
using Sage.CA.SBS.ERP.Sage300.CS.Interfaces.Services;
using Sage.CA.SBS.ERP.Sage300.CS.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Manager class for OnPremise
    /// </summary>
    public class AuthenticationManagerOnPremise : AuthenticationManagerBase
    {
        #region Private Variables

        private readonly List<string> _requiredAppIds = new List<string>{"GL"};

        private readonly string STR_ZI_INTEGRATION_VERSION = "53A";

        #endregion

        #region Public Methods
        /// <summary>
        /// Login for OnPremise
        /// </summary>
        /// <param name="controller">The controller</param>
        public override void Login(Controller controller = null)
        {
            // Assign View Name
            AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.View;
            AuthenticationResult.ViewName = AreaConstants.Core.OnPremiseLoginView;
        }

        /// <summary>
        /// Login Result for OnPremise
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <param name="company">Company</param>
        /// <param name="userId">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="container">Container</param>
        /// <param name="context">The context</param>
        public override void LoginResult(string sessionId, string company, string userId, string password, 
            IUnityContainer container, Context context)
        {
            // Parameter validations
            userId = (userId == null) ? string.Empty : userId.Trim().ToUpper();
            password = (password == null) ? string.Empty : password.Trim().ToUpper();
            company = (company == null) ? string.Empty : company.ToUpper();

            // Check company and do not continue if field does not have value
            if (!RequiredCredential(company, ASCommonResx.Company))
            {
                return;
            }

            // Check user and do not continue if field does not have value
            if (!RequiredCredential(userId, ASCommonResx.UserID))
            {
                return;
            }

            // Validate credentials and do not continue if credentials are invalid
            Validate(userId, password, company, container);
            if (!AuthenticationResult.IsSuccess)
            {
                return;
            }

            try
            {
                var userTenantResolver = container.Resolve<IUserTenantResolver>();
                var userTenantInfo = userTenantResolver.ResolveUserTenant(container, context, company, userId, password);

                var commonService = Utilities.Utilities.Resolve<ICommonService>(context);
                var appIds = commonService.GetActiveApplications().Select(app => app.AppId);

                if (IsICTCompany(commonService.GetActiveApplications()))
                {
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                    AuthenticationResult.IsSuccess = true;
                    AuthenticationResult.ActionName = "ICTNotAvailable";
                    AuthenticationResult.ControllerName = "Error";
                    AuthenticationResult.RouteValues = new {area = "Core"};

                    CommonService.DestroyPool(sessionId);
                    return;
                }

                //Check if all required applications are installed
                if (_requiredAppIds.Except(appIds).Any())
                {
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                    AuthenticationResult.IsSuccess = true;
                    AuthenticationResult.ActionName = "MissingModules";
                    AuthenticationResult.ControllerName = "Error";
                    AuthenticationResult.RouteValues = new {area = "Core"};

                    CommonService.DestroyPool(sessionId);
                    return;
                }

                // Cache information
                Utilities.Utilities.StoreUserSignOnResult(userTenantInfo);

                // Get the url for home page
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = true;
                AuthenticationResult.ActionName = "Index";
                AuthenticationResult.ControllerName = "Home";
                AuthenticationResult.RouteValues =
                    new {area = "Core", tenantAlias = userTenantInfo.SelectedTenant.TenantAlias};

                // Store cookie to be used as defaults for next login
                AuthenticationResult.Cookie = new AuthenticationCookie
                {
                    UserId = userId,
                    Company = company
                };

                // Ensure any pools are removed that are created during login
                CommonService.DestroyPool(sessionId);

                ValidateDatabaseAccess(context);
            }
            catch (Exception ex)
            {
                // Errors relating to dbconfig.xml file and Portal Database
                const int errorPortalDatabase = unchecked((int) 0x80131904);
                const int errorPortalDbConfig1 = unchecked((int) 0x80131537);
                const int errorPortalDbConfig2 = unchecked((int) 0x80070057);
                const int errorNoPortalCredentials = unchecked((int)0x80070002);
                const int errorNoAdminServices = unchecked((int)0x80004003);
                const int errorInvalidDatabase = unchecked((int)0x80131600);


                // Default to thrown message
                var message = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;

                if (ex.InnerException != null && ex.InnerException.HResult.Equals(errorPortalDatabase))
                {
                    // Override message
                    message = ASCommonResx.PortalLoginMessage;
                }
                else if (ex.HResult.Equals(errorPortalDbConfig1) || ex.HResult.Equals(errorPortalDbConfig2)) 
                {
                    // Override message
                    message = ASCommonResx.PortalLoginMessage;
                }
                else if (ex.HResult.Equals(errorNoPortalCredentials))
                {
                    // No portal credentials message
                    message = ASCommonResx.NoPortalCredentialsMessage;
                }
                else if (ex.HResult.Equals(errorNoAdminServices))
                {
                    // No admin services message
                    message = ASCommonResx.NoAdminServicesMessage;
                }
                else if (ex.HResult.Equals(errorInvalidDatabase))
                {
                    message = CommonResx.GenericViewError;
                }

                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = false;
                AuthenticationResult.Message = new EntityError
                {
                    Message = message,
                    Priority = Priority.Error,
                    Tag = AuthenticationException.LoginException
                };

                Logger.Error(ex.Message, ex);
                // Ensure any pools are removed that are created during login
                CommonService.DestroyPool(sessionId);

            }
        }

        /// <summary>
        /// To validate database access
        /// </summary>
        /// <param name="context">Context</param>
        public override void ValidateDatabaseAccess(Context context)
        {
            // try to get the company profile to see if database access is ok or not, will throw exception if fail
            var companyProfileService = Utilities.Utilities.Resolve<ICompanyProfileService<CompanyProfile>>(context);

            var profile = companyProfileService.Get();
        }

        /// <summary>
        /// Function to test if ICT module is active
        /// </summary>
        /// <param name="activeApplications">List&lt;ActiveApplication&gt;</param>
        /// <returns>true if company is ICT, false otherwise </returns>
        private bool IsICTCompany(List<ActiveApplication> activeApplications)
        {
            bool result = false;

            ActiveApplication ziApplication = activeApplications.FirstOrDefault(x => x.AppId == "ZI");

            if (ziApplication != null && string.Compare(ziApplication.AppVersion, STR_ZI_INTEGRATION_VERSION, StringComparison.InvariantCulture) >= 0)
            {
                result = true;
            }

            return result;
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
            // We will reuse the UserTenant record created in this session when the same user starts a 
            // subsequent session; therefore, we no longer need to remove it from the landlord database.
            //
            //var userTenantInfo = Utilities.Utilities.GetStoredUserSignOnResult();
            //if (userTenantInfo != null && userTenantInfo.SelectedTenant != null)
            //{
            //    var landlordService = Utilities.Utilities.Resolve<ILandlordService>(context);
            //    landlordService.DeleteUserTenant(userTenantInfo.ProductUserId, userTenantInfo.SelectedTenant.TenantId);
            //}

            base.EndSession(controller, true, context);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="container">Container</param>
        public override void ChangePassword(string userId, string oldPassword,
            string newPassword, string confirmPassword, IUnityContainer container)
        {
            // User and Passwords must be upper cased
            userId = userId.Trim().ToUpper();
            oldPassword = oldPassword.Trim().ToUpper();
            newPassword = newPassword.Trim().ToUpper();
            confirmPassword = confirmPassword.Trim().ToUpper();

            // Check user and do not continue if field does not have value
            if (!RequiredCredential(userId, ASCommonResx.UserID))
            {
                return;
            }

            // Check old password and do not continue if field does not have value
            if (!RequiredCredential(oldPassword, ASCommonResx.OldPassword))
            {
                return;
            }

            // Check new password and do not continue if field does not have value
            if (!RequiredCredential(newPassword, ASCommonResx.NewPassword))
            {
                return;
            }

            // Check confirm password and do not continue if field does not have value
            if (!RequiredCredential(confirmPassword, ASCommonResx.ConfirmPassword))
            {
                return;
            }

            // Passwords do not match
            if (!newPassword.Equals(confirmPassword))
            {
                // Invalid
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = false;
                AuthenticationResult.Message = new EntityError
                {
                    Message = string.Format(ASCommonResx.MismatchPasswordMessage, ASCommonResx.NewPassword, ASCommonResx.ConfirmPassword),
                    Priority = Priority.Error,
                    Tag = AuthenticationException.PasswordChangeValidation
                };
                return;
            }

            // Passwords are the same
            if (newPassword.Equals(oldPassword))
            {
                // Invalid
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = false;
                AuthenticationResult.Message = new EntityError
                {
                    Message = ASCommonResx.SamePasswordMessage,
                    Priority = Priority.Error,
                    Tag = AuthenticationException.PasswordChangeValidation
                };
                return;
            }

            // Set password
            SetPassword(userId, oldPassword, newPassword, confirmPassword, container);

        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <param name="controller">The controller</param>
        public override void Clear(Controller controller = null)
        {
            // Change return action
            AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;

            // Remove session cache key
            Utilities.Utilities.SetResumeLogin(null);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Required Login credential
        /// </summary>
        /// <param name="property">Property to be required</param>
        /// <param name="propertyToken">Message Token</param>
        /// <returns>True if has value otherwise false</returns>
        private bool RequiredCredential(string property, string propertyToken)
        {
            // Valid if property have a value
            if (!string.IsNullOrEmpty(property))
            {
                return true;
            }

            // Invalid
            AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
            AuthenticationResult.IsSuccess = false;
            AuthenticationResult.Message = new EntityError
            {
                Message = string.Format(CommonResx.CannotBeBlankMessage, propertyToken),
                Priority = Priority.Error,
                Tag = AuthenticationException.RequiredCredential
            };

            return false;
        }

        /// <summary>
        /// Login Result for OnPremise
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="company">Company</param>
        /// <param name="container">Container</param>
        private void Validate(string userId, string password, string company, IUnityContainer container)
        {
            // Errors thrown by base library
            const int errorUserDisabled = unchecked((int) 0xE0000080L);
            const int errorPasswordChangeRequired = unchecked((int) 0xE0000060L);
            const int errorUserRestricted = unchecked((int) 0xE0000090L);
            const int errorUserLocked = unchecked((int) 0xE0000070L);
            const int errorBadSignon = unchecked((int) 0xE0000004L);
            const int errorBadUserId = unchecked((int) 0xE0000008L);
            const int errorBadParams = unchecked((int) 0xE0000001L);
            const int errorNoAccess = unchecked((int) 0xE0000020L);
            const int errorNoLicense = unchecked((int)0x80040112);
            const int errorNoAdminServices = unchecked((int)0x80004003);

            try
            {
                // Validate credentials
                var authenticationSession = container.Resolve<IAuthenticationSession>();
                authenticationSession.Validate(userId, password, company, AuthenticationResult);

                if ((Utilities.Utilities.GetResumeLogin() == null) &&
                    (AuthenticationResult.PasswordResult.ExpiresToday ||
                    AuthenticationResult.PasswordResult.ExpiresTwoWeeks))
                {
                    // Assign error message to result
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                    AuthenticationResult.IsSuccess = false;
                    AuthenticationResult.Message = new EntityError
                    {
                        Message = AuthenticationResult.PasswordResult.ExpiresToday ? ASCommonResx.PasswordExpiresTodayMessage : ASCommonResx.PasswordExpiresSoonMessage,
                        Priority = Priority.Warning,
                        Tag = AuthenticationResult.PasswordResult.ExpiresToday ? AuthenticationException.PasswordExpiresToday : AuthenticationException.PasswordExpiresSoon
                    };
                }
                else
                {
                    // Success
                    AuthenticationResult.IsSuccess = true;
                    Utilities.Utilities.SetResumeLogin(null);
                }

            }
            catch (Exception ex)
            {
                string message;
                AuthenticationException authenticationException;

                switch (ex.HResult)
                {
                    case errorUserDisabled:
                        // User is disabled
                        message = ASCommonResx.UserDisabledMessage;
                        authenticationException = AuthenticationException.UserDisabled;
                        break;
                    case errorPasswordChangeRequired:
                        // Password change is required
                        message = ASCommonResx.PasswordChangeMessage;
                        authenticationException = AuthenticationException.PasswordChangeRequired;
                        break;
                    case errorUserRestricted:
                        // User is restricted
                        message = ASCommonResx.UserRestrictedMessage;
                        authenticationException = AuthenticationException.UserRestricted;
                        break;
                    case errorUserLocked:
                        // User is locked
                        message = ASCommonResx.UserLockedMessage;
                        authenticationException = AuthenticationException.UserLocked;
                        break;
                    case errorBadSignon:
                    case errorBadUserId:
                    case errorBadParams:
                    case errorNoAccess:
                        // Bad sign on, parameters, etc.
                        message = string.Format(ASCommonResx.ErrorPasswordMessage, ASCommonResx.UserID, ASCommonResx.Password);
                        authenticationException = AuthenticationException.LoginFailure;
                        break;
                    case errorNoLicense:
                        // No license (WX...)
                        message = ASCommonResx.NoLicenseMessage;
                        authenticationException = AuthenticationException.NoLicense;
                        break;
                    case errorNoAdminServices:
                        // No Adminstrative Services (i.e. No databases loaded yet...)
                        message = ASCommonResx.NoAdminServicesMessage;
                        authenticationException = AuthenticationException.NoAdminServices;
                        break;
                    default:
                        // Unknown. So, display message in error
                        message = ex.Message;
                        authenticationException = AuthenticationException.LoginException;
                        break;
                }

                // Assign error message to result
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = false;
                AuthenticationResult.Message = new EntityError
                {
                    Message = message,
                    Priority = Priority.Error,
                    Tag = authenticationException
                };
            }
        }

        /// <summary>
        /// Set Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="container">Container</param>
        private void SetPassword(string userId, string oldPassword, string newPassword, string confirmPassword,
            IUnityContainer container)
        {
            // Locals
            string message;
            AuthenticationException authenticationException;

            try
            {
                // Set Password
                var authenticationSession = container.Resolve<IAuthenticationSession>();
                authenticationSession.SetPassword(userId, oldPassword, newPassword, confirmPassword, AuthenticationResult);

                // Validate minimum length
                if (newPassword.Length < AuthenticationResult.PasswordResult.MinimumPasswordLength)
                {
                    // Invalid
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                    AuthenticationResult.IsSuccess = false;
                    AuthenticationResult.Message = new EntityError
                    {
                        Message = string.Format(ASCommonResx.MinLengthPasswordMessage, ASCommonResx.NewPassword),
                        Priority = Priority.Error,
                        Tag = AuthenticationException.PasswordChangeValidation
                    };
                    return;
                }

                // Validate if password not changed
                if (!AuthenticationResult.PasswordResult.PasswordChanged)
                {
                    switch (AuthenticationResult.PasswordResult.PasswordException)
                    {
                        case PasswordException.CannotChangePassword:
                            // Cannot change password restriction
                            message = ASCommonResx.CannotChangePasswordMessage;
                            authenticationException = AuthenticationException.PasswordChangeRestriction;
                            break;

                        case PasswordException.ComplexPasswordRequired:
                            // Complex password required
                            message = ASCommonResx.ComplexPasswordMessage;
                            authenticationException = AuthenticationException.PasswordChangeComplexRequired;
                            break;

                        case PasswordException.SamePassword:
                            // Passwords cannot be reused
                            message = ASCommonResx.SamePasswordMessage;
                            authenticationException = AuthenticationException.PasswordChangeValidation;
                            break;

                        default:
                            // Default message
                            message = string.Format(ASCommonResx.ErrorPasswordMessage, ASCommonResx.UserID, ASCommonResx.Password);
                            authenticationException = AuthenticationException.PasswordChangeFailure;
                            break;
                    }

                    // Assign failures
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                    AuthenticationResult.IsSuccess = false;
                    AuthenticationResult.Message = new EntityError
                    {
                        Message = message,
                        Priority = Priority.Error,
                        Tag = authenticationException
                    };

                }
                else
                {
                    // Success
                    AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                }
            }
            catch (Exception ex)
            {
                AuthenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
                AuthenticationResult.IsSuccess = false;
                AuthenticationResult.Message = new EntityError
                {
                    Message = ex.Message,
                    Priority = Priority.Error,
                    Tag = AuthenticationException.PasswordChangeException
                };
            }
        }

        #endregion
    }
}