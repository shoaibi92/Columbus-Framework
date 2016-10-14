/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Runtime.Serialization;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Process
{
    /// <summary>
    /// Class for getting/showing progress of business entity component
    /// </summary>
    [DataContract]
    public class ProgressMeter
    {
        /// <summary>
        /// Cancel ?
        /// </summary>
        [DataMember]
        public bool Cancel { get; set; }

        /// <summary>
        /// Status - true/false
        /// </summary>
        [DataMember]
        public bool IsRunning { get; set; }

        /// <summary>
        /// Caption messages
        /// </summary>
        [DataMember]
        public string Caption { get; set; }

        /// <summary>
        /// Status text
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// Show gauge
        /// </summary>
        [DataMember]
        public bool ShowGauge { get; set; }

        /// <summary>
        /// Show cancel button or no
        /// </summary>
        [DataMember]
        public bool ShowCancel { get; set; }

        /// <summary>
        /// Show cancel button or no
        /// </summary>
        [DataMember]
        public int Percent { get; set; }
    }
}