/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Xml.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Utilities;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Label
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Caption Resource Id
        /// </summary>
        [XmlAttribute]
        public string ResourceId { get; set; }

        /// <summary>
        /// ResourceAssemblyType
        /// </summary>
        [XmlAttribute]
        public string ResourceAssemblyType { get; set; }

        /// <summary>
        /// Caption to Display in UI
        /// </summary>
        public string Caption
        {
            get { return ResourceUtil.GetString(ResourceAssemblyType, ResourceId); }
        }

        /// <summary>
        /// Clone the Label
        /// </summary>
        /// <returns>Paramter</returns>
        public Label Clone()
        {
            return (Label) MemberwiseClone();
        }
    }
}