/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

namespace Sage.CA.SBS.ERP.Sage300.Common.Models
{
    /// <summary>
    /// Class to get and set Enum value for select list
    /// </summary>
    public class CustomSelectList
    {
        /// <summary>
        /// Gets or sets a value that indicates whether this <see cref="T:System.Web.Mvc.CustomSelectList"/> is selected.
        /// </summary>
        /// 
        /// <returns>
        /// true if the item is selected; otherwise, false.
        /// </returns>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the text of the selected item.
        /// </summary>
        /// 
        /// <returns>
        /// The text.
        /// </returns>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value of the selected item.
        /// </summary>
        /// 
        /// <returns>
        /// The value.
        /// </returns>
        public string Value { get; set; }
    }
}