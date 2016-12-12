namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTETYPES")]
    public partial class NOTETYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOTETYPE()
        {
            DEPTSTATUS = new HashSet<DEPTSTATU>();
            NOTETYPETPLATES = new HashSet<NOTETYPETPLATE>();
            SPCNTTYPEs = new HashSet<SPCNTTYPE>();
            SYSTEMs = new HashSet<SYSTEM>();
            USERNOTES = new HashSet<USERNOTE>();
            ASSQUESTS = new HashSet<ASSQUEST>();
        }

        [Key]
        [StringLength(14)]
        public string TYPE_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string EDITABLE { get; set; }

        [StringLength(1)]
        public string DELETABLE { get; set; }

        [StringLength(1)]
        public string TRKPROGRESS { get; set; }

        [StringLength(1)]
        public string AUTODELETE { get; set; }

        public int? AUTODELDAYS { get; set; }

        [StringLength(1)]
        public string TEMPEDIT { get; set; }

        public int? TEMPEDITMINS { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(14)]
        public string SUBJLOOKUP_ID { get; set; }

        [StringLength(1)]
        public string ALLOWTIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSTATU> DEPTSTATUS { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual LOOKUP LOOKUP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTETYPETPLATE> NOTETYPETPLATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPCNTTYPE> SPCNTTYPEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSTEM> SYSTEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERNOTE> USERNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }
    }
}
