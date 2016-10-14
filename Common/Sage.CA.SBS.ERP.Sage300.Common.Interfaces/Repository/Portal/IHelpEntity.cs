/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;
using System;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Repository.Portal
{
    /// <summary>
    /// Interface IHelpEntity For XML Based Menu Help
    /// </summary>
    /// <typeparam name="T"> MenuHelp </typeparam>
    public interface IHelpEntity<T> : IDisposable where T : MenuHelp, new()
    {
        /// <summary>
        /// Gets the MenuHelp object for Menu Help Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns>list of help objects</returns>
        List<T> GetMenuHelp(string fileLocation);
    }
}
