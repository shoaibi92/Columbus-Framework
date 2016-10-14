/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Reports
{
    /// <summary>
    /// List of Reports
    /// </summary>
    public class Reports
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reports"/> class.
        /// </summary>
        public Reports()
        {
            ReportList = new List<GenericReport>();
        }

        /// <summary>
        /// List of Reports
        /// </summary>
        /// <value>The report list.</value>
        [XmlElement("Report", typeof (GenericReport))]
        public List<GenericReport> ReportList { get; set; }
    }
}