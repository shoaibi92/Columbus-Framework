namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDMETRICS")]
    public partial class DASHBRDMETRIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DASHBRDMETRIC()
        {
            DASHBRDDETAILS = new HashSet<DASHBRDDETAIL>();
            DASHBRDMETRICDISPLAYs = new HashSet<DASHBRDMETRICDISPLAY>();
            DASHBRDMETRICKPIS = new HashSet<DASHBRDMETRICKPI>();
            DASHBRDMETRICKPIS1 = new HashSet<DASHBRDMETRICKPI>();
            DASHBRDMETRICSCORES = new HashSet<DASHBRDMETRICSCORE>();
            DASHBRDMETRICSERIES = new HashSet<DASHBRDMETRICSERy>();
        }

        [Key]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string METRICTITLE { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(20)]
        public string CHARTTYPE { get; set; }

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

        [StringLength(80)]
        public string DATASORTORDER { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public int? STARTWEEK { get; set; }

        public int? STARTYEAR { get; set; }

        [StringLength(1)]
        public string COMMONSTRUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDDETAIL> DASHBRDDETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICDISPLAY> DASHBRDMETRICDISPLAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICKPI> DASHBRDMETRICKPIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICKPI> DASHBRDMETRICKPIS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICSCORE> DASHBRDMETRICSCORES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICSERy> DASHBRDMETRICSERIES { get; set; }
    }
}
