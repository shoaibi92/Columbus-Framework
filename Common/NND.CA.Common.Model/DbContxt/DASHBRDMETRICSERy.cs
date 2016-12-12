namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDMETRICSERIES")]
    public partial class DASHBRDMETRICSERy
    {
        [Key]
        [StringLength(14)]
        public string SERIES_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        [StringLength(14)]
        public string KPI_ID { get; set; }

        public int? SERIESXLABEL { get; set; }

        public int? SERIESYVALUE { get; set; }

        public int? SERIESZVALUE { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(60)]
        public string DESCR { get; set; }

        public int? SERIESCOLOR { get; set; }

        [StringLength(20)]
        public string SERIESCHARTTYPE { get; set; }

        public virtual DASHBRDKPI DASHBRDKPI { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC { get; set; }
    }
}
