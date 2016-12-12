namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTACTC")]
    public partial class CLTACTC
    {
        [Key]
        [StringLength(14)]
        public string CLTACTC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ACTIVITY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? PAYDUR { get; set; }

        [StringLength(80)]
        public string COMMENTS { get; set; }

        [Column(TypeName = "text")]
        public string DETDESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string CHANGED { get; set; }

        [Required]
        [StringLength(1)]
        public string FREQTYPE { get; set; }

        [StringLength(10)]
        public string SUNDAY { get; set; }

        [StringLength(10)]
        public string MONDAY { get; set; }

        [StringLength(10)]
        public string TUESDAY { get; set; }

        [StringLength(10)]
        public string WEDNESDAY { get; set; }

        [StringLength(10)]
        public string THURSDAY { get; set; }

        [StringLength(10)]
        public string FRIDAY { get; set; }

        [StringLength(10)]
        public string SATURDAY { get; set; }

        [StringLength(1)]
        public string DAYFREQ { get; set; }

        public DateTime? TIMEONE { get; set; }

        public DateTime? TIMETWO { get; set; }

        public DateTime? TIMETHREE { get; set; }

        public DateTime? TIMEFOUR { get; set; }

        public int? OTHFREQ { get; set; }

        [StringLength(10)]
        public string OTHUNITS { get; set; }

        [StringLength(10)]
        public string GOALID { get; set; }

        [StringLength(30)]
        public string GOALDESCR { get; set; }

        [Column(TypeName = "text")]
        public string GOALCOMM { get; set; }

        [StringLength(20)]
        public string GOALSTATUS { get; set; }

        [StringLength(10)]
        public string OUTID { get; set; }

        [StringLength(30)]
        public string OUTDESCR { get; set; }

        [Column(TypeName = "text")]
        public string OUTCOMMENT { get; set; }

        [StringLength(20)]
        public string OUTSTATUS { get; set; }

        [Required]
        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? HISTDATE { get; set; }

        [StringLength(20)]
        public string HISTCODE { get; set; }

        [StringLength(30)]
        public string HISTOUT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ACTIVITY ACTIVITY { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
