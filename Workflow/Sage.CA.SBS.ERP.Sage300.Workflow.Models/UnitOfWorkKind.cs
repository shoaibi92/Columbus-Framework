/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Unit of Work Kind
    /// </summary>
    public class UnitOfWorkKind
    {
        /// <summary>
        /// UnitOfWorkKindId
        /// </summary>
        public int UnitOfWorkKindId { get; set; }

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
        /// AssemblyName
        /// </summary>
        [StringLength(200)]
        public string AssemblyName { get; set; }

        /// <summary>
        /// TypeName
        /// </summary>
        [StringLength(100)]
        public string TypeName { get; set; }

        /// <summary>
        /// ExecutionOrder
        /// </summary>
        public int ExecutionOrder { get; set; }

        /// <summary>
        /// IsAsynchronous
        /// </summary>
        public bool IsAsynchronous { get; set; }

        /// <summary>
        /// UnitOfWorkInstances
        /// </summary>
        public virtual ICollection<UnitOfWorkInstance> UnitOfWorkInstances { get; set; }

        /// <summary>
        /// WorkflowKind
        /// </summary>
        public virtual WorkflowKind WorkflowKind { get; set; }
    }
}
