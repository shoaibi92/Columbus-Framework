namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MonthRevBenchmarks
    {
        public int ID { get; set; }

        public int? MonthCount { get; set; }

        [Column(TypeName = "money")]
        public decimal? RevBenchmark { get; set; }
    }
}
