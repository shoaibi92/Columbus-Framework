namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AVROTEMP")]
    public partial class AVROTEMP
    {
        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ROTATE_ID { get; set; }

        public DateTime EFFDATE { get; set; }

        public DateTime? EXPDATE { get; set; }

        public int? DAYSTART { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        [StringLength(80)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string EMPSPEC { get; set; }

        [Key]
        [StringLength(14)]
        public string AVROTEMP_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual AVROTATE AVROTATE { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
