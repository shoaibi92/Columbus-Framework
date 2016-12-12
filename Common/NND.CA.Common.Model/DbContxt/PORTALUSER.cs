namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALUSERS")]
    public partial class PORTALUSER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PORTALUSER()
        {
            PORTALUSERCHANGES = new HashSet<PORTALUSERCHANx>();
            PORTALUSERDEPTS = new HashSet<PORTALUSERDEPT>();
            PORTALUSEREVENTS = new HashSet<PORTALUSEREVENT>();
            PORTALUSERGROUPS = new HashSet<PORTALUSERGROUP>();
            PORTALUSERROLES = new HashSet<PORTALUSERROLE>();
            PORTALUSERSESSIONS = new HashSet<PORTALUSERSESSION>();
            SYSAPPS = new HashSet<SYSAPP>();
        }

        [Key]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(128)]
        public string EMAIL { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [Required]
        [StringLength(128)]
        public string PASSWORD { get; set; }

        [StringLength(255)]
        public string PASSQUESTION { get; set; }

        [StringLength(255)]
        public string PASSANSWER { get; set; }

        [StringLength(1)]
        public string APPROVED { get; set; }

        public DateTime? LASTACTIVITYDATE { get; set; }

        public DateTime? LASTLOGINDATE { get; set; }

        public DateTime? LASTPASSCHGDATE { get; set; }

        [StringLength(1)]
        public string ONLINE { get; set; }

        [StringLength(1)]
        public string LOCKEDOUT { get; set; }

        public int? FAILEDPASSATTEMPTCOUNT { get; set; }

        public DateTime? FAILEDPASSATTEMPTWINDOWSTART { get; set; }

        public int? FAILEDPASSANSWERATTEMPCOUNT { get; set; }

        public DateTime? FAILEDPASSANSWERATTEMPWINDOWSTART { get; set; }

        [StringLength(30)]
        public string LASTNAME { get; set; }

        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        public int? LANGUAGE { get; set; }

        [Column(TypeName = "text")]
        public string PREFS { get; set; }

        [StringLength(1)]
        public string CHGPASS { get; set; }

        [StringLength(1)]
        public string PASSNOEXPIRE { get; set; }

        public DateTime? ACCTSTARTDATE { get; set; }

        public DateTime? ACCTSTOPDATE { get; set; }

        public DateTime? ACCTSTARTTIME { get; set; }

        public DateTime? ACCTSTOPTIME { get; set; }

        [StringLength(1)]
        public string AUTHTYPE { get; set; }

        [StringLength(100)]
        public string AUTHWINUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(10)]
        public string TIMEZONE { get; set; }

        [StringLength(1)]
        public string TIMEZONEDAYSAVINGS { get; set; }

        [StringLength(1)]
        public string USERROLE { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERCHANx> PORTALUSERCHANGES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERDEPT> PORTALUSERDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSEREVENT> PORTALUSEREVENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERGROUP> PORTALUSERGROUPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERROLE> PORTALUSERROLES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERSESSION> PORTALUSERSESSIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSAPP> SYSAPPS { get; set; }
    }
}
