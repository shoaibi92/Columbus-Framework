namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLDEPT")]
    public partial class EMPLDEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLDEPT()
        {
            EMPDATES = new HashSet<EMPDATE>();
            EMPLNOTES = new HashSet<EMPLNOTE>();
            EMPSERVS = new HashSet<EMPSERV>();
            EMPSTATES = new HashSet<EMPSTATE>();
            EMPSUPERS = new HashSet<EMPSUPER>();
            EMPSUPREQs = new HashSet<EMPSUPREQ>();
            PAYRECORDS = new HashSet<PAYRECORD>();
            POSITIONS = new HashSet<POSITION>();
            SCHGROUPEMPS = new HashSet<SCHGROUPEMP>();
            TIMEDUTies = new HashSet<TIMEDUTY>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string PAYLEVEL_ID { get; set; }

        [StringLength(14)]
        public string DEFPAYREC { get; set; }

        public decimal? HRSWORKED { get; set; }

        public decimal? HRSPAID { get; set; }

        [StringLength(14)]
        public string AGREE_ID { get; set; }

        [StringLength(14)]
        public string EMPCAT_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? DATE_IN { get; set; }

        public DateTime? TIME_IN { get; set; }

        [StringLength(255)]
        public string USER_IN { get; set; }

        public DateTime? NXTSUPDATE { get; set; }

        public DateTime? LSTSUPDATE { get; set; }

        public int? FREQUENCY { get; set; }

        [StringLength(20)]
        public string PROGRAM { get; set; }

        [StringLength(20)]
        public string SERVICE { get; set; }

        [StringLength(20)]
        public string SECTION { get; set; }

        [StringLength(20)]
        public string LOCATION { get; set; }

        [StringLength(10)]
        public string PAYROLLNUM { get; set; }

        [StringLength(10)]
        public string HRAPPNUM { get; set; }

        [StringLength(14)]
        public string RECRUITER { get; set; }

        [StringLength(14)]
        public string PROGRESS { get; set; }

        [StringLength(1)]
        public string NOTESEXIST { get; set; }

        [StringLength(1)]
        public string TERMNOTES { get; set; }

        [StringLength(1)]
        public string NEWBRANCH { get; set; }

        [StringLength(1)]
        public string NEWDEPT { get; set; }

        [StringLength(1)]
        public string APPLPREV { get; set; }

        [StringLength(1)]
        public string PREVHIRED { get; set; }

        [Column(TypeName = "text")]
        public string RESCOMNTS { get; set; }

        public DateTime? SENSTART { get; set; }

        public decimal? HRWRKDPROB { get; set; }

        public decimal? HRWRKYEAR { get; set; }

        public decimal? HRSPAIDYR { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        [StringLength(20)]
        public string FILENUM { get; set; }

        public DateTime? INTAKEDATE { get; set; }

        public DateTime? INTAKETIME { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string RECEMPREQ { get; set; }

        [StringLength(1)]
        public string EMPCONFIRM { get; set; }

        [StringLength(10)]
        public string FREQUNITS { get; set; }

        public decimal? NEXTEVAL { get; set; }

        public decimal? AHRSWORKED { get; set; }

        public decimal? AHRSPAID { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string CHKCONFLICTS { get; set; }

        public string PROPS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDATE> EMPDATES { get; set; }

        public virtual RESVI RESVI { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }

        public virtual LBREMPCAT LBREMPCAT { get; set; }

        public virtual PAYLEVEL PAYLEVEL { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLNOTE> EMPLNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSERV> EMPSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSTATE> EMPSTATES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPER> EMPSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPREQ> EMPSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POSITION> POSITIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPEMP> SCHGROUPEMPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMEDUTY> TIMEDUTies { get; set; }
    }
}
