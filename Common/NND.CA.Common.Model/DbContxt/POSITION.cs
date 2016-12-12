namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POSITIONS")]
    public partial class POSITION
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string POS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

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
