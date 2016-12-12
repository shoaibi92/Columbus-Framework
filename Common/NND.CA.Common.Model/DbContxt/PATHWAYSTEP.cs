namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHWAYSTEPS")]
    public partial class PATHWAYSTEP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string PATHWAY_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string STEP_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string SCHANGED { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }

        public virtual PATHWAY PATHWAY { get; set; }
    }
}
