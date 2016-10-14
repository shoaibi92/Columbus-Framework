// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Mock class for Password Change Failure
    /// </summary>
    public class MockPasswordChangeFailure : MockAuthenticationSessionBase
    {
        #region Public Methods
        /// <summary>
        /// Set Password
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="oldPassword">Old Password</param>
        /// <param name="newPassword">New Password</param>
        /// <param name="confirmPassword">Confirm Password</param>
        /// <param name="authenticationResult">Authentication Result</param>
        public override void SetPassword(string userId, string oldPassword, string newPassword,
            string confirmPassword, AuthenticationResult authenticationResult)
        {
            // Mock password change failure
            authenticationResult.PasswordResult = new PasswordResult
            {
                MinimumPasswordLength = 0,
                PasswordChanged = false,
                PasswordException = PasswordException.None
            };
        }
        #endregion
    }
}
