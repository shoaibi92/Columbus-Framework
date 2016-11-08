/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Core.Configuration;
using System.Collections.Generic;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web
{
    /// <summary>
    /// Class for ViewModelBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModelBase<T> where T : new()
    {
        /// <summary>
        /// Gets or sets Data
        /// This will be renamed
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets DataList
        /// This will be renamed
        /// </summary>
        public IEnumerable<T> DataList { get; set; }

        /// <summary>
        /// Gets or sets UserMessage
        /// </summary>
        public UserMessage UserMessage { get; set; }

        /// <summary>
        /// Gets or sets UserAccess
        /// </summary>
        public UserAccess UserAccess { get; set; }

        /// <summary>
        /// Intailizing ViewModelBase
        /// </summary>
        public ViewModelBase()
        {
            UserMessage = new UserMessage();
            Data = new T();
            DataList = new List<T>();
        }

        /// <summary>
        /// Get or Set Total Results Count
        /// </summary>
        public int TotalResultsCount { get; set; }

        /// <summary>
        /// Is On Premise version
        /// </summary>
        public bool IsOnPremise
        {
            get { return ConfigurationHelper.IsOnPremise; }
        }
    }
}