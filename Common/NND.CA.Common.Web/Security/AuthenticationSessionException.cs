// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using System;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Session Exception for OnPremise
    /// </summary>
    public class AuthenticationSessionException : Exception
    {
        #region Constructor
        /// <summary>
        /// Can only override HResult in contstructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="hResult">Exception HResult</param>
        /// <param name="exception">Inner Exception</param>
        public AuthenticationSessionException(string message, int hResult, Exception exception) :
            base(message, exception)
        {
            HResult = hResult;
        }
        #endregion
    }
}
