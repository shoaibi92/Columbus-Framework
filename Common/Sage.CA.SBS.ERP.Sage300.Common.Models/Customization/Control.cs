/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Xml.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Customization.Validators;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Customization
{
    /// <summary>
    /// Class Control.
    /// </summary>
    public class Control
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <value>The name.</value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Type - Control type
        /// </summary>
        /// <value>The type.</value>
        [XmlAttribute]
        public string Type { get; set; }

        /// <summary>
        /// True if disabled else false
        /// </summary>
        /// <value><c>true</c> if disable; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool Disable { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        /// <value>The label.</value>
        [XmlAttribute]
        public string Label { get; set; }

        /// <summary>
        /// True if invisible else false
        /// </summary>
        /// <value><c>true</c> if hide; otherwise, <c>false</c>.</value>
        [XmlAttribute]
        public bool Hide { get; set; }

    }
}