namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FinDashboardRevBenchmarks
    {
        [Key]
        public int UID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FYStartDate { get; set; }

        [StringLength(20)]
        public string Dept_ID { get; set; }

        [StringLength(2)]
        public string Tier { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth01 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth02 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth03 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth04 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth05 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth06 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth07 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth08 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth09 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth10 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth11 { get; set; }

        [Column(TypeName = "money")]
        public decimal? BenchMonth12 { get; set; }

        public int? ArchiveID { get; set; }

        [StringLength(100)]
        public string ArchiveName { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTimeStamp { get; set; }
    }
}
