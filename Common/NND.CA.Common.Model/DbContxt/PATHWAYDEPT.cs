namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHWAYDEPTS")]
    public partial class PATHWAYDEPT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string PATHWAY_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual PATHWAY PATHWAY { get; set; }
    }
}
