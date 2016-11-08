// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Interface for Authentication Session
    /// </summary>
    public interface IAuthenticationSession
    {
        /// <summary>
        /// Validate Login credentials
        /// </summary>
        /// <param name="userId">Login User Id</param>
        /// <param name="password">Login Password</param>
        /// <param name="company">Login Company</param>
        /// <param name="authenticationResult">Authentication Result</param>
        /// <remarks>Validate directly to session to bypass caching of session and credentials</remarks>
        void Validate(string userId, string password, string company, AuthenticationResult authenticationResult);

        /// <summary>
        /// Set Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="authenticationResult">Authentication Result</param>
        void SetPassword(string userId, string oldPassword, string newPassword, string confirmPassword,
            AuthenticationResult authenticationResult);

        /// <summary>
        /// Gets a list of company's for a session opened
        /// </summary>
        /// <param name="context"></param>
        /// <returns>List of organizations</returns>
        List<Organization> GetCompanies(Context context);
    }
}