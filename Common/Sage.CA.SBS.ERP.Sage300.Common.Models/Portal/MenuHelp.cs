/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Portal
{
    /// <summary>
    /// Contains list of properties for Menu Help
    /// </summary>
    public class MenuHelp : ModelBase
    {
        /// <summary>
        /// Gets or sets ScreenMenuId 
        /// </summary>
        public string ScreenMenuId { get; set; }

        /// <summary>
        /// Gets or sets ScreenHelps 
        /// </summary>
        public List<Help> ScreenHelps { get; set; }
    }
}
