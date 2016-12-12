namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPSTATES")]
    public partial class EMPSTATE
    {
        [Key]
        [StringLength(14)]
        public string HISTORY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        public DateTime? AUXDATE { get; set; }

        [StringLength(40)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string ACTDONE { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(30)]
        public string REASON2 { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }
    }
}
