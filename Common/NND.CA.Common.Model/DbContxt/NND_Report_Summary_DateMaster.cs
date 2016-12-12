namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_Summary_DateMaster
    {
        [Key]
        public int UID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(35)]
        public string Region { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        public int? Territory_ID { get; set; }

        [StringLength(50)]
        public string TerritoryName { get; set; }

        [StringLength(50)]
        public string ReferralSource { get; set; }
    }
}
