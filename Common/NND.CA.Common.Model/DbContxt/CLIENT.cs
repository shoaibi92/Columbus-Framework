namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENTS")]
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            BILLINGs = new HashSet<BILLING>();
            BILLINVs = new HashSet<BILLINV>();
            CL_REFNOS = new HashSet<CL_REFNOS>();
            CLNTNOTES = new HashSet<CLNTNOTE>();
            CLTACTCs = new HashSet<CLTACTC>();
            CLTALLERGIES = new HashSet<CLTALLERGy>();
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTATTRIBs = new HashSet<CLTATTRIB>();
            CLTCHANGES = new HashSet<CLTCHANx>();
            CLTDIAGs = new HashSet<CLTDIAG>();
            CLTDOCS = new HashSet<CLTDOC>();
            CLTFOLDERS = new HashSet<CLTFOLDER>();
            CLTLANGs = new HashSet<CLTLANG>();
            CLTLOGs = new HashSet<CLTLOG>();
            CLTMEDS = new HashSet<CLTMED>();
            CLTPATHWAYS = new HashSet<CLTPATHWAY>();
            CLTRULES = new HashSet<CLTRULE>();
            CLTSUBCATS = new HashSet<CLTSUBCAT>();
            CLTSYNCHes = new HashSet<CLTSYNCH>();
            CLTVITALS = new HashSet<CLTVITAL>();
            CONTACTS = new HashSet<CONTACT>();
            DONOTSENDS = new HashSet<DONOTSEND>();
            EMPSERVS = new HashSet<EMPSERV>();
            EQUIPPRES1 = new HashSet<EQUIPPRE>();
            FRMCONTACTs = new HashSet<FRMCONTACT>();
            HAZARDS = new HashSet<HAZARD>();
            INFCONTACTs = new HashSet<INFCONTACT>();
            INFCONTACTs1 = new HashSet<INFCONTACT>();
            INVPERIODS = new HashSet<INVPERIOD>();
            MDS = new HashSet<MD>();
            MEALDIS = new HashSet<MEALDI>();
            MEALSCHEDs = new HashSet<MEALSCHED>();
            MEALSORTs = new HashSet<MEALSORT>();
            MEALVISITS = new HashSet<MEALVISIT>();
            NUTRITIONS = new HashSet<NUTRITION>();
            Oases = new HashSet<OASIS>();
            OVERSERVs = new HashSet<OVERSERV>();
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
            RATECHARTs = new HashSet<RATECHART>();
            REMINDERS = new HashSet<REMINDER>();
            SCHEDULES = new HashSet<SCHEDULE>();
            SCHGROUPS = new HashSet<SCHGROUP>();
            SHIFTCODES = new HashSet<SHIFTCODE>();
            SYNCSERVERLOGs = new HashSet<SYNCSERVERLOG>();
            TRXBATCHTRXes = new HashSet<TRXBATCHTRX>();
            WFTASKS = new HashSet<WFTASK>();
        }

        [Key]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(20)]
        public string MIDDLENAME { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        [StringLength(75)]
        public string ALIAS { get; set; }

        [StringLength(40)]
        public string PERMADDR_1 { get; set; }

        [StringLength(40)]
        public string PERMADDR_2 { get; set; }

        [StringLength(30)]
        public string PERM_CITY { get; set; }

        [StringLength(3)]
        public string PERM_PROV { get; set; }

        [StringLength(10)]
        public string PERM_POST { get; set; }

        [StringLength(30)]
        public string PERM_CNTRY { get; set; }

        [StringLength(12)]
        public string HOME_PHONE { get; set; }

        [StringLength(12)]
        public string WORK_PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        [StringLength(10)]
        public string MARITAL { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(14)]
        public string PRIDOCTOR { get; set; }

        [StringLength(14)]
        public string PRIDIAG { get; set; }

        [StringLength(20)]
        public string REFERRAL { get; set; }

        public DateTime? REF_DATE { get; set; }

        [StringLength(20)]
        public string REF_REASON { get; set; }

        public DateTime? INTAKEDATE { get; set; }

        public DateTime? INTAKETIME { get; set; }

        public DateTime? RES_DATE { get; set; }

        [StringLength(40)]
        public string CURR_ADDR1 { get; set; }

        [StringLength(40)]
        public string CURR_ADDR2 { get; set; }

        [StringLength(30)]
        public string CURR_CITY { get; set; }

        [StringLength(3)]
        public string CURR_PROV { get; set; }

        [StringLength(10)]
        public string CURR_POST { get; set; }

        [StringLength(30)]
        public string CURR_CNTRY { get; set; }

        [StringLength(5)]
        public string AREA { get; set; }

        [StringLength(40)]
        public string EMP_ADDR_1 { get; set; }

        [StringLength(40)]
        public string EMP_ADDR_2 { get; set; }

        [StringLength(30)]
        public string EMP_CITY { get; set; }

        [StringLength(10)]
        public string EMP_POST { get; set; }

        [StringLength(30)]
        public string EMP_CNTRY { get; set; }

        [StringLength(12)]
        public string EMP_PHONE1 { get; set; }

        [StringLength(10)]
        public string EMP_EXT1 { get; set; }

        [StringLength(12)]
        public string EMP_PHONE2 { get; set; }

        [StringLength(20)]
        public string OCCUPATION { get; set; }

        [Column(TypeName = "text")]
        public string DIRCHOME { get; set; }

        [StringLength(20)]
        public string RES_TYPE { get; set; }

        [StringLength(20)]
        public string LIVING_ARR { get; set; }

        public DateTime? ADMISSDATE { get; set; }

        [StringLength(1)]
        public string EQUIPPRES { get; set; }

        [StringLength(14)]
        public string PRICONTACT { get; set; }

        [StringLength(14)]
        public string PRILANG { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(10)]
        public string WORKEXT { get; set; }

        [StringLength(1)]
        public string NOTIFYUSER { get; set; }

        [Column(TypeName = "text")]
        public string DIRPHOME { get; set; }

        [StringLength(1)]
        public string SAMEASPERM { get; set; }

        [StringLength(3)]
        public string EMPPROV { get; set; }

        [StringLength(30)]
        public string EMPPLACE { get; set; }

        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(1)]
        public string ATTENDANCE { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        [StringLength(14)]
        public string ALERT_TYPE_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] VOICE_FILE { get; set; }

        [StringLength(7)]
        public string PIN { get; set; }

        [StringLength(1)]
        public string REFUSAL { get; set; }

        [StringLength(20)]
        public string CURRESTYPE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(1)]
        public string MAILADDR { get; set; }

        public int? REPTYPE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(1)]
        public string VITALS { get; set; }

        [StringLength(1)]
        public string CHECKEDOUT { get; set; }

        [StringLength(14)]
        public string CHKOUTUSER_ID { get; set; }

        [StringLength(30)]
        public string ETHNICITY { get; set; }

        [StringLength(12)]
        public string CCELL { get; set; }

        [StringLength(12)]
        public string CPAGER { get; set; }

        [StringLength(1)]
        public string RELATED { get; set; }

        public DateTime? DECDATE { get; set; }

        [StringLength(1)]
        public string CONSENTGIVEN { get; set; }

        [StringLength(1)]
        public string ESTBIRTHDATE { get; set; }

        [StringLength(30)]
        public string COUNTRYOFBIRTH { get; set; }

        public string PROPS { get; set; }

        [StringLength(20)]
        public string REFRESTYPE { get; set; }

        [StringLength(10)]
        public string TIMEZONE { get; set; }

        [StringLength(1)]
        public string TIMEZONEDAYSAVINGS { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CL_REFNOS> CL_REFNOS { get; set; }

        public virtual USER USER { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual CLTVISITOR CLTVISITOR { get; set; }

        public virtual FRMCONTACT FRMCONTACT { get; set; }

        public virtual INFCONTACT INFCONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTNOTE> CLNTNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTC> CLTACTCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTALLERGy> CLTALLERGIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTATTRIB> CLTATTRIBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTCHANx> CLTCHANGES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDIAG> CLTDIAGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDOC> CLTDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTFOLDER> CLTFOLDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTLANG> CLTLANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTLOG> CLTLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMED> CLTMEDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHWAY> CLTPATHWAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTRULE> CLTRULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUBCAT> CLTSUBCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSYNCH> CLTSYNCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTVITAL> CLTVITALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACT> CONTACTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONOTSEND> DONOTSENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSERV> EMPSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EQUIPPRE> EQUIPPRES1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRMCONTACT> FRMCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HAZARD> HAZARDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVPERIOD> INVPERIODS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD> MDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALDI> MEALDIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHED> MEALSCHEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSORT> MEALSORTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUTRITION> NUTRITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATECHART> RATECHARTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUP> SCHGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFTCODE> SHIFTCODES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYNCSERVERLOG> SYNCSERVERLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRX> TRXBATCHTRXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS { get; set; }
    }
}
