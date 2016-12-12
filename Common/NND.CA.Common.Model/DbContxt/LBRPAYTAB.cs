namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LBRPAYTABS")]
    public partial class LBRPAYTAB
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string AGREE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string PAYTAB_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual LABORAGREE LABORAGREE { get; set; }

        public virtual PAYTABLE PAYTABLE { get; set; }
    }
}
