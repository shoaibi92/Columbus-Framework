// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using System.Collections.Generic;
using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository;
using Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Utilities;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Session class for OnPremise
    /// </summary>
    public class AuthenticationSession : IAuthenticationSession
    {
        #region Public Methods
        /// <summary>
        /// Validate Login credentials
        /// </summary>
        /// <param name="userId">Login User Id</param>
        /// <param name="password">Login Password</param>
        /// <param name="company">Login Company</param>
        /// <param name="authenticationResult">Authentication Result</param>
        /// <remarks>Validate directly to session to bypass caching of session and credentials</remarks>
        public void Validate(string userId, string password, string company, AuthenticationResult authenticationResult)
        {
            try
            {
                // Locals
                var session = new Session();
                bool expiresToday;
                bool expiresTwoWeeks;
                int daysLeft;

                // Attempt to open a session which performs the major validations
                session.InitEx2(null, "", Helper.ApplicationIdentifier, Helper.ProgramName, Helper.ApplicationVersion, 1);
                session.Open(userId, password, company, DateUtil.GetNowDate(), 0);
                session.OpenDBLink(DBLinkType.Company, DBLinkFlags.ReadWrite);

                // Error not thrown in opening of session, so get password criteria
                session.DoesPWExpireToday(userId, password, out expiresToday, out expiresTwoWeeks, out daysLeft);
                authenticationResult.PasswordResult = new PasswordResult
                {
                    ExpiresToday = expiresToday,
                    ExpiresTwoWeeks = expiresTwoWeeks,
                    DaysRemaining = daysLeft
                };
            }
            catch (Exception ex)
            {
                throw new AuthenticationSessionException(ex.InnerException.Message, ex.InnerException.HResult, ex);
            }
        }

        /// <summary>
        /// Set Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="authenticationResult">Authentication Result</param>
        public void SetPassword(string userId, string oldPassword, string newPassword,
            string confirmPassword, AuthenticationResult authenticationResult)
        {
            try
            {
                // Locals
                var session = new Session();
                bool changed;
                authenticationResult.PasswordResult = new PasswordResult();

                // Init session
                session.InitEx2(null, "", Helper.ApplicationIdentifier, Helper.ProgramName, Helper.ApplicationVersion, 1);

                // Assign minimum length - Need to do validation here so not to proceed with attempted change
                authenticationResult.PasswordResult.MinimumPasswordLength = session.GetMinimumPasswordLength();
                if (newPassword.Length < authenticationResult.PasswordResult.MinimumPasswordLength)
                {
                    return;
                }

                // Set new password
                var retVal = session.SetPWWithErrorCode(userId, oldPassword, newPassword, out changed);

                // Set status and error code
                authenticationResult.PasswordResult.PasswordChanged = changed;
                authenticationResult.PasswordResult.PasswordException = (PasswordException)retVal;
            }
            catch (Exception ex)
            {
                throw new AuthenticationSessionException(ex.InnerException.Message, ex.InnerException.HResult, ex);
            }
        }

        /// <summary>
        /// Gets a list of company's for a session opened
        /// </summary>
        /// <param name="context"></param>
        /// <returns>List of organizations</returns>
        public List<Common.Models.Organization> GetCompanies(Context context)
        {
            return BusinessEntitySession.GetCompanies(context);
        }

        #endregion
    }
}
