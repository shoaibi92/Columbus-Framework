namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOOKUPS")]
    public partial class LOOKUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOOKUP()
        {
            ASSQUESTS = new HashSet<ASSQUEST>();
            CLIENTS = new HashSet<CLIENT>();
            DEPTSTATUS = new HashSet<DEPTSTATU>();
            DEPTSTATUS1 = new HashSet<DEPTSTATU>();
            FUNDCLTREFs = new HashSet<FUNDCLTREF>();
            LOOKUPVALS = new HashSet<LOOKUPVAL>();
            NOTETYPES = new HashSet<NOTETYPE>();
            NOTETYPES1 = new HashSet<NOTETYPE>();
            NUMBERS = new HashSet<NUMBER>();
            OUTTABLES = new HashSet<OUTTABLE>();
            OUTTABLES1 = new HashSet<OUTTABLE>();
            SUBCATEGORies = new HashSet<SUBCATEGORY>();
            TRXTYPES = new HashSet<TRXTYPE>();
            TRXTYPES1 = new HashSet<TRXTYPE>();
        }

        [Key]
        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }

        public int? MAXLENGTH { get; set; }

        [StringLength(1)]
        public string USERDEF { get; set; }

        [StringLength(1)]
        public string USEREDIT { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string ALLOWVAL { get; set; }

        [StringLength(1)]
        public string ADMINLOOKUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT> CLIENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSTATU> DEPTSTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSTATU> DEPTSTATUS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDCLTREF> FUNDCLTREFs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOOKUPVAL> LOOKUPVALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTETYPE> NOTETYPES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTETYPE> NOTETYPES1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUMBER> NUMBERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTTABLE> OUTTABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTTABLE> OUTTABLES1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBCATEGORY> SUBCATEGORies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXTYPE> TRXTYPES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXTYPE> TRXTYPES1 { get; set; }
    }
}
