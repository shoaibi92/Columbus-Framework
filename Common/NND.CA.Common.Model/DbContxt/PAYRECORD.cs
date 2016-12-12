namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYRECORDS")]
    public partial class PAYRECORD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYRECORD()
        {
            BILLRECS = new HashSet<BILLREC>();
            BILLRECS1 = new HashSet<BILLREC>();
            EMPLDEPTs = new HashSet<EMPLDEPT>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            PAYLEVELS = new HashSet<PAYLEVEL>();
            PAYRECORDS1 = new HashSet<PAYRECORD>();
            PAYRECORDS11 = new HashSet<PAYRECORD>();
            PAYRECVALs = new HashSet<PAYRECVAL>();
            ROUTEDDEFS = new HashSet<ROUTEDDEF>();
            ROUTESDEFS = new HashSet<ROUTESDEF>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LEVEL_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(10)]
        public string SERVTYPE { get; set; }

        [StringLength(20)]
        public string COSTCENTRE { get; set; }

        [StringLength(20)]
        public string EMPPOS { get; set; }

        [StringLength(14)]
        public string REGRATE { get; set; }

        [StringLength(10)]
        public string REGCODE { get; set; }

        [StringLength(5)]
        public string REGUNITS { get; set; }

        [StringLength(14)]
        public string STATRATE { get; set; }

        [StringLength(10)]
        public string STATCODE { get; set; }

        [StringLength(5)]
        public string STATUNITS { get; set; }

        [StringLength(1)]
        public string EMPINACTIVE { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(1)]
        public string EMPSPEC { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string CLTFUNDER { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [StringLength(14)]
        public string MASTERREC { get; set; }

        [StringLength(30)]
        public string MASTACCT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(14)]
        public string PARENT_ID { get; set; }

        [StringLength(1)]
        public string EXPIRED { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS1 { get; set; }

        public virtual CLTVISITOR CLTVISITOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYLEVEL> PAYLEVELS { get; set; }

        public virtual PAYLEVEL PAYLEVEL { get; set; }

        public virtual RATECODE RATECODE { get; set; }

        public virtual RATECODE RATECODE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS1 { get; set; }

        public virtual PAYRECORD PAYRECORD1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS11 { get; set; }

        public virtual PAYRECORD PAYRECORD2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECVAL> PAYRECVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDDEF> ROUTEDDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTESDEF> ROUTESDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
