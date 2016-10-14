/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal
{
    /// <summary>
    /// Interface ISecurityCheckRepository
    /// </summary>
    public interface IMenuSecurityEntity : IRepository, IDisposable
    {
        /// <summary>
        /// To get list of Menus after getting checked against its resource key.
        /// </summary>
        /// <param name="resourceIdList">resoureKkey</param>
        /// <returns></returns>
        List<string> SecurityCheck(List<string> resourceIdList);
    }
}
