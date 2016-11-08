/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Security.Principal;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Security
{
    /// <summary>
    /// Custom Principal Class
    /// </summary>
    public class CustomPrincipal : IPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPrincipal"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public CustomPrincipal(IIdentity identity)
        {
            _identity = identity;
        }

        /// <summary>
        /// Gets the identity of the current principal
        /// </summary>
        /// <value>The identity.</value>
        /// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
        public IIdentity Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>true if the current principal is a member of the specified role; otherwise, false.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsInRole(String role)
        {
            throw new NotImplementedException();
        }

        #region Private Members

        /// <summary>
        /// The _identity
        /// </summary>
        private readonly IIdentity _identity;

        #endregion
    }
}