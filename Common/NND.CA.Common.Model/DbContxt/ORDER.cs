namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            BILLINGs = new HashSet<BILLING>();
            BILLINGs1 = new HashSet<BILLING>();
            BILLINGs2 = new HashSet<BILLING>();
            BILLINVs = new HashSet<BILLINV>();
            BILLRECS = new HashSet<BILLREC>();
            BILLSUMRECs = new HashSet<BILLSUMREC>();
            CLTACTCs = new HashSet<CLTACTC>();
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTDEPTs = new HashSet<CLTDEPT>();
            CLTPATHVISITS = new HashSet<CLTPATHVISIT>();
            CLTSERVS = new HashSet<CLTSERV>();
            DRORDERS = new HashSet<DRORDER>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            FUNDORDVALs = new HashSet<FUNDORDVAL>();
            MEALSCHEDs = new HashSet<MEALSCHED>();
            MEALVISITS = new HashSet<MEALVISIT>();
            Oases = new HashSet<OASIS>();
            ORDCALCs = new HashSet<ORDCALC>();
            ORDCCRULES = new HashSet<ORDCCRULE>();
            ORDDATES = new HashSet<ORDDATE>();
            ORDEXCEEDs = new HashSet<ORDEXCEED>();
            ORDPLANs = new HashSet<ORDPLAN>();
            ORDRULES = new HashSet<ORDRULE>();
            ORDSTATHISTs = new HashSet<ORDSTATHIST>();
            OVERSERVs = new HashSet<OVERSERV>();
            TRXBATCHTRXes = new HashSet<TRXBATCHTRX>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        [StringLength(14)]
        public string DEFRATE { get; set; }

        [StringLength(60)]
        public string AUTH_NO { get; set; }

        [StringLength(1)]
        public string HRSLEVEL { get; set; }

        public DateTime? RECDATE { get; set; }

        public DateTime? CNTRCTDATE { get; set; }

        public DateTime? CAREDATE { get; set; }

        [StringLength(1)]
        public string USEOR { get; set; }

        [StringLength(1)]
        public string USEORORD { get; set; }

        [StringLength(14)]
        public string ORORDER { get; set; }

        [StringLength(2)]
        public string ORCODETYPE { get; set; }

        [StringLength(14)]
        public string ORFUNDCODE { get; set; }

        [StringLength(1)]
        public string CANEXCEED { get; set; }

        public decimal? EXCEEDAMT { get; set; }

        [StringLength(1)]
        public string USECC { get; set; }

        [StringLength(14)]
        public string CCORDER { get; set; }

        [StringLength(2)]
        public string CCCODETYPE { get; set; }

        [StringLength(14)]
        public string CCFUNDRATE { get; set; }

        [StringLength(1)]
        public string USEEB { get; set; }

        public decimal? EBVALUE { get; set; }

        public int? EBRULE { get; set; }

        [StringLength(14)]
        public string EBORDER { get; set; }

        [StringLength(2)]
        public string EBCODETYPE { get; set; }

        [StringLength(14)]
        public string EBFUNDRATE { get; set; }

        [StringLength(1)]
        public string USERB { get; set; }

        public decimal? RBVALUE { get; set; }

        public int? RBRULE { get; set; }

        [StringLength(2)]
        public string RBCODETYPE { get; set; }

        [StringLength(14)]
        public string RBFUNDRATE { get; set; }

        [StringLength(1)]
        public string USETAXONE { get; set; }

        [StringLength(1)]
        public string USETAXTWO { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string ESSERVICE { get; set; }

        [StringLength(1)]
        public string STATSERV { get; set; }

        [StringLength(1)]
        public string USEXVISDAY { get; set; }

        public int? XVISDAY { get; set; }

        [StringLength(10)]
        public string CPREFIX { get; set; }

        [StringLength(30)]
        public string CLAST { get; set; }

        [StringLength(20)]
        public string CFIRST { get; set; }

        [StringLength(12)]
        public string CPHONE { get; set; }

        [StringLength(10)]
        public string CEXT { get; set; }

        [StringLength(12)]
        public string RPHONE { get; set; }

        [StringLength(12)]
        public string RFAX { get; set; }

        [StringLength(40)]
        public string RADDR1 { get; set; }

        [StringLength(40)]
        public string RADDR2 { get; set; }

        [StringLength(30)]
        public string RCITY { get; set; }

        [StringLength(3)]
        public string RPROV { get; set; }

        [StringLength(30)]
        public string RCOUNTRY { get; set; }

        [StringLength(10)]
        public string RPOSTAL { get; set; }

        [StringLength(1)]
        public string SAMEASREG { get; set; }

        [StringLength(12)]
        public string BPHONE { get; set; }

        [StringLength(12)]
        public string BFAX { get; set; }

        [StringLength(40)]
        public string BADDR1 { get; set; }

        [StringLength(40)]
        public string BADDR2 { get; set; }

        [StringLength(30)]
        public string BCITY { get; set; }

        [StringLength(3)]
        public string BPROV { get; set; }

        [StringLength(30)]
        public string BCOUNTRY { get; set; }

        [StringLength(10)]
        public string BPOSTAL { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public int? EXCTIMES { get; set; }

        [StringLength(1)]
        public string LVLVISITS { get; set; }

        [StringLength(30)]
        public string GLACCT { get; set; }

        [StringLength(1)]
        public string CLTADDRESS { get; set; }

        [StringLength(20)]
        public string COORDNAME { get; set; }

        [StringLength(12)]
        public string COORDPHONE { get; set; }

        [StringLength(10)]
        public string COORDEXT { get; set; }

        [StringLength(1)]
        public string SAP { get; set; }

        [StringLength(1)]
        public string SIP { get; set; }

        [StringLength(1)]
        public string FIP { get; set; }

        [StringLength(1)]
        public string WARVET { get; set; }

        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        [StringLength(14)]
        public string COPYINV_ID { get; set; }

        [StringLength(1)]
        public string COPYINVTYPE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(5)]
        public string MSACODE { get; set; }

        [StringLength(14)]
        public string RECERTORD { get; set; }

        public DateTime? SOCDATE { get; set; }

        public DateTime? VSOCDATE { get; set; }

        [StringLength(1)]
        public string KNOWNLUPA { get; set; }

        [StringLength(1)]
        public string HOLDCLAIM { get; set; }

        public int? ORDSEQ { get; set; }

        public string PROPS { get; set; }

        public int? ELECTIONSEQ { get; set; }

        public int? PAYERSEQ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLSUMREC> BILLSUMRECs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTC> CLTACTCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSERV> CLTSERVS { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRORDER> DRORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDORDVAL> FUNDORDVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHED> MEALSCHEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDCALC> ORDCALCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDCCRULE> ORDCCRULES { get; set; }

        public virtual ORDCHART ORDCHART { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDDATE> ORDDATES { get; set; }

        public virtual RULE RULE { get; set; }

        public virtual RULE RULE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEXCEED> ORDEXCEEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDPLAN> ORDPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDRULE> ORDRULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDSTATHIST> ORDSTATHISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRX> TRXBATCHTRXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
