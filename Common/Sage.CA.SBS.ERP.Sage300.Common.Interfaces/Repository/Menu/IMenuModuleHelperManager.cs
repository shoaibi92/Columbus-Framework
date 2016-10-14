/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu
{
    /// <summary>
    /// Interface to manager all Menu Module Helper, currently only manage caching
    /// </summary>
    public interface IMenuModuleHelperManager
    {
        /// <summary>
        /// To hold list of all existing menu module helper in the system
        /// </summary>
        IEnumerable<Lazy<IMenuModuleHelper, IBootstrapMetadata>> AllModuleManagers { get; }

        /// <summary>
        /// To indicate whether has third party plug in menu
        /// </summary>
        bool HasPluginMenu { get; set; }
    }
}
