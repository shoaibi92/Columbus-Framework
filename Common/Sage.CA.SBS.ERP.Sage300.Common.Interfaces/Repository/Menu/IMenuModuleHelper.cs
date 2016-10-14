/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using ACCPAC.Advantage;
using Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Bootstrap;
using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu
{
    /// <summary>
    /// Interface IMenuModuleHelper
    /// </summary>
    public interface IMenuModuleHelper
    {
        /// <summary>
        /// Initialize the module manager
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="context">Context</param>
        void Initialize(string company, Context context);

        /// <summary>
        /// Return all Menu items for the module
        /// </summary>
        /// <returns>List</returns>
        List<NavigableMenu> GetMenuItems();

        /// <summary>
        /// Save the menuItems back to module screen file
        /// </summary>
        /// <param name="menuItems">List</param>
        /// <param name="subFolder">string of subfolder name</param>
        void SaveMenuItems(List<NavigableMenu> menuItems, string subFolder);

        /// <summary>
        /// Return Menu Items with activation filter applied
        /// </summary>
        /// <returns>List</returns>
        List<NavigableMenu> GetFilteredMenuItems();

        /// <summary>
        /// Return Module specified
        /// </summary>
        string Module { get; }

        /// <summary>
        /// Return Name of the screen file
        /// </summary>
        string MenuDetailFileName { get; }

        /// <summary>
        /// Return the head of the module
        /// </summary>
        NavigableMenu ModuleHeader { get; }

        /// <summary>
        /// Id of Header Menu
        /// </summary>
        string HeaderMenuId { get; }

        /// <summary>
        /// Flag to indicate if optional field is enable
        /// </summary>
        bool IsOptionalFieldEnable { get; set; }

        /// <summary>
        /// Flag for national account license
        /// </summary>
        bool HasNationalAccountLicense { get; set; }

        /// <summary>
        /// Flag to indicate if the module is screen UI specific
        /// </summary>
        bool IsScreenUIModule { get; }

        /// <summary>
        /// To hold a list of active applications
        /// </summary>
        List<Sage.CA.SBS.ERP.Sage300.Common.Models.ActiveApplication> ActiveApplicationList { get; set; }

        /// <summary>
        /// Store current product seriese
        /// </summary>
        ProductSeries ProductSeries { get; set; }

        /// <summary>
        /// Flag to indicate whether the menu is third part developement menu 
        /// </summary>
        bool IsPlugInMenu { get; }
    }
}
