namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPREFNOS")]
    public partial class EMPREFNO
    {
        [Key]
        [StringLength(14)]
        public string REFNUM_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string NUMBER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(20)]
        public string NUMVAL { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual NUMBER NUMBER { get; set; }
    }
}
