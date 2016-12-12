namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHGROUPEMPS")]
    public partial class SCHGROUPEMP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }

        public virtual SCHGROUP SCHGROUP { get; set; }
    }
}
