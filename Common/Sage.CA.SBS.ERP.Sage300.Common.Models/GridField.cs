/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums;
using System.Collections.Generic;


#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Contains list of properties for GridField
    /// </summary>
    public class GridField : BusinessEntityField
    {
        /// <summary>
        /// To assign kendo grid field  key-value pair
        /// </summary>
        public string fieldToQuery { get; set; }

        /// <summary>
        /// To assign kendo grid width key-value pair
        /// </summary>
        public int width { get; set; }

        /// <summary>
        /// To assign kendo grid attributes key-value pair
        /// </summary>
        public string attributes { get; set; }

        /// <summary>
        ///  To assign kendo grid headerAttributes key-value pair
        /// </summary>
        public string headerAttributes { get; set; }

        /// <summary>
        ///  To assign kendo grid template key-value pair
        /// </summary>
        public string template { get; set; }

        /// <summary>
        ///  To assign kendo grid format key-value pair
        /// </summary>
        public string format { get; set; }

        /// <summary>
        ///  To assign kendo grid hidden key-value pair
        /// </summary>
        public bool hidden { get; set; }

        /// <summary>
        /// Dictionary of all the custom attributes
        /// </summary>
        public IDictionary<string, string> customAttributes { get; set; }

        /// <summary>
        /// Present list, with list of all allowed values
        /// </summary>
        public IEnumerable<CustomSelectList> PresentationList { get; set; }

        /// <summary>
        /// This is only required on service side. If this is set to true, then this column will only be used to filter.
        /// </summary>
        public FinderDisplayType FinderDisplayType { get; set; }

        /// <summary>
        /// If true, this column will not be displayed in edit column popup
        /// </summary>
        public bool IgnorePreferences { get; set; }
    }
}