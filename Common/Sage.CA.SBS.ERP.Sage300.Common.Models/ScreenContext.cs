/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class ScreenContext.
    /// </summary>
    public class ScreenContext
    {
        /// <summary>
        /// Name of screen
        /// </summary>
        /// <value>The name of the screen.</value>
        public string ScreenName { get; set; }

        /// <summary>
        /// screen Definition
        /// </summary>
        /// <value>The screen.</value>
        public Screen Screen { get; set; }
    }
}