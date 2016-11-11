// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Enumeration of Authentication Exceptions
    /// </summary>
    public enum AuthenticationException
    {
        /// <summary> None - Success </summary>
        None = 0,
        /// <summary> Catch all exception </summary>
        Unknown = 100,
        /// <summary> Hard error during login </summary>
        LoginException = 200,
        /// <summary> Failure but not hard error </summary>
        LoginFailure = 210,
        /// <summary> Invalid password </summary>
        InvalidPassword = 220,
        /// <summary> Hard error during password change </summary>
        PasswordChangeException = 300,
        /// <summary> Failure but not hard error </summary>
        PasswordChangeFailure = 310,
        /// <summary> Password change is required </summary>
        PasswordChangeRequired = 320,
        /// <summary> Password change is restricted </summary>
        PasswordChangeRestriction = 330,
        /// <summary> Password change validation issue </summary>
        PasswordChangeValidation = 340,
        /// <summary> Password change complex password required </summary>
        PasswordChangeComplexRequired = 350,
        /// <summary> Credential is required </summary>
        RequiredCredential = 400,
        /// <summary> User is diabled </summary>
        UserDisabled = 500,
        /// <summary> User is locked </summary>
        UserLocked = 510,
        /// <summary> User is restricted </summary>
        UserRestricted = 520,
        /// <summary> Password expires today </summary>
        PasswordExpiresToday = 600,
        /// <summary> Password expires soon </summary>
        PasswordExpiresSoon = 610,
        /// <summary> No license </summary>
        NoLicense = 700,
        /// <summary> No Administrative Services </summary>
        NoAdminServices = 710
    }
}
