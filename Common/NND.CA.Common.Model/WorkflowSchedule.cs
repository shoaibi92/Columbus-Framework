using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
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
