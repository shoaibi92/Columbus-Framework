// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Mock class for password expires today
    /// </summary>
    public class MockPasswordExpiresToday : MockAuthenticationSessionBase
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
        public override void Validate(string userId, string password, string company, AuthenticationResult authenticationResult)
        {
            // Mock password expires today
            authenticationResult.PasswordResult = new PasswordResult
            {
                ExpiresToday = true,
                ExpiresTwoWeeks = false,
                DaysRemaining = 0
            };

            authenticationResult.Action = AuthenticationResult.AuthenticationAction.JsonResult;
            authenticationResult.IsSuccess = false;
            authenticationResult.Message = new EntityError
            {
                Message = "Password expires today",
                Priority = Priority.Warning,
                Tag = AuthenticationException.PasswordExpiresToday
            };
        }
        #endregion
    }
}
