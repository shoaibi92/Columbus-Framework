/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Workflow Schedule
    /// </summary>
    public class WorkflowSchedule
    {
        /// <summary>
        /// WorkflowScheduleId
        /// </summary>
        public int WorkflowScheduleId { get; set; }

        /// <summary>
        /// Tenant Id
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// InitiatorId
        /// </summary>
        public Guid InitiatorId { get; set; }

        /// <summary>
        /// WorkflowKindId
        /// </summary>
        public int WorkflowKindId { get; set; }

        /// <summary>
        /// IsRunning
        /// </summary>
        public bool IsRunning { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        public long Interval { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// NextRunTime
        /// </summary>
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// SeedEntity
        /// </summary>
        public string SeedEntity { get; set; }

        /// <summary>
        /// AggregateEntity
        /// </summary>
        public string AggregateEntity { get; set; }

        /// <summary>
        /// WorkflowInstances
        /// </summary>
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }

        /// <summary>
        /// WorkflowKind
        /// </summary>
        public virtual WorkflowKind WorkflowKind { get; set; }
    }
}
