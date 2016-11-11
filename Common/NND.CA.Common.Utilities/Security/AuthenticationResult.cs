// Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved.

#region Namespaces
using Sage.CA.SBS.ERP.Sage300.Common.Models;
#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Authentication Result
    /// </summary>
    public class AuthenticationResult
    {
        #region Public Enumeration
        /// <summary>
        /// Enumeration for actions when returned to controller
        /// </summary>
        public enum AuthenticationAction
        {
            Redirect = 0,
            RedirectToAction = 1,
            View = 2,
            JsonResult = 3
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticationResult()
        {
            // Set default(s)
            Action = AuthenticationAction.Redirect;
            IsSuccess = true;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Action Enumeration
        /// </summary>
        public AuthenticationAction Action { get; set; }

        /// <summary>
        /// URL for redirection
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// View Name
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Action Name
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Controller Name
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// Route Values
        /// </summary>
        public object RouteValues { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public EntityError Message { get; set; }

        /// <summary>
        /// Cookie
        /// </summary>
        public AuthenticationCookie Cookie { get; set; }

        /// <summary>
        /// Password Result
        /// </summary>
        public PasswordResult PasswordResult { get; set; }
        #endregion

    }
}