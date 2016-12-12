namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDMETRICKPIS")]
    public partial class DASHBRDMETRICKPI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DASHBRDMETRICKPI()
        {
            DASHBRDMETRICSCORES = new HashSet<DASHBRDMETRICSCORE>();
        }

        [Key]
        [StringLength(14)]
        public string METRICKPI_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string KPI_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(3)]
        public string DATERTYPE { get; set; }

        public int? DATERCOUNTER { get; set; }

        public DateTime? DATERSTART { get; set; }

        public DateTime? DATERSTOP { get; set; }

        public int? DATERSTARTINDEX { get; set; }

        [StringLength(14)]
        public string DRILLDOWNMETRIC_ID { get; set; }

        public int? DRILLDOWNINDEX { get; set; }

        [Required]
        [StringLength(1)]
        public string SCORETYPE { get; set; }

        public int? SCORESOURCEINDEX { get; set; }

        public int? SCORETARGETINDEX { get; set; }

        public decimal? SCOREFUDGEFACTOR { get; set; }

        [Required]
        [StringLength(1)]
        public string SCOREDISPLAYTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string SCOREIMAGELIST { get; set; }

        [StringLength(20)]
        public string SCORELABEL { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DASHBRDKPI DASHBRDKPI { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICSCORE> DASHBRDMETRICSCORES { get; set; }
    }
}
