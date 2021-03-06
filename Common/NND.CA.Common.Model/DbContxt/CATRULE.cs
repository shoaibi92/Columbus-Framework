namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATRULES")]
    public partial class CATRULE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMPCAT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string RULE_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual LBRRULE LBRRULE { get; set; }

        public virtual EMPCAT EMPCAT { get; set; }
    }
}
