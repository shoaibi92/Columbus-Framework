namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIAGGROUPS")]
    public partial class DIAGGROUP
    {
        [Key]
        [StringLength(14)]
        public string DIAGGR_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(20)]
        public string RANGESTART { get; set; }

        [Required]
        [StringLength(20)]
        public string RANGESTOP { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }
    }
}
