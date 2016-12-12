namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLINV")]
    public partial class BILLINV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLINV()
        {
            BILLINVNOTES = new HashSet<BILLINVNOTE>();
            BILLPMTS = new HashSet<BILLPMT>();
            BILLPMTS1 = new HashSet<BILLPMT>();
            TRXBATCHTRXDETs = new HashSet<TRXBATCHTRXDET>();
        }

        [Key]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TRX_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(14)]
        public string OASIS_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string INVTYPE { get; set; }

        [Required]
        [StringLength(10)]
        public string INVSUBTYPE { get; set; }

        [Required]
        [StringLength(10)]
        public string INVSTATUS { get; set; }

        public DateTime INVDATE { get; set; }

        public decimal? INVAMT { get; set; }

        public decimal? INVOUTAMT { get; set; }

        public decimal? INVAUXAMT { get; set; }

        [StringLength(40)]
        public string REFNUMBER { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [StringLength(30)]
        public string PAYMETHOD { get; set; }

        [Required]
        [StringLength(1)]
        public string SENT { get; set; }

        public DateTime? SENTDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string EXPORTAR { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(1)]
        public string AUXFLAG { get; set; }

        [StringLength(255)]
        public string AUTHREASON { get; set; }

        public DateTime? EXPORTGL { get; set; }

        [StringLength(30)]
        public string GROUPNUM { get; set; }

        [StringLength(40)]
        public string REFNUMBER2 { get; set; }

        [StringLength(14)]
        public string CLAIMBATCH_ID { get; set; }

        public DateTime? RECEIPTPRINTED { get; set; }

        [StringLength(30)]
        public string RECEIPTNUM { get; set; }

        public decimal? CNTRAMT { get; set; }

        [StringLength(20)]
        public string CASGROUPCODE { get; set; }

        [StringLength(20)]
        public string CASCODE { get; set; }

        public decimal? CASUNITS { get; set; }

        public decimal? CASAMT { get; set; }

        public string PROPS { get; set; }

        public virtual BILLANSI BILLANSI { get; set; }

        public virtual BILLEDX BILLEDX { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual OASIS OASIS { get; set; }

        public virtual TRXTYPE TRXTYPE { get; set; }

        public virtual CLAIMBATCH CLAIMBATCH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINVNOTE> BILLINVNOTES { get; set; }

        public virtual BILLPMI BILLPMI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLPMT> BILLPMTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLPMT> BILLPMTS1 { get; set; }

        public virtual BILLUB92 BILLUB92 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRXDET> TRXBATCHTRXDETs { get; set; }
    }
}
