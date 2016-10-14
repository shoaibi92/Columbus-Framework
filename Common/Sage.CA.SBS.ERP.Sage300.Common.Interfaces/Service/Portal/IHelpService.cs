/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Portal;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Interfaces.Service.Portal
{
    /// <summary>
    /// Interface IHelpService For XML MenuHelp
    /// </summary>
    /// <typeparam name="T"> MenuHelp </typeparam>
    public interface IHelpService<T> : ISecurityService where T : MenuHelp, new()
    {
        /// <summary>
        /// Gets the MenuHelp object for Menu Help Items from XML file
        /// </summary>
        /// <param name="fileLocation">location of the xml file</param>
        /// <returns>list of help objects</returns>
        List<T> GetMenuHelp(string fileLocation);
    }
}
