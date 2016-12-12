namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRXTYPES")]
    public partial class TRXTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRXTYPE()
        {
            BILLINVs = new HashSet<BILLINV>();
            BILLRECS = new HashSet<BILLREC>();
            TRXBATCHes = new HashSet<TRXBATCH>();
            TRXBATCHTRXes = new HashSet<TRXBATCHTRX>();
            TRXBATCHTRXDETs = new HashSet<TRXBATCHTRXDET>();
        }

        [Key]
        [StringLength(14)]
        public string TRX_ID { get; set; }

        [Column("TRXTYPE")]
        [Required]
        [StringLength(10)]
        public string TRXTYPE1 { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(1)]
        public string SYSDEFINED { get; set; }

        [StringLength(80)]
        public string DGLACCT { get; set; }

        [StringLength(80)]
        public string CGLACCT { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [StringLength(255)]
        public string ARCHIVEUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string GLOOKUP_ID { get; set; }

        [StringLength(14)]
        public string CLOOKUP_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual LOOKUP LOOKUP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCH> TRXBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRX> TRXBATCHTRXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRXDET> TRXBATCHTRXDETs { get; set; }
    }
}
