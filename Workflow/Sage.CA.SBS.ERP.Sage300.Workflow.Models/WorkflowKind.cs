/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Workflow Kind
    /// </summary>
    public class WorkflowKind
    {
        /// <summary>
        /// WorkflowKindId
        /// </summary>
        public int WorkflowKindId { get; set; }

        /// <summary>
        /// UniqueName
        /// </summary>
        [StringLength(50)]
        public string UniqueName { get; set; }

        /// <summary>
        /// MaxRetries
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// UnitOfWorkKinds
        /// </summary>
        public virtual ICollection<UnitOfWorkKind> UnitOfWorkKinds { get; set; }

        /// <summary>
        /// WorkflowInstances
        /// </summary>
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }

        /// <summary>
        /// WorkflowSchedules
        /// </summary>
        public virtual ICollection<WorkflowSchedule> WorkflowSchedules { get; set; }
    }
}
