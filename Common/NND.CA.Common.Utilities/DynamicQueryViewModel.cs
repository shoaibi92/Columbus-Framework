/* Copyright (c) 1994-2015 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Class for DynamicQueryViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicQueryViewModel<T> where T : ApplicationModelBase, new()
    {
        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public DynamicQueryEnumerableResponse<T> Data { get; set; }

        /// <summary>
        /// Gets or sets UserMessage
        /// </summary>
        public UserMessage UserMessage { get; set; }

        /// <summary>
        /// Gets or sets UserAccess
        /// </summary>
        public UserAccess UserAccess { get; set; }

        /// <summary>
        /// Intailizing ViewModelBaseKPI
        /// </summary>
        public DynamicQueryViewModel()
        {
            UserMessage = new UserMessage();
            Data = new DynamicQueryEnumerableResponse<T>();
        }

        /// <summary>
        /// Gets or sets the widget name
        /// </summary>
        public string WidgetName { get; set; }

    }
}