namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RATECHART")]
    public partial class RATECHART
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        public int? PROVIS { get; set; }

        public decimal? PROUNITS { get; set; }

        public int? CHARTVIS { get; set; }

        public decimal? CHARTUNITS { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
