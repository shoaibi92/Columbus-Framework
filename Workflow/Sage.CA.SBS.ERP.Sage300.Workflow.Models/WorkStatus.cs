/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Work Status
    /// </summary>
    public class WorkStatus
    {
        /// <summary>
        /// Work Status Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkStatusId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }
    
        /// <summary>
        /// WorkflowInstances
        /// </summary>
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }

        /// <summary>
        /// UnitOfWorkInstances
        /// </summary>
        public virtual ICollection<UnitOfWorkInstance> UnitOfWorkInstances { get; set; }
    }
}
