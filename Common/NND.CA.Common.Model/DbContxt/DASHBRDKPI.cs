namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDKPIS")]
    public partial class DASHBRDKPI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DASHBRDKPI()
        {
            DASHBRDMETRICKPIS = new HashSet<DASHBRDMETRICKPI>();
            DASHBRDMETRICSERIES = new HashSet<DASHBRDMETRICSERy>();
        }

        [Key]
        [StringLength(14)]
        public string KPI_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(2)]
        public string DATAMETHOD { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DATAQUERY { get; set; }

        [Column(TypeName = "text")]
        public string DATACONNECT { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICKPI> DASHBRDMETRICKPIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDMETRICSERy> DASHBRDMETRICSERIES { get; set; }
    }
}
