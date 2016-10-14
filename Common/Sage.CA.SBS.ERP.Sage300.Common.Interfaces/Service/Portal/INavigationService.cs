/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Portal
{
    /// <summary>
    /// Interface INavigationService For XML Based Menu
    /// </summary>
    /// <typeparam name="T"> NavigableMenu </typeparam>
    public interface INavigationService<T> : ISecurityService where T : NavigableMenu, new()
    {
        /// <summary>
        /// Gets the NavigableMenu object for Menu Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <param name="isReturnNonActiveMenu">bool</param>
        /// <returns>list of menu objects</returns>
        List<T> GetMenuDetails(string fileLocation, bool isReturnNonActiveMenu = false);
    }
}
