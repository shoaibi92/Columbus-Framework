namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NUMBERS")]
    public partial class NUMBER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NUMBER()
        {
            ASSQUESTS = new HashSet<ASSQUEST>();
            CL_REFNOS = new HashSet<CL_REFNOS>();
            CLTDEPTs = new HashSet<CLTDEPT>();
            DEPTNUMS = new HashSet<DEPTNUM>();
            EMPREFNOS = new HashSet<EMPREFNO>();
            EXPPAYROLLs = new HashSet<EXPPAYROLL>();
            EXPPAYROLLs1 = new HashSet<EXPPAYROLL>();
            SYSTEMs = new HashSet<SYSTEM>();
            SYSTEMs1 = new HashSet<SYSTEM>();
            SYSTEMs2 = new HashSet<SYSTEM>();
            SYSTEMs3 = new HashSet<SYSTEM>();
            SYSTEMs4 = new HashSet<SYSTEM>();
            SYSTEMs5 = new HashSet<SYSTEM>();
            USERS = new HashSet<USER>();
            USERS1 = new HashSet<USER>();
        }

        [Key]
        [StringLength(14)]
        public string NUMBER_ID { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string FORMAT { get; set; }

        [StringLength(20)]
        public string FORMULA { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string UNIQNUM { get; set; }

        [StringLength(1)]
        public string NUMTYPE { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(1)]
        public string NOFREEFORM { get; set; }

        public int? NMINLENGTH { get; set; }

        public int? NMAXLENGTH { get; set; }

        [StringLength(1)]
        public string NUMREQ { get; set; }

        [StringLength(1)]
        public string ADMINREF { get; set; }

        [StringLength(100)]
        public string NUMMASK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CL_REFNOS> CL_REFNOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTNUM> DEPTNUMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPREFNO> EMPREFNOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPPAYROLL> EXPPAYROLLs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPPAYROLL> EXPPAYROLLs1 { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs5 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS1 { get; set; }
    }
}
