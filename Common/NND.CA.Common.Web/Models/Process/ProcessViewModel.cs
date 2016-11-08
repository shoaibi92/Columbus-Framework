/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

#region

using Sage.CA.SBS.ERP.Sage300.Common.Models;
using Sage.CA.SBS.ERP.Sage300.Common.Models.Process;

#endregion

namespace Sage.CA.SBS.ERP.Sage300.Common.Web.Models.Process
{
    /// <summary>
    /// Class ProcessViewModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProcessViewModel<T> : ViewModelBase<T> where T : ModelBase, new()
    {
        /// <summary>
        /// Gets or sets the process result.
        /// </summary>
        /// <value>The process result.</value>
        public ProcessResult ProcessResult { get; set; }

        /// <summary>
        /// Gets or sets the workflow instance identifier.
        /// </summary>
        /// <value>The workflow instance identifier.</value>
        public int WorkflowInstanceId { get; set; }
    }
}