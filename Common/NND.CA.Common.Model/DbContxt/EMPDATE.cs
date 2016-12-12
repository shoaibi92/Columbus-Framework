namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPDATES")]
    public partial class EMPDATE
    {
        [Key]
        [StringLength(14)]
        public string EMPDATE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DESCR_ID { get; set; }

        [Column("EMPDATE")]
        public DateTime? EMPDATE1 { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
