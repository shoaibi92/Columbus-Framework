/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// Generic Report
    /// </summary>
    public class GenericReport : ReportBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public GenericReport()
        {
            Parameters = new List<Parameter>();
        }

        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute]
        public Guid Id { get; set; }

        /// <summary>
        /// Parameters of the report
        /// </summary>
        public List<Parameter> Parameters { get; set; }

        /// <summary>
        /// Menu Id
        /// </summary>
        [XmlAttribute]
        public string MenuId { get; set; }

        /// <summary>
        /// Program Id
        /// </summary>
        [XmlAttribute]
        public string ProgramId { get; set; }

        /// <summary>
        /// Name of the report
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Label of the report
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
        /// Clone the Report
        /// </summary>
        /// <returns>Report</returns>
        public GenericReport Clone()
        {
            var other = (GenericReport) MemberwiseClone();

            if (other.Label != null)
            {
                other.Label = Label.Clone();
            }
            other.Parameters = new List<Parameter>();
            foreach (var parameter in Parameters)
            {
                var newParameter = parameter.Clone();
                if (parameter.Control != null)
                {
                    newParameter.Control = parameter.Control.Clone();
                }
                if (parameter.Label != null)
                {
                    newParameter.Label = parameter.Label.Clone();
                }
                other.Parameters.Add(newParameter);
            }
            return other;
        }
    }
}