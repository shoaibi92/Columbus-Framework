namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEES")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            AVONETIMES = new HashSet<AVONETIME>();
            AVROTATEs = new HashSet<AVROTATE>();
            AVROTEMPs = new HashSet<AVROTEMP>();
            BILLINGs = new HashSet<BILLING>();
            BILLRECS = new HashSet<BILLREC>();
            CLTMEDS = new HashSet<CLTMED>();
            DONOTSENDS = new HashSet<DONOTSEND>();
            DRORDERS = new HashSet<DRORDER>();
            EDCCALLS = new HashSet<EDCCALL>();
            EMPATTRIBs = new HashSet<EMPATTRIB>();
            EMPCHANGES = new HashSet<EMPCHANx>();
            EMPCONTACTS = new HashSet<EMPCONTACT>();
            EMPDISTs = new HashSet<EMPDIST>();
            EMPDOCS = new HashSet<EMPDOC>();
            EMPFOLDERS = new HashSet<EMPFOLDER>();
            EMPFRMS = new HashSet<EMPFRM>();
            EMPLANGs = new HashSet<EMPLANG>();
            EMPLNOTES = new HashSet<EMPLNOTE>();
            EMPLOGs = new HashSet<EMPLOG>();
            EMPREFNOS = new HashSet<EMPREFNO>();
            EMPROUTES = new HashSet<EMPROUTE>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            OVERSERVs = new HashSet<OVERSERV>();
            REMINDERS = new HashSet<REMINDER>();
            ROUTEDDEFS = new HashSet<ROUTEDDEF>();
            ROUTESDEFS = new HashSet<ROUTESDEF>();
            SCHGROUPS = new HashSet<SCHGROUP>();
            SCHGROUPS1 = new HashSet<SCHGROUP>();
            VISITOFFERS = new HashSet<VISITOFFER>();
            VISITS = new HashSet<VISIT>();
            WFTASKS = new HashSet<WFTASK>();
        }

        [Key]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(20)]
        public string MIDDLENAME { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(12)]
        public string HOMEPHONE { get; set; }

        [StringLength(12)]
        public string WORKPHONE { get; set; }

        [StringLength(12)]
        public string CELLPHONE { get; set; }

        [StringLength(12)]
        public string PAGERNUM { get; set; }

        [StringLength(14)]
        public string PRILANG { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        [StringLength(10)]
        public string MARITAL { get; set; }

        [StringLength(5)]
        public string AREA { get; set; }

        [StringLength(1)]
        public string IS_USER { get; set; }

        [StringLength(40)]
        public string CURR_ADDR1 { get; set; }

        [StringLength(40)]
        public string CURR_ADDR2 { get; set; }

        [StringLength(30)]
        public string CURR_CITY { get; set; }

        [StringLength(3)]
        public string CURR_PROV { get; set; }

        [StringLength(30)]
        public string CURR_CNTRY { get; set; }

        [StringLength(10)]
        public string CURR_POST { get; set; }

        public DateTime? RES_DATE { get; set; }

        [StringLength(40)]
        public string PERMADDR_1 { get; set; }

        [StringLength(40)]
        public string PERMADDR_2 { get; set; }

        [StringLength(30)]
        public string PERM_CITY { get; set; }

        [StringLength(3)]
        public string PERM_PROV { get; set; }

        [StringLength(30)]
        public string PERM_CNTRY { get; set; }

        [StringLength(10)]
        public string PERM_POST { get; set; }

        [StringLength(1)]
        public string SAMEASPERM { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(75)]
        public string ALIAS { get; set; }

        public int? BIRTHMONTH { get; set; }

        public int? BIRTHDAY { get; set; }

        [StringLength(10)]
        public string WORKEXT { get; set; }

        [StringLength(12)]
        public string VOICEMAIL { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? INTAKEDATE { get; set; }

        public DateTime? INTAKETIME { get; set; }

        [StringLength(20)]
        public string PLACEEMP { get; set; }

        [StringLength(20)]
        public string TITLEEMP { get; set; }

        [StringLength(40)]
        public string ADDREMP { get; set; }

        [Column(TypeName = "text")]
        public string DIRCHOME { get; set; }

        [Column(TypeName = "text")]
        public string DIRPHOME { get; set; }

        [StringLength(1)]
        public string ISSUPER { get; set; }

        public decimal? TEMPRATE { get; set; }

        [StringLength(14)]
        public string ALERT_TYPE_ID { get; set; }

        [StringLength(6)]
        public string PIN { get; set; }

        [StringLength(4)]
        public string VERIFY_CODE { get; set; }

        [StringLength(1)]
        public string VISIT_MODE { get; set; }

        [StringLength(1)]
        public string BATCH_MODE { get; set; }

        [Column(TypeName = "image")]
        public byte[] VOICE_FILE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(1)]
        public string MAILADDR { get; set; }

        public int? REPTYPE { get; set; }

        [StringLength(1)]
        public string EDCENABLED { get; set; }

        [StringLength(10)]
        public string EDCTIMEZONE { get; set; }

        [StringLength(1)]
        public string EDCDAYSAVINGS { get; set; }

        [StringLength(1)]
        public string ENOTIFY { get; set; }

        [StringLength(1)]
        public string EDCMILEAGE { get; set; }

        [StringLength(1)]
        public string EDCACTIVITIES { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string OFFERCOMMMODE { get; set; }

        public string PROPS { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVONETIME> AVONETIMES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVROTATE> AVROTATEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVROTEMP> AVROTEMPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMED> CLTMEDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONOTSEND> DONOTSENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRORDER> DRORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCCALL> EDCCALLS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPATTRIB> EMPATTRIBs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPCHANx> EMPCHANGES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPCONTACT> EMPCONTACTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDIST> EMPDISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDOC> EMPDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFOLDER> EMPFOLDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLANG> EMPLANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLNOTE> EMPLNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOG> EMPLOGs { get; set; }

        public virtual RESOURCE RESOURCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPREFNO> EMPREFNOS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPROUTE> EMPROUTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDDEF> ROUTEDDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTESDEF> ROUTESDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUP> SCHGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUP> SCHGROUPS1 { get; set; }

        public virtual SUPERVISOR SUPERVISOR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISITOFFER> VISITOFFERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS { get; set; }
    }
}
