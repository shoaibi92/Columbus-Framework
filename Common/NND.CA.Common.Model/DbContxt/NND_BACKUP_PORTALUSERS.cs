namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_BACKUP_PORTALUSERS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string USERNAME { get; set; }

        [Key]
        [Column(Order = 2)]
        public string EMAIL { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [Key]
        [Column(Order = 3)]
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
    }
}
