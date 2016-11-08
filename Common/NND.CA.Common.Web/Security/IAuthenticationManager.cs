// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Interface for Authentication Manager
    /// </summary>
    public interface IAuthenticationManager
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="controller">The controller</param>
        void Login(Controller controller = null);

        /// <summary>
        /// Login Result
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="signOnResult">The sign on result</param>
        /// <param name="container">Container</param>
        void LoginResult(Controller controller, string signOnResult, IUnityContainer container);

        /// <summary>
        /// Login Result
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <param name="company">Company</param>
        /// <param name="userId">User ID</param>
        /// <param name="password">Password</param>
        /// <param name="container">Container</param>
        /// <param name="context">The context</param>
        void LoginResult(string sessionId, string company, string userId, string password, IUnityContainer container, Context context);

        /// <summary>
        /// End session
        /// </summary>
        /// <param name="controller">The controller</param>
        /// <param name="clear">True to clear the session otherwise false</param>
        /// <param name="context">The context</param>
        /// <remarks>Do specific end session work before calling base method</remarks>
        void EndSession(Controller controller, bool clear, Context context);

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="container">Container</param>
        void ChangePassword(string userId, string oldPassword,
            string newPassword, string confirmPassword, IUnityContainer container);

        /// <summary>
        /// Clear Login
        /// </summary>
        /// <param name="controller">The controller</param>
        void Clear(Controller controller = null);

        /// <summary> Authentication result </summary>
        /// <remarks> Result from Authentication </remarks>
        AuthenticationResult AuthenticationResult { get; }

        /// <summary>
        /// To validate database access
        /// </summary>
        /// <param name="context">Context</param>
        void ValidateDatabaseAccess(Context context);
    }
}