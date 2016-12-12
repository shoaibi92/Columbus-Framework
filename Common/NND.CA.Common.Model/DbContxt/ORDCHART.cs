namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDCHART")]
    public partial class ORDCHART
    {
        [Key]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        public int? PROVIS { get; set; }

        public int? CHARTVIS { get; set; }

        public decimal? PROUNITS { get; set; }

        public decimal? CHARTUNITS { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
