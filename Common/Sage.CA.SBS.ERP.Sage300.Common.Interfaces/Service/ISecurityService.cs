/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service
{
    /// <summary>
    /// Methods for implementing Security
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Get rights
        /// </summary>
        /// <returns>UserAccess</returns>
        UserAccess GetAccessRights();
    }
}