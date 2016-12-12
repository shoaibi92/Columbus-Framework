namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDMETRICSCORES")]
    public partial class DASHBRDMETRICSCORE
    {
        [Key]
        [StringLength(14)]
        public string SCORE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        [StringLength(14)]
        public string METRICKPI_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DESCR { get; set; }

        public decimal STARTRANGE { get; set; }

        public int? IMAGEINDEX { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DASHBRDMETRICKPI DASHBRDMETRICKPI { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC { get; set; }
    }
}
