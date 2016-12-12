namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHGROUPCLTSTATES")]
    public partial class SCHGROUPCLTSTATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHGROUPCLTSTATE()
        {
            SCHGROUPCLTREVIEWs = new HashSet<SCHGROUPCLTREVIEW>();
        }

        [Key]
        [StringLength(14)]
        public string HISTORY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(120)]
        public string COMMENTS { get; set; }

        public DateTime? AUXDATE { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        public DateTime? REFDATE { get; set; }

        [StringLength(30)]
        public string REFSOURCE { get; set; }

        [StringLength(120)]
        public string REFDETAIL { get; set; }

        [StringLength(30)]
        public string FAILEDADMISSION { get; set; }

        [StringLength(1)]
        public string ACUTECARE { get; set; }

        [StringLength(30)]
        public string GOALOFCARE { get; set; }

        [StringLength(30)]
        public string GOALNOTMET { get; set; }

        public DateTime? WAITLISTDATE { get; set; }

        [StringLength(30)]
        public string RATINGTOOL { get; set; }

        public int? RATING { get; set; }

        [StringLength(30)]
        public string REFONWARD { get; set; }

        [StringLength(120)]
        public string REFONWARDNOTE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(120)]
        public string FAILEDADMDETAIL { get; set; }

        public string PROPS { get; set; }

        public DateTime? FWRDREFDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPCLTREVIEW> SCHGROUPCLTREVIEWs { get; set; }

        public virtual SCHGROUPCLT SCHGROUPCLT { get; set; }
    }
}
