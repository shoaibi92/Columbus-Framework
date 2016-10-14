using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sage.CA.SBS.ERP.Sage300.Workflow.Models
{
    public class WorkflowStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkflowStatusId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    
        public virtual ICollection<WorkflowInstance> WorkflowInstances { get; set; }
    }
}
