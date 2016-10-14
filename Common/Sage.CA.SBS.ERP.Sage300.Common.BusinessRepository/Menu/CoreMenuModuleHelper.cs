/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Sage.CA.SBS.ERP.Sage300.Common.BusinessRepository.Menu
{
    /// <summary>
    /// Core Module helper
    /// </summary>
    [Export(typeof(IMenuModuleHelper))]
    [BootstrapMetadataExport(BootstrapModule.Framework, new[] { BootstrapAppliesTo.Web }, 10)]
    public class CoreMenuModuleHelper : AbstractMenuModuleHelper
    {
        /// <summary>
        /// Return Module specified
        /// </summary>
        public override string Module
        {
            get { return BootstrapModule.Framework; }
        }

        /// <summary>
        /// Return Name of the screen file
        /// </summary>
        public override string MenuDetailFileName
        {
            get { return "CoreMenuDetails.xml"; }
        }

        /// <summary>
        /// Initialize the module manager
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="context">Context</param>
        public override void Initialize(string company, Context context)
        {
            PrepareDataFile(company);
        }

        /// <summary>
        /// Return Menu Items with activation filter applied
        /// </summary>
        /// <returns>List</returns>
        public override List<NavigableMenu> GetFilteredMenuItems()
        {
            return GetApplyFilteredMenuItems(null);
        }

        /// <summary>
        /// Flag to indicate if the module is screen UI specific
        /// </summary>
        public override bool IsScreenUIModule
        {
            get { return false; }
        }
    }
}
