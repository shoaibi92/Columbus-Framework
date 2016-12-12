namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FROM NND_Report_Client_Stats")]
    public partial class FROM_NND_Report_Client_Stats
    {
        [Key]
        public int UID { get; set; }

        [StringLength(50)]
        public string SystemUser { get; set; }

        public DateTime? ReportRunDate { get; set; }

        public DateTime? ReportDateRangeStart { get; set; }

        public DateTime? ReportDateRangeStop { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(20)]
        public string DeptName { get; set; }

        [StringLength(50)]
        public string Region { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? Territory_ID { get; set; }

        [StringLength(50)]
        public string TerritoryName { get; set; }

        [StringLength(10)]
        public string ServiceType { get; set; }

        [StringLength(50)]
        public string ReferralSource { get; set; }

        [Column(TypeName = "money")]
        public decimal? Revenue { get; set; }

        public int? ActiveClientCount { get; set; }

        public int? ServiceHours { get; set; }

        public int? ServiceMinutes { get; set; }
    }
}
