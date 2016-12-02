using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
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
