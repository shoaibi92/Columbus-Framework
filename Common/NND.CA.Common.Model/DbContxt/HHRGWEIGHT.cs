namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HHRGWEIGHTS")]
    public partial class HHRGWEIGHT
    {
        [Key]
        [StringLength(14)]
        public string HHRG_ID { get; set; }

        [Required]
        [StringLength(6)]
        public string HHRG { get; set; }

        public decimal WEIGHT { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        public int? THERAPYSTART { get; set; }

        public int? THERAPYSTOP { get; set; }

        public decimal? ESTCOST { get; set; }

        [StringLength(2)]
        public string M0110_EPISODE_TIMING { get; set; }
    }
}
