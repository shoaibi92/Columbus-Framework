namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRXBATCHFUNDERS")]
    public partial class TRXBATCHFUNDER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string TRXBATCH_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual TRXBATCH TRXBATCH { get; set; }
    }
}
