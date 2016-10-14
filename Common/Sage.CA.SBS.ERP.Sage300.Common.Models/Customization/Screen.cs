/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Xml.Serialization;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization
{
    /// <summary>
    /// Class Screen.
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Screen()
        {
            Controls = new List<Control>();
            Grids = new List<Grid>();
        }

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
        [XmlElement("Control", typeof(Control))]
        public List<Control> Controls { get; set; }

        /// <summary>
        /// Gets or sets the grids.
        /// </summary>
        /// <value>The grids.</value>
        [XmlElement("Grid", typeof(Grid))]
        public List<Grid> Grids { get; set; }
    }
}