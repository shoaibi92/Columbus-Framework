// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Cookie
    /// </summary>
    public class AuthenticationCookie
    {
        #region Public Properties
        /// <summary>
        /// User ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public string Company { get; set; }
        #endregion
    }
}