namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHSTEPS")]
    public partial class PATHSTEP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHSTEP()
        {
            CLTPATHCOSTEPS = new HashSet<CLTPATHCOSTEP>();
            CLTPATHITEMS = new HashSet<CLTPATHITEM>();
            CLTPATHITEMSXes = new HashSet<CLTPATHITEMSX>();
            CLTPATHVISITS = new HashSet<CLTPATHVISIT>();
            CLTPATHVISITS1 = new HashSet<CLTPATHVISIT>();
            CLTPATHWAYS = new HashSet<CLTPATHWAY>();
            PATHSTEPITEMLINKS = new HashSet<PATHSTEPITEMLINK>();
            PATHSTEPITEMS = new HashSet<PATHSTEPITEM>();
            PATHWAYSTEPS = new HashSet<PATHWAYSTEP>();
        }

        [Key]
        [StringLength(14)]
        public string STEP_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DEFDESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string IGNORECOSTEP { get; set; }

        [StringLength(14)]
        public string FCAT_ID { get; set; }

        public decimal? LOCKVALUE { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHCOSTEP> CLTPATHCOSTEPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEM> CLTPATHITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEMSX> CLTPATHITEMSXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHWAY> CLTPATHWAYS { get; set; }

        public virtual PATHCAT PATHCAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEPITEMLINK> PATHSTEPITEMLINKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEPITEM> PATHSTEPITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHWAYSTEP> PATHWAYSTEPS { get; set; }
    }
}
