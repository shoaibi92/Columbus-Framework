/* Copyright (c) 1994-2014 Sage Software, Inc.  All rights reserved. */

using System;
using System.Collections.Generic;
using Sage.CA.SBS.ERP.Sage300.Workflow.Models.Enums;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    /// <summary>
    /// Workflow Instance
    /// </summary>
    public class WorkflowInstance
    {
        /// <summary>
        /// WorkflowInstanceId
        /// </summary>
        public int WorkflowInstanceId { get; set; }

        /// <summary>
        /// WorkflowKindId
        /// </summary>
        public int WorkflowKindId { get; set; }

        /// <summary>
        /// WorkStatusId
        /// </summary>
        public int WorkStatusId { get; set; }

        /// <summary>
        /// Tenant Id
        /// </summary>
        public Guid TenantId { get; set; }

        /// <summary>
        /// WorkStatusType
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public WorkStatusType WorkStatusType
        {
            get { return (WorkStatusType) WorkStatusId; }
            set { WorkStatusId = (int) value; }
        }

        /// <summary>
        /// InitiatorId
        /// </summary>
        public Guid InitiatorId { get; set; }

        /// <summary>
        /// RetryCount
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// SeedEntity
        /// </summary>
        public string SeedEntity { get; set; }

        /// <summary>
        /// DateCreated
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// DateStartExecution
        /// </summary>
        public DateTime? DateStartExecution { get; set; }

        /// <summary>
        /// DateCompleteExecution
        /// </summary>
        public DateTime? DateCompleteExecution { get; set; }

        /// <summary>
        /// WorkflowScheduleId
        /// </summary>
        public int? WorkflowScheduleId { get; set; }

        /// <summary>
        /// Error description (BUsiness Exceons)
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// UnitOfWorkInstances
        /// </summary>
        public virtual ICollection<UnitOfWorkInstance> UnitOfWorkInstances { get; set; }

        /// <summary>
        /// WorkflowKind
        /// </summary>
        public virtual WorkflowKind WorkflowKind { get; set; }

        /// <summary>
        /// WorkStatus
        /// </summary>
        public virtual WorkStatus WorkStatus { get; set; }

        /// <summary>
        /// WorkflowSchedule
        /// </summary>
        public virtual WorkflowSchedule WorkflowSchedule { get; set; }
    }
}
