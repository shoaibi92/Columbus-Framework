/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization
{
    /// <summary>
    /// Screens
    /// </summary>
    public class Screens
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Screens()
        {
            ScreenList = new List<Screen>();
        }

        /// <summary>
        /// List of Screens
        /// </summary>
        [XmlElement("Screen", typeof (Screen))] public List<Screen> ScreenList;
    }
}