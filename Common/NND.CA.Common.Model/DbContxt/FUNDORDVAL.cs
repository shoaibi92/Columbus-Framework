namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDORDVAL")]
    public partial class FUNDORDVAL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string REF_ID { get; set; }

        public DateTime? DATEVAL { get; set; }

        [StringLength(30)]
        public string TEXTVAL { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual FUNDCLTREF FUNDCLTREF { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
