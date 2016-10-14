/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Enums.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Process
{
    /// <summary>
    /// Process result class
    /// </summary>
    public class ProcessResult
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public ProcessResult()
        {
            Results = new List<EntityError>();
        }

        /// <summary>
        /// Process Status
        /// </summary>
        public ProcessStatus ProcessStatus { get; set; }

        /// <summary>
        /// Process Result
        /// </summary>
        public List<EntityError> Results { get; set; }

        /// <summary>
        /// Progress Meter
        /// </summary>
        public ProgressMeter ProgressMeter { get; set; }
        
        /// <summary>
        /// Model after processing
        /// </summary>
        public object ResultObject { get; set; }
    }
}