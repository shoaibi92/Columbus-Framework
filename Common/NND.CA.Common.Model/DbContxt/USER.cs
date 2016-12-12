namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            CLIENTS = new HashSet<CLIENT>();
            CLTSYNCHes = new HashSet<CLTSYNCH>();
            CONTACTS = new HashSet<CONTACT>();
            INVALIDPASSes = new HashSet<INVALIDPASS>();
            LOGUSERs = new HashSet<LOGUSER>();
            REMINDERS = new HashSet<REMINDER>();
            REMINDERS1 = new HashSet<REMINDER>();
            REMOTETEAMS = new HashSet<REMOTETEAM>();
            REMOTETEAMS1 = new HashSet<REMOTETEAM>();
            REPORTTEMPLATES = new HashSet<REPORTTEMPLATE>();
            RPTUSERFOLDs = new HashSet<RPTUSERFOLD>();
            SYNCSERVERs = new HashSet<SYNCSERVER>();
            USERACCESSes = new HashSet<USERACCESS>();
            USERDEPTs = new HashSet<USERDEPT>();
            USERGROUPS = new HashSet<USERGROUP>();
            USERSTATUS = new HashSet<USERSTATU>();
            USERSYNCHes = new HashSet<USERSYNCH>();
            USERVIPCLIENTS = new HashSet<USERVIPCLIENT>();
            WFALERTTASKS = new HashSet<WFALERTTASK>();
            WFALERTTASKS1 = new HashSet<WFALERTTASK>();
            WFTASKS = new HashSet<WFTASK>();
        }

        [Key]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string USERNAME { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [MaxLength(100)]
        public byte[] PASSWRD { get; set; }

        public int? LANGUAGE { get; set; }

        [StringLength(1)]
        public string ACTIVE { get; set; }

        [StringLength(1)]
        public string OT_NOTIFY { get; set; }

        [StringLength(14)]
        public string DEFDEPT { get; set; }

        [StringLength(1)]
        public string PROMPTDEPT { get; set; }

        [StringLength(1)]
        public string ADDDEPT { get; set; }

        [StringLength(1)]
        public string CHKREMIND { get; set; }

        public int? CHKREMMIN { get; set; }

        [StringLength(1)]
        public string NOTEUNFILL { get; set; }

        [StringLength(1)]
        public string DURHRSMIN { get; set; }

        [StringLength(1)]
        public string PRTBILLDUR { get; set; }

        [StringLength(1)]
        public string UPDBILLDUR { get; set; }

        [StringLength(1)]
        public string PRTPAYDUR { get; set; }

        [StringLength(1)]
        public string UPDPAYDUR { get; set; }

        [StringLength(1)]
        public string USEDEFPLAN { get; set; }

        [StringLength(14)]
        public string DEFPLAN { get; set; }

        [StringLength(1)]
        public string USEDEFAREA { get; set; }

        [StringLength(5)]
        public string DEFAREA { get; set; }

        [StringLength(1)]
        public string CLTFIND { get; set; }

        [StringLength(14)]
        public string FINDCREF { get; set; }

        [StringLength(14)]
        public string FINDOFUND { get; set; }

        [StringLength(14)]
        public string FINDOREF { get; set; }

        [StringLength(1)]
        public string EMPFIND { get; set; }

        [StringLength(14)]
        public string FINDEREF { get; set; }

        [StringLength(1)]
        public string DEFSCHED { get; set; }

        public int? DAYSAHEAD { get; set; }

        [StringLength(1)]
        public string ALLPLANS { get; set; }

        [StringLength(1)]
        public string PROMPTAVAIL { get; set; }

        [StringLength(1)]
        public string DISP24H { get; set; }

        [StringLength(1)]
        public string FWDREMIND { get; set; }

        [StringLength(14)]
        public string FWDUSER { get; set; }

        [StringLength(14)]
        public string DEFNOTETYPE { get; set; }

        [StringLength(1)]
        public string FORCESYNCH { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string CHGPASS { get; set; }

        public DateTime? CHGPASSDATE { get; set; }

        [StringLength(1)]
        public string PASSNOEXPIRE { get; set; }

        public DateTime? ACCTSTARTDATE { get; set; }

        public DateTime? ACCTSTOPDATE { get; set; }

        public DateTime? ACCTSTARTTIME { get; set; }

        public DateTime? ACCTSTOPTIME { get; set; }

        [StringLength(1)]
        public string ADMINUSER { get; set; }

        [StringLength(1)]
        public string PROMPTLOG { get; set; }

        [Column(TypeName = "text")]
        public string PROMPTMSG { get; set; }

        [StringLength(1)]
        public string SYNCAUTOACCEPT { get; set; }

        [StringLength(1)]
        public string SYNCAUTOSYNC { get; set; }

        [StringLength(1)]
        public string AUTHTYPE { get; set; }

        [StringLength(60)]
        public string AUTHWINUSER { get; set; }

        [StringLength(1)]
        public string CLTFIND2 { get; set; }

        [StringLength(1)]
        public string EMPFIND2 { get; set; }

        [Column(TypeName = "text")]
        public string FAVORITES { get; set; }

        [StringLength(80)]
        public string EMAIL_SENDERNAME { get; set; }

        [StringLength(80)]
        public string EMAIL_SENDEREMAIL { get; set; }

        [StringLength(80)]
        public string EMAIL_ACCTNAME { get; set; }

        [StringLength(80)]
        public string EMAIL_ACCTPASS { get; set; }

        [StringLength(80)]
        public string EMAIL_SERVERADDR { get; set; }

        public int? EMAIL_SERVERPORT { get; set; }

        [StringLength(1)]
        public string ALWAYSONPOC { get; set; }

        [StringLength(1)]
        public string FORCESYNCTYPE { get; set; }

        [StringLength(1)]
        public string EMAIL_USESSL { get; set; }

        [StringLength(1)]
        public string EMAIL_USEFORDATEDNOTES { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT> CLIENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSYNCH> CLTSYNCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACT> CONTACTS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual FUNDCLTREF FUNDCLTREF { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVALIDPASS> INVALIDPASSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOGUSER> LOGUSERs { get; set; }

        public virtual NUMBER NUMBER { get; set; }

        public virtual NUMBER NUMBER1 { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMOTETEAM> REMOTETEAMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMOTETEAM> REMOTETEAMS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTTEMPLATE> REPORTTEMPLATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RPTUSERFOLD> RPTUSERFOLDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYNCSERVER> SYNCSERVERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERACCESS> USERACCESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERDEPT> USERDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERGROUP> USERGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERSTATU> USERSTATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERSYNCH> USERSYNCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERVIPCLIENT> USERVIPCLIENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS { get; set; }
    }
}
