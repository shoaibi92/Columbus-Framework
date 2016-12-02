using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NND.CA.Common.Model
{
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
