namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OVERSERV")]
    public partial class OVERSERV
    {
        [Key]
        [StringLength(14)]
        public string OVERSERV_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime? BILLDATE { get; set; }

        public int? RULE_ID { get; set; }

        public decimal? RULEMAX { get; set; }

        public decimal? AMTOVERAGED { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(1)]
        public string BILLTYPE { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual VISIT VISIT { get; set; }

        public virtual RULE RULE { get; set; }
    }
}
