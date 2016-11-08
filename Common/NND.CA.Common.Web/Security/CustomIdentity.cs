/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Security.Principal;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Custom Identity class
    /// </summary>
    public class CustomIdentity : IIdentity
    {
        /// <summary>
        /// Custom Identity constructor to accept name, emailid and isAuthenticated
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="isAuthenticated">if set to <c>true</c> [is authenticated].</param>
        /// <param name="isGuest">if set to <c>true</c> [is guest].</param>
        public CustomIdentity(string name, string emailId, bool isAuthenticated, bool isGuest)
        {
            _name = name;
            _emailId = emailId;
            _isAuthenticated = isAuthenticated;
            _isGuest = isGuest;
        }

        /// <summary>
        /// Type of authentication used to identify the user
        /// </summary>
        public string AuthenticationType
        {
            get { return "SageId"; }
        }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated
        /// </summary>
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        /// <summary>
        /// User's email Id
        /// </summary>
        public string EmailId
        {
            get { return _emailId; }
        }

        /// <summary>
        /// Is User Guest
        /// </summary>
        public bool IsGuest
        {
            get { return _isGuest; }
        }

        #region Private members

        private readonly bool _isAuthenticated;
        private readonly string _name;
        private readonly string _emailId;
        private readonly bool _isGuest;

        #endregion
    }
}