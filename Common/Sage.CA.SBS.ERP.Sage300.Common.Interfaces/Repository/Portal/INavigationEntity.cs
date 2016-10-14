/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal
{
    /// <summary>
    /// Interface INavigationEntity For XML Based Menu
    /// </summary>
    /// <typeparam name="T"> NavigableMenu </typeparam>
    public interface INavigationEntity<T> : IDisposable where T : NavigableMenu, new()
    {
        /// <summary>
        /// Gets the NavigableMenu object for Menu Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <param name="isReturnNonActiveMenu">bool</param>
        /// <returns>list of menu objects</returns>
        List<T> GetMenuDetails(string fileLocation, bool isReturnNonActiveMenu);
    }
}
