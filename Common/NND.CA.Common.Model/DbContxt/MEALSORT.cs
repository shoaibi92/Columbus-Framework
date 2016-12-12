namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALSORT")]
    public partial class MEALSORT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public decimal SORTORDER { get; set; }

        [StringLength(1)]
        public string SORTDONE { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual ROUTE ROUTE { get; set; }
    }
}
