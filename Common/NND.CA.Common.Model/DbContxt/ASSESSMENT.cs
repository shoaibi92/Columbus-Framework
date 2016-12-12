namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSESSMENTS")]
    public partial class ASSESSMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASSESSMENT()
        {
            ASSESSMDS = new HashSet<ASSESSMD>();
            ASSESSOASIS = new HashSet<ASSESSOASI>();
            ASSESSRAIs = new HashSet<ASSESSRAI>();
            ASSGROUPS = new HashSet<ASSGROUP>();
            ASSQUESTS = new HashSet<ASSQUEST>();
            ASSSECTS = new HashSet<ASSSECT>();
            CLTASSESSes = new HashSet<CLTASSESS>();
            DEPTASSESSes = new HashSet<DEPTASSESS>();
            EMPFRMS = new HashSet<EMPFRM>();
            GRPASSESSes = new HashSet<GRPASSESS>();
            PATHSTEPS = new HashSet<PATHSTEP>();
        }

        [Key]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string ANAME { get; set; }

        [Required]
        [StringLength(3)]
        public string ASORTORDER { get; set; }

        [StringLength(100)]
        public string AREFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string ASYSDEFINED { get; set; }

        [Required]
        [StringLength(1)]
        public string ARECSTATUS { get; set; }

        [StringLength(1)]
        public string ARECTYPE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ALLOWORDER { get; set; }

        [StringLength(14)]
        public string CATLOOKUPVAL_ID { get; set; }

        public decimal? LOCKVALUE { get; set; }

        public string PROPS { get; set; }

        [StringLength(1)]
        public string FINALDOCS { get; set; }

        [StringLength(1)]
        public string ARECSUBTYPE { get; set; }

        public int? ACOMPATIBILITYINDEX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSMD> ASSESSMDS { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSOASI> ASSESSOASIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSESSRAI> ASSESSRAIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSGROUP> ASSGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTASSESS> DEPTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRPASSESS> GRPASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEP> PATHSTEPS { get; set; }
    }
}
