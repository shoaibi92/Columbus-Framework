namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AVONETIMES")]
    public partial class AVONETIME
    {
        [Key]
        [StringLength(14)]
        public string AVONE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime AVDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string AVAILABLE { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        [StringLength(80)]
        public string COMMENTS { get; set; }

        public int? AVTIMES { get; set; }

        public DateTime? START1 { get; set; }

        public DateTime? STOP1 { get; set; }

        public DateTime? START2 { get; set; }

        public DateTime? STOP2 { get; set; }

        public DateTime? START3 { get; set; }

        public DateTime? STOP3 { get; set; }

        public DateTime? START4 { get; set; }

        public DateTime? STOP4 { get; set; }

        public DateTime? START5 { get; set; }

        public DateTime? STOP5 { get; set; }

        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public string PROPS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
