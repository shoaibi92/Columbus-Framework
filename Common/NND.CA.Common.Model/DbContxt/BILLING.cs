namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLING")]
    public partial class BILLING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLING()
        {
            BILLING1 = new HashSet<BILLING>();
            BILLPMTS = new HashSet<BILLPMT>();
            TRXBATCHTRXDETs = new HashSet<TRXBATCHTRXDET>();
        }

        [Key]
        [StringLength(14)]
        public string BILLING_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(1)]
        public string BILLTYPE { get; set; }

        public DateTime? BILLDATE { get; set; }

        public decimal? BILLUNITS { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? BILLAMT { get; set; }

        [Required]
        [StringLength(14)]
        public string SOURCEORD { get; set; }

        [Required]
        [StringLength(14)]
        public string TARGETORD { get; set; }

        [StringLength(30)]
        public string RECREASON { get; set; }

        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [StringLength(10)]
        public string BILLCODE { get; set; }

        public decimal? BILLRATE { get; set; }

        [StringLength(5)]
        public string BILLUNIT { get; set; }

        [StringLength(80)]
        public string ADJCOMMENT { get; set; }

        [StringLength(14)]
        public string ADJMASTREC { get; set; }

        public int? INVNUM { get; set; }

        public int? INVITEM { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string VSTATUS { get; set; }

        [StringLength(14)]
        public string SUMMARY_ID { get; set; }

        [StringLength(1)]
        public string INVOICED { get; set; }

        [StringLength(1)]
        public string CLOSED { get; set; }

        [StringLength(1)]
        public string EXPORTAR { get; set; }

        [StringLength(1)]
        public string TAX1 { get; set; }

        [StringLength(1)]
        public string TAX2 { get; set; }

        public DateTime? INVDATE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(255)]
        public string AUX_ID2 { get; set; }

        [StringLength(1)]
        public string BILLTYPE2 { get; set; }

        [StringLength(14)]
        public string OSOURCEORD { get; set; }

        [StringLength(14)]
        public string SRCPERIOD_ID { get; set; }

        public decimal? BILLOUTAMT { get; set; }

        public decimal? CNTRRATE { get; set; }

        public decimal? CNTRAMT { get; set; }

        [StringLength(14)]
        public string SRCBILLING_ID { get; set; }

        public int? COB { get; set; }

        public int? ROUNDUNITS { get; set; }

        public string PROPS { get; set; }

        [Required]
        [StringLength(1)]
        public string EXPORTAP { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual ORDER ORDER1 { get; set; }

        public virtual ORDER ORDER2 { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual VISIT VISIT { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER1 { get; set; }

        public virtual BILLSUMREC BILLSUMREC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLING1 { get; set; }

        public virtual BILLING BILLING2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLPMT> BILLPMTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRXDET> TRXBATCHTRXDETs { get; set; }
    }
}
