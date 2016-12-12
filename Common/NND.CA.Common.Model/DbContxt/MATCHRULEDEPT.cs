namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATCHRULEDEPTS")]
    public partial class MATCHRULEDEPT
    {
        [Key]
        [StringLength(14)]
        public string MATCHRULEDEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string MATCHRULE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public int RULEWEIGHT { get; set; }

        public int SORTORDER { get; set; }

        [Required]
        [StringLength(1)]
        public string RULEREQ { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Column(TypeName = "text")]
        public string RULEDATA { get; set; }

        public int? DROPRATIO { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual MATCHRULE MATCHRULE { get; set; }
    }
}
