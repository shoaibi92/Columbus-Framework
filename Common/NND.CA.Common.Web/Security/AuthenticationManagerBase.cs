// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces

using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Web.AreaConstants;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Manager Base class
    /// </summary>
    public class AuthenticationManagerBase : IAuthenticationManager
    {
        #region Private properties
        /// <summary>
        /// Authentication Result
        /// </summary>
        private readonly AuthenticationResult _authenticationResult = new AuthenticationResult();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets Authentication Result
        /// </summary>
        public AuthenticationResult AuthenticationResult
        {
            get
            {
                return _authenticationResult;   
            } 
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="controller">The controller</param>
        public virtual void Login(Controller controller = null)
        {
        }

        /// <summary>
        /// Login Result
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="signOnResult">The sign on result</param>
        /// <param name="container">Container</param>
        public virtual void LoginResult(Controller controller, string signOnResult,
            IUnityContainer container)
        {
        }

        /// <summary>
        /// Login Result
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <param name="company">Company</param>
        /// <param name="userId">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="container">Container</param>
        /// <param name="context">The context</param>
        public virtual void LoginResult(string sessionId, string company, string userId, string password,
            IUnityContainer container, Context context)
        {
        }

        /// <summary>
        /// End session
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="clear">True to clear the session otherwise false</param>
        /// <param name="context">The context</param>
        /// <remarks>Do specific end session work before calling base method</remarks>
        public virtual void EndSession(Controller controller, bool clear, Context context)
        {
            if (!clear)
            {
                return;
            }

            controller.Session.RemoveAll();
            controller.Session.Abandon();
            controller.Session.Clear();

            // Clear Session and ARR Cookies
            ClearCookie(controller, Shared.DotNetSessionId);
            ClearCookie(controller, Shared.ApplicationRequestRoutingCookie);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="container">Container</param>
        public virtual void ChangePassword(string userId, string oldPassword, string newPassword,
            string confirmPassword, IUnityContainer container)
        {
        }

        /// <summary>
        /// Clear Login
        /// </summary>
        /// <param name="controller">The controller</param>
        public virtual void Clear(Controller controller = null)
        {
        }

        /// <summary>
        /// To validate database access
        /// </summary>
        /// <param name="context">Context</param>
        public virtual void ValidateDatabaseAccess(Context context)
        {
            ///TODO update to "Cloud" version to validate database access
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Clear Cookie
        /// </summary>
        /// <param name="controller">Controller</param>
        /// <param name="cookieName">Cookie Name</param>
        private static void ClearCookie(Controller controller, string cookieName)
        {
            var httpCookie = controller.Response.Cookies[cookieName];

            if (httpCookie == null)
            {
                return;
            }

            httpCookie.Value = string.Empty;
            httpCookie.Expires = DateUtil.GetNowDate().AddMonths(-20);
        }

        #endregion
    }
}