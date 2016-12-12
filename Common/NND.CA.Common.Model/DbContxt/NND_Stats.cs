namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Stats
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Grouping1 { get; set; }

        [StringLength(50)]
        public string Grouping2 { get; set; }

        [StringLength(50)]
        public string Grouping3 { get; set; }

        [StringLength(50)]
        public string RowDesc { get; set; }

        [StringLength(50)]
        public string Value1 { get; set; }

        [StringLength(50)]
        public string Value2 { get; set; }

        [StringLength(50)]
        public string Value3 { get; set; }

        [StringLength(50)]
        public string Value4 { get; set; }

        [StringLength(50)]
        public string Value5 { get; set; }

        [StringLength(50)]
        public string Value6 { get; set; }

        [StringLength(50)]
        public string Value7 { get; set; }

        [StringLength(50)]
        public string Value8 { get; set; }

        [StringLength(50)]
        public string Value9 { get; set; }

        [StringLength(50)]
        public string Value10 { get; set; }

        [StringLength(50)]
        public string Value11 { get; set; }

        [StringLength(50)]
        public string Value12 { get; set; }

        [StringLength(50)]
        public string Value13 { get; set; }

        [StringLength(50)]
        public string Value14 { get; set; }

        public DateTime? DateStamp { get; set; }

        public int? ArchiveID { get; set; }

        [StringLength(50)]
        public string StatType { get; set; }

        [StringLength(50)]
        public string YTDBench1 { get; set; }

        [StringLength(50)]
        public string YTDBench2 { get; set; }

        [StringLength(50)]
        public string YTDBench3 { get; set; }

        [StringLength(50)]
        public string YTDBench4 { get; set; }

        [StringLength(50)]
        public string YTDBench5 { get; set; }

        [StringLength(50)]
        public string YTDBench6 { get; set; }

        [StringLength(50)]
        public string YTDBench7 { get; set; }

        [StringLength(50)]
        public string YTDBench8 { get; set; }

        [StringLength(50)]
        public string YTDBench9 { get; set; }

        [StringLength(50)]
        public string YTDBench10 { get; set; }

        [StringLength(50)]
        public string YTDBench11 { get; set; }

        [StringLength(50)]
        public string YTDBench12 { get; set; }
    }
}
