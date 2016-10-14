/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization
{
    /// <summary>
    /// Class Grid.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Screen Name
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// List of controls
        /// </summary>
        /// <value>The controls.</value>
        [XmlElement("Control", typeof (Control))]
        public List<Control> Controls { get; set; }
    }
}