/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository
{
    /// <summary>
    /// Methods for implementing Secuirty
    /// </summary>
    public interface ISecurity
    {
        /// <summary>
        /// Get rights
        /// </summary>
        /// <returns>UserAccess</returns>
        UserAccess GetAccessRights();
    }
}