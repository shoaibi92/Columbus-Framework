namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTRULES")]
    public partial class CLTRULE
    {
        [Key]
        [StringLength(14)]
        public string CLTRULE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string RULELOOKUPVAL_ID { get; set; }

        public int? RULE_ID { get; set; }

        public decimal RULEMAX { get; set; }

        public DateTime EFFDATE { get; set; }

        public DateTime? EXPDATE { get; set; }

        public DateTime? REVIEWDATE { get; set; }

        [StringLength(30)]
        public string SERVAUTH { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
