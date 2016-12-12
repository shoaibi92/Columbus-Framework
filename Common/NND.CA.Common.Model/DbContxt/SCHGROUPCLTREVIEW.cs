namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHGROUPCLTREVIEW")]
    public partial class SCHGROUPCLTREVIEW
    {
        [Key]
        [StringLength(14)]
        public string REVIEW_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string HISTORY_ID { get; set; }

        public DateTime? REVIEWDATE { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        [StringLength(120)]
        public string COMMENTS { get; set; }

        [StringLength(60)]
        public string REVIEWER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual SCHGROUPCLTSTATE SCHGROUPCLTSTATE { get; set; }
    }
}
