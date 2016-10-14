/* Copyright (c) 1994-2016 Sage Software, Inc.  All rights reserved. */

using System.ComponentModel;
using Newtonsoft.Json;

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// These properties are used for storing column preferences.
    /// </summary>
    public class GridColumn
    {
        /// <summary>
        /// To assign kendo grid field  key-value pair.
        /// </summary>
        //Making the property name for serialization to a single character helps in saving storage as we have a limit of 3kb when it comes to saving user preference
        //[JsonProperty(PropertyName = "f")]
        public string field { get; set; }

        /// <summary>
        /// Whether the column is hidden or not.
        /// </summary>
        //Making the property name for serialization to a single character helps in saving storage as we have a limit of 3kb when it comes to saving user preference
        //[JsonProperty(PropertyName = "h")]
        [DefaultValue(false)]
        public bool isHidden { get; set; }
    }
}
