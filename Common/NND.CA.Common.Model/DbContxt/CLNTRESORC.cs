namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLNTRESORC")]
    public partial class CLNTRESORC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTVISITOR_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string RES_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string CODE { get; set; }

        public DateTime? FSCHEDVIS { get; set; }

        public DateTime? LSCHEDVIS { get; set; }

        public DateTime? LSCHEDPER { get; set; }

        public int? TSCHEDVIS { get; set; }

        public decimal? TSCHEDHRS { get; set; }

        public DateTime? FTIMEVIS { get; set; }

        public DateTime? LTIMEVIS { get; set; }

        public int? TTIMEVIS { get; set; }

        public int? TTKPERVIS { get; set; }

        public decimal? TTKHRS { get; set; }

        public decimal? TTKPERHRS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(10)]
        public string RELATION { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual RESOURCE RESOURCE { get; set; }

        public virtual CLTVISITOR CLTVISITOR { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }
    }
}
