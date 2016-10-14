/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Xml.Serialization;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Parameter class
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Label of the parameter
        /// </summary>
        public Label Label { get; set; }

        /// <summary>
        /// Get the label Text
        /// </summary>
        public string LabelText
        {
            get
            {
                if (Label != null)
                {
                    return Label.Caption;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Control
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// Type of Data
        /// </summary>
        [XmlAttribute]
        public DataType DataType { get; set; }

        /// <summary>
        /// Is the parameter hidden
        /// </summary>
        [XmlAttribute]
        public bool Hide { get; set; }

        /// <summary>
        /// Value of the parameter
        /// </summary>
        [XmlAttribute]
        public string Value { get; set; }

        /// <summary>
        /// Clone the Paramter
        /// </summary>
        /// <returns>Paramter</returns>
        public Parameter Clone()
        {
            return (Parameter) MemberwiseClone();
        }
    }
}