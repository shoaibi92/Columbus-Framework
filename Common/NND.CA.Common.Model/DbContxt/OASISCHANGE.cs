namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OASISCHANGE")]
    public partial class OASISCHANGE
    {
        [Key]
        [StringLength(14)]
        public string OASISCHG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string OASIS_ID { get; set; }

        [StringLength(6)]
        public string HHRG { get; set; }

        [StringLength(5)]
        public string HIPPS { get; set; }

        public decimal? PPSTOTAL { get; set; }

        public DateTime? LOCKDATE { get; set; }

        public int? CORRECTION_NUM { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual OASIS OASIS { get; set; }
    }
}
