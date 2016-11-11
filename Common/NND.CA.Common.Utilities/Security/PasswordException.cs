// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Enumeration of Password Exceptions
    /// </summary>
    public enum PasswordException
    {
        /// <summary> None - Success </summary>
        None = 0,
        /// <summary> Cannot change password </summary>
        CannotChangePassword = 1,
        /// <summary> Complex password required </summary>
        ComplexPasswordRequired = 2,
        /// <summary> Same password </summary>
        SamePassword = 4
    }
}
