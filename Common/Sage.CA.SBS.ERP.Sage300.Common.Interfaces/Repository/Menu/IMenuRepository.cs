/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Menu
{
    /// <summary>
    /// Menu Repository Interface
    /// </summary>
    public interface IMenuRepository : IRepository, IDisposable, ISecurity
    {
        /// <summary>
        /// Flag for optional field for the system
        /// </summary>
        bool IsOptionalFieldActivated { get; set; }

        /// <summary>
        /// Flag for national account license
        /// </summary>
        bool HasNationalAccountLicense { get; set; }

        /// <summary>
        /// Get Menu header base on the company
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<NavigableMenu> GetMenuHeader(string company);

        /// <summary>
        /// Get all MenuItems base on the module without any filtering
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="headerMenuId">string</param>
        /// <param name="removeHeader">bool</param>
        /// <returns>List</returns>
        List<NavigableMenu> GetMenuItems(string company, string headerMenuId, bool removeHeader = true);

        /// <summary>
        /// Save updated menu item
        /// </summary>
        /// <param name="company">string</param>
        /// <param name="menuList">List of NavigableMenu</param>
        void SaveAllMenuItems(string company, List<NavigableMenu> menuList);

        /// <summary>
        /// Get all Widget items
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        List<NavigableMenu> GetWidgetItems(string company);

        /// <summary>
        /// Get all Menu Items with filtering base on multicurrency, optional field and activation ... etc
        /// </summary>
        /// <param name="company">string</param>
        /// <returns>List</returns>
        List<NavigableMenu> GetAllMenuItems(string company);
    }
}
