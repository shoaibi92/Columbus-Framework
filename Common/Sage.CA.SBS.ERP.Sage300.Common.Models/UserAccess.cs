/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// User Access
    /// </summary>
    public class UserAccess
    {
        /// <summary>
        /// Type of security for the main view
        /// </summary>
        public SecurityType SecurityType;

        /// <summary>
        /// Dictionary that contains the entity name and security for the entity
        /// </summary>
        public Dictionary<string, UserAccess> ResourceSecurity;
    }
}