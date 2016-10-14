/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Xml.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Control class
    /// </summary>
    public class Control
    {
        /// <summary>
        /// Type of Control
        /// </summary>
        /// <value>The type of the control.</value>
        [XmlAttribute]
        public ControlType ControlType { get; set; }

        /// <summary>
        /// Type of Finder
        /// </summary>
        /// <value>The type of the finder.</value>
        [XmlAttribute]
        public FinderType FinderType { get; set; }

        /// <summary>
        /// Name of the property used for finder
        /// </summary>
        /// <value>The property identifier.</value>
        [XmlAttribute]
        public string PropertyId { get; set; }

        /// <summary>
        /// Text of the finder
        /// </summary>
        /// <value>The finder type text.</value>
        public string FinderTypeText
        {
            get { return EnumUtility.GetStringValue(FinderType); }
        }

        /// <summary>
        /// Clone the Control
        /// </summary>
        /// <returns>Paramter</returns>
        public Control Clone()
        {
            return (Control) MemberwiseClone();
        }
    }
}