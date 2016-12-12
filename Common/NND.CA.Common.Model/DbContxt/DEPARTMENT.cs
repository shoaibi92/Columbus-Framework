namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPARTMENTS")]
    public partial class DEPARTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT()
        {
            AUTOORDPLANs = new HashSet<AUTOORDPLAN>();
            AVONETIMES = new HashSet<AVONETIME>();
            AVROTATEs = new HashSet<AVROTATE>();
            AVROTEMPs = new HashSet<AVROTEMP>();
            BILLINGs = new HashSet<BILLING>();
            BILLTABLES = new HashSet<BILLTABLE>();
            CLAIMBATCHes = new HashSet<CLAIMBATCH>();
            CLNTNOTES = new HashSet<CLNTNOTE>();
            CLNTRESORCs = new HashSet<CLNTRESORC>();
            CLTACTCs = new HashSet<CLTACTC>();
            CLTDEPTs = new HashSet<CLTDEPT>();
            CLTDIAGs = new HashSet<CLTDIAG>();
            CLTLOGs = new HashSet<CLTLOG>();
            CLTSUBCATS = new HashSet<CLTSUBCAT>();
            DEPTAGREEs = new HashSet<DEPTAGREE>();
            DEPTAREAS = new HashSet<DEPTAREA>();
            DEPTASSESSes = new HashSet<DEPTASSESS>();
            DEPTAVROTs = new HashSet<DEPTAVROT>();
            DEPTBILLTABLES = new HashSet<DEPTBILLTABLE>();
            DEPTNUMS = new HashSet<DEPTNUM>();
            DEPTPERIODs = new HashSet<DEPTPERIOD>();
            DEPTPLANS = new HashSet<DEPTPLAN>();
            DEPTREFS = new HashSet<DEPTREF>();
            DEPTSCHGROUPS = new HashSet<DEPTSCHGROUP>();
            DEPTSERVs = new HashSet<DEPTSERV>();
            DEPTSRVREQs = new HashSet<DEPTSRVREQ>();
            DEPTSTATUS = new HashSet<DEPTSTATU>();
            DISTRICTS = new HashSet<DISTRICT>();
            DOCTYPEDEPTS = new HashSet<DOCTYPEDEPT>();
            EDCVARIANCES = new HashSet<EDCVARIANCE>();
            EMPLDEPTs = new HashSet<EMPLDEPT>();
            EMPLNOTES = new HashSet<EMPLNOTE>();
            EMPLOGs = new HashSet<EMPLOG>();
            EMPSUBCATS = new HashSet<EMPSUBCAT>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            FRMCONTACTs = new HashSet<FRMCONTACT>();
            FUNDDEPTs = new HashSet<FUNDDEPT>();
            INFCONTACTs = new HashSet<INFCONTACT>();
            KITCHENS = new HashSet<KITCHEN>();
            MATCHRULEDEPTS = new HashSet<MATCHRULEDEPT>();
            MEALPLANs = new HashSet<MEALPLAN>();
            MEALSCHEDs = new HashSet<MEALSCHED>();
            MEALVISITS = new HashSet<MEALVISIT>();
            OVERSERVs = new HashSet<OVERSERV>();
            PATHWAYDEPTS = new HashSet<PATHWAYDEPT>();
            PORTALUSERDEPTS = new HashSet<PORTALUSERDEPT>();
            REQDEFS = new HashSet<REQDEF>();
            ROUTESCHEDs = new HashSet<ROUTESCHED>();
            SCHEDULES = new HashSet<SCHEDULE>();
            SYSAPPSDEPTs = new HashSet<SYSAPPSDEPT>();
            TRXBATCHes = new HashSet<TRXBATCH>();
            USERDEPTs = new HashSet<USERDEPT>();
            USERS = new HashSet<USER>();
            VALIDSUPERs = new HashSet<VALIDSUPER>();
            WFALERTDEPTS = new HashSet<WFALERTDEPT>();
            CONTACTS = new HashSet<CONTACT>();
        }

        [Key]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(14)]
        public string PAYROLL { get; set; }

        [StringLength(14)]
        public string PAYTABLE { get; set; }

        [StringLength(1)]
        public string CLIENTSTAT { get; set; }

        [StringLength(1)]
        public string EMPSTAT { get; set; }

        [StringLength(1)]
        public string PROMPTCONT { get; set; }

        [StringLength(1)]
        public string EMPCONFIRM { get; set; }

        [StringLength(1)]
        public string CLTCONFIRM { get; set; }

        public DateTime? SCHEDSTART { get; set; }

        public DateTime? SCHEDEND { get; set; }

        public DateTime? SCHEDNEXT { get; set; }

        public DateTime? GENDATE { get; set; }

        public DateTime? GENTIME { get; set; }

        public int? GENFRQ { get; set; }

        [StringLength(1)]
        public string GENFRQUNIT { get; set; }

        public int? GENDAYS { get; set; }

        [StringLength(1)]
        public string EMPFLICT { get; set; }

        [StringLength(1)]
        public string CLTFLICT { get; set; }

        [StringLength(1)]
        public string ORDFLICT { get; set; }

        [StringLength(1)]
        public string USEGENLOG { get; set; }

        [StringLength(1)]
        public string USEPLUNFIL { get; set; }

        [StringLength(1)]
        public string USEPLEMPC { get; set; }

        [StringLength(1)]
        public string USECLTDBK { get; set; }

        [StringLength(1)]
        public string USECLTSTAT { get; set; }

        [StringLength(1)]
        public string USECLTHOLD { get; set; }

        [StringLength(1)]
        public string USECLTDNSD { get; set; }

        [StringLength(12)]
        public string PRI_PHONE { get; set; }

        [StringLength(12)]
        public string SEC_PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(40)]
        public string ADDRESS_2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(1)]
        public string DEFSENSORT { get; set; }

        [StringLength(1)]
        public string UPTKDUR { get; set; }

        public DateTime? STARTDATE { get; set; }

        [StringLength(14)]
        public string DEFAGREE { get; set; }

        [StringLength(5)]
        public string FACCODE { get; set; }

        public int? DEFWEEK { get; set; }

        [StringLength(1)]
        public string DEFAVACT { get; set; }

        [StringLength(14)]
        public string DEFAVPLAN { get; set; }

        [StringLength(1)]
        public string DEFAVEMP { get; set; }

        [StringLength(40)]
        public string COMPNAME { get; set; }

        [StringLength(1)]
        public string USEADDR { get; set; }

        [StringLength(1)]
        public string USECLP { get; set; }

        [StringLength(14)]
        public string EMPACTLOOK { get; set; }

        [StringLength(14)]
        public string EMPAPPLOOK { get; set; }

        [StringLength(14)]
        public string EMPHLDLOOK { get; set; }

        [StringLength(14)]
        public string EMPPROLOOK { get; set; }

        [StringLength(14)]
        public string EMPTRMLOOK { get; set; }

        [StringLength(14)]
        public string CLTACTLOOK { get; set; }

        [StringLength(14)]
        public string CLTDISLOOK { get; set; }

        [StringLength(14)]
        public string CLTHLDLOOK { get; set; }

        [StringLength(14)]
        public string CLTASSLOOK { get; set; }

        [StringLength(14)]
        public string CLTTRFLOOK { get; set; }

        [StringLength(14)]
        public string CLTWTLLOOK { get; set; }

        [StringLength(14)]
        public string CLTTRMLOOK { get; set; }

        [StringLength(1)]
        public string NOTESTATUS { get; set; }

        [StringLength(14)]
        public string EMPHLDNOTE { get; set; }

        [StringLength(14)]
        public string EMPTRMNOTE { get; set; }

        [StringLength(14)]
        public string CLTDISNOTE { get; set; }

        [StringLength(14)]
        public string CLTHLDNOTE { get; set; }

        [StringLength(14)]
        public string CLTTRFNOTE { get; set; }

        [StringLength(14)]
        public string CLTTRMNOTE { get; set; }

        [StringLength(14)]
        public string ORDHLDNOTE { get; set; }

        [StringLength(14)]
        public string ORDTRMNOTE { get; set; }

        [StringLength(14)]
        public string CLTWTLNOTE { get; set; }

        [StringLength(1)]
        public string LBRALLDEPT { get; set; }

        [StringLength(1)]
        public string TAX1USE { get; set; }

        [StringLength(20)]
        public string TAX1DESCR { get; set; }

        public decimal? TAX1VAL { get; set; }

        [StringLength(40)]
        public string TAX1GL { get; set; }

        [StringLength(20)]
        public string TAX1NUM { get; set; }

        [StringLength(1)]
        public string TAX2USE { get; set; }

        [StringLength(20)]
        public string TAX2DESCR { get; set; }

        public decimal? TAX2VAL { get; set; }

        [StringLength(40)]
        public string TAX2GL { get; set; }

        [StringLength(20)]
        public string TAX2NUM { get; set; }

        [StringLength(1)]
        public string CFTOPLAN { get; set; }

        [StringLength(14)]
        public string CFPLANNER_ID { get; set; }

        [StringLength(1)]
        public string CFCLTPLAN { get; set; }

        [StringLength(30)]
        public string CLASTNAME { get; set; }

        [StringLength(20)]
        public string CFIRSTNAME { get; set; }

        [StringLength(10)]
        public string EXTENSION { get; set; }

        [StringLength(1)]
        public string AUTOORDERS { get; set; }

        [StringLength(1)]
        public string AUTOORDERPMT { get; set; }

        [StringLength(14)]
        public string AUTOSFUNDER_ID { get; set; }

        [StringLength(40)]
        public string AUTOSDESCR { get; set; }

        [StringLength(1)]
        public string AUTOTARGET { get; set; }

        [StringLength(14)]
        public string AUTOTFUNDER_ID { get; set; }

        [StringLength(40)]
        public string AUTOTDESCR { get; set; }

        [StringLength(1)]
        public string BCCAREPLAN { get; set; }

        [StringLength(1)]
        public string BCEXPENSES { get; set; }

        [StringLength(1)]
        public string CHKSERVPLAN { get; set; }

        [StringLength(1)]
        public string ADMINDEPT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string GVTOPLAN { get; set; }

        [StringLength(14)]
        public string GVPLANNER_ID { get; set; }

        [StringLength(1)]
        public string GVCLTPLAN { get; set; }

        [StringLength(1)]
        public string AUTOTTARGET { get; set; }

        [StringLength(14)]
        public string AUTOTTFUNDER_ID { get; set; }

        [StringLength(40)]
        public string AUTOTTDESCR { get; set; }

        [StringLength(1)]
        public string CHKDEPTDBLBOOK { get; set; }

        [StringLength(1)]
        public string CFPLANONETIME { get; set; }

        [StringLength(1)]
        public string CFPLANUNFILLED { get; set; }

        [StringLength(1)]
        public string CHKORDRULES { get; set; }

        public string PROPS { get; set; }

        public byte[] LOGO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOORDPLAN> AUTOORDPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVONETIME> AVONETIMES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVROTATE> AVROTATEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVROTEMP> AVROTEMPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLTABLE> BILLTABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLAIMBATCH> CLAIMBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTNOTE> CLNTNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTRESORC> CLNTRESORCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTC> CLTACTCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDIAG> CLTDIAGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTLOG> CLTLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUBCAT> CLTSUBCATS { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual FUNDER FUNDER1 { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }

        public virtual PAYTABLE PAYTABLE1 { get; set; }

        public virtual LABORAGREE LABORAGREE { get; set; }

        public virtual EXPPAYROLL EXPPAYROLL { get; set; }

        public virtual FUNDER FUNDER2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTAGREE> DEPTAGREEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTAREA> DEPTAREAS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTASSESS> DEPTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTAVROT> DEPTAVROTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTBILLTABLE> DEPTBILLTABLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTNUM> DEPTNUMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTPERIOD> DEPTPERIODs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTPLAN> DEPTPLANS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTREF> DEPTREFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSCHGROUP> DEPTSCHGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSERV> DEPTSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSRVREQ> DEPTSRVREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSTATU> DEPTSTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISTRICT> DISTRICTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTYPEDEPT> DOCTYPEDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCVARIANCE> EDCVARIANCES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLNOTE> EMPLNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOG> EMPLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUBCAT> EMPSUBCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRMCONTACT> FRMCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KITCHEN> KITCHENS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATCHRULEDEPT> MATCHRULEDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPLAN> MEALPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHED> MEALSCHEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHWAYDEPT> PATHWAYDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERDEPT> PORTALUSERDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQDEF> REQDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTESCHED> ROUTESCHEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSAPPSDEPT> SYSAPPSDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCH> TRXBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERDEPT> USERDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VALIDSUPER> VALIDSUPERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTDEPT> WFALERTDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACT> CONTACTS { get; set; }
    }
}
