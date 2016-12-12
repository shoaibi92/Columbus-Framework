namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CompetitorBenchmarks
    {
        public int ID { get; set; }

        [StringLength(40)]
        public string CompetitorName { get; set; }

        [Column(TypeName = "money")]
        public decimal? Year1Rev { get; set; }

        [Column(TypeName = "money")]
        public decimal? Year2Rev { get; set; }

        [Column(TypeName = "money")]
        public decimal? Year3Rev { get; set; }

        public int? GrossMargin { get; set; }
    }
}
