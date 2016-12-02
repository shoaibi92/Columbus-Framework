using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NND.CA.Common.Model.Enums;

namespace NND.CA.Common.Model
{
    public class UnitOfWorkInstance
    {
        /// <summary>
        /// UnitOfWorkInstanceId
        /// </summary>
        public int UnitOfWorkInstanceId { get; set; }

        /// <summary>
        /// WorkflowInstanceId
        /// </summary>
        public int WorkflowInstanceId { get; set; }

        /// <summary>
        /// UnitOfWorkKindId
        /// </summary>
        public int UnitOfWorkKindId { get; set; }

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
            get { return (WorkStatusType)WorkStatusId; }
            set { WorkStatusId = (int)value; }
        }

        /// <summary>
        /// RetryCount
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// AggregateEntity
        /// </summary>
        public string AggregateEntity { get; set; }

        /// <summary>
        /// Result object
        /// </summary>
        public string ResultEntity { get; set; }

        /// <summary>
        /// Worker role instance address (IP Address)
        /// </summary>
        public string WorkerRoleAddress { get; set; }

        /// <summary>
        /// Worker role port details for WCF service
        /// </summary>
        public string WorkerRolePort { get; set; }

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
        /// UnitOfWorkKind
        /// </summary>
        public virtual UnitOfWorkKind UnitOfWorkKind { get; set; }

        /// <summary>
        /// UnitOfWorkStatus
        /// </summary>
        public virtual WorkStatus UnitOfWorkStatus { get; set; }

        /// <summary>
        /// WorkflowInstance
        /// </summary>
        public virtual WorkflowInstance WorkflowInstance { get; set; }
    }
}
