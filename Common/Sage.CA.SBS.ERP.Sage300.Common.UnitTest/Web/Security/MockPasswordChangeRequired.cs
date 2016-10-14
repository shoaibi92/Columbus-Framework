// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
using Sage.CA.SBS.ERP.Sage300.Common.Web.Security;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.UnitTest.Web.Security
{
    /// <summary>
    /// Mock class for Password Change Required
    /// </summary>
    public class MockPasswordChangeRequired : MockAuthenticationSessionBase
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
            // Mock password change is required
            const int errorPasswordChangeRequired = unchecked((int)0xE0000060L);
            throw new AuthenticationSessionException("Test password change is required", errorPasswordChangeRequired, new Exception());
        }
        #endregion
    }
}
