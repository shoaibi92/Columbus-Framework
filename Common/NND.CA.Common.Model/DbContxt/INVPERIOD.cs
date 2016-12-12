namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVPERIODS")]
    public partial class INVPERIOD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string INVRUN_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string PERTYPE { get; set; }

        [StringLength(20)]
        public string RANGEFROM { get; set; }

        [StringLength(20)]
        public string RANGETO { get; set; }

        [StringLength(1)]
        public string INVDEST { get; set; }

        [StringLength(40)]
        public string INVPATH { get; set; }

        [StringLength(1)]
        public string INVPREVIEW { get; set; }

        public DateTime? INVDATE { get; set; }

        [Column(TypeName = "text")]
        public string INVCOMMENT { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(1)]
        public string PRTCOMPANY { get; set; }

        [StringLength(1)]
        public string RPLEMP { get; set; }

        [StringLength(20)]
        public string EMPTEXT { get; set; }

        [StringLength(1)]
        public string SEPINV { get; set; }

        [StringLength(20)]
        public string INVFILE { get; set; }

        [StringLength(1)]
        public string INCREFNUM { get; set; }

        public int? PTLLANG { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual INVRUN INVRUN { get; set; }
    }
}
