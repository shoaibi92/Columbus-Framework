namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDRULES")]
    public partial class ORDRULE
    {
        [Key]
        [StringLength(14)]
        public string ORDRULE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        public int RULE_ID { get; set; }

        public decimal RULEMAX { get; set; }

        [StringLength(30)]
        public string SERVAUTH { get; set; }

        public DateTime EFFDATE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? EXPDATE { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual RULE RULE { get; set; }
    }
}
