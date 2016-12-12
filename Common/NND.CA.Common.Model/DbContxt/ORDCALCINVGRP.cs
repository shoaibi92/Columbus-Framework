namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDCALCINVGRP")]
    public partial class ORDCALCINVGRP
    {
        [Key]
        [StringLength(14)]
        public string INVGRP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string INVGROUPING { get; set; }

        public int? INVNUM { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual ORDCALC ORDCALC { get; set; }
    }
}
