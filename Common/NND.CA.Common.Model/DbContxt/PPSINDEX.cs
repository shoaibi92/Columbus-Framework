namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PPSINDEX")]
    public partial class PPSINDEX
    {
        [Key]
        [StringLength(14)]
        public string PPS_INDEX_ID { get; set; }

        public decimal PPR { get; set; }

        public decimal LABOR { get; set; }

        public decimal NONLABOR { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        public decimal? PPRRURAL { get; set; }
    }
}
