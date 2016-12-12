namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_Client_Counts
    {
        [Key]
        public int UID { get; set; }

        [StringLength(50)]
        public string SystemUser { get; set; }

        public DateTime? ReportRunDate { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(35)]
        public string Region { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [StringLength(15)]
        public string ServiceType { get; set; }

        public bool? ServiceTypeIsUsed { get; set; }

        [StringLength(50)]
        public string ReferralSource { get; set; }

        public bool? ReferralSourceIsUsed { get; set; }

        [Column(TypeName = "money")]
        public decimal? Revenue { get; set; }

        public int? ClientwithRevCount { get; set; }

        public int? IntakesCount { get; set; }

        public int? ServiceMinutes { get; set; }

        public int? ServiceHours { get; set; }

        [Column(TypeName = "money")]
        public decimal? AvgServiceRevenuePerHour { get; set; }

        public DateTime? VisitStart { get; set; }

        public DateTime? VisitStop { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        [StringLength(14)]
        public string Client_ID { get; set; }

        [StringLength(14)]
        public string ClientZipPostal { get; set; }

        [StringLength(2)]
        public string ClientStateProv { get; set; }

        [StringLength(50)]
        public string TerritoryName { get; set; }

        public int? Territory_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IntakeDate { get; set; }

        public bool? HadAssessmentStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AssessmentDate { get; set; }

        [StringLength(10)]
        public string CurrentClientStatus { get; set; }

        public bool? IsFirstVisit { get; set; }

        public DateTime? VisitCHGDATE { get; set; }

        [StringLength(255)]
        public string VisitCHGUSER { get; set; }

        public DateTime? visitINTAKE { get; set; }

        [StringLength(255)]
        public string visitINTAKEUSER { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(30)]
        public string CLTLastName { get; set; }

        [StringLength(20)]
        public string CLTFirstName { get; set; }

        public bool? IsMedcan { get; set; }

        [Column(TypeName = "money")]
        public decimal? RevenueStatAdjusted { get; set; }

        [Column(TypeName = "money")]
        public decimal? Expenses { get; set; }

        public byte? IsStatRevenue { get; set; }

        public DateTime? CallMeInvestigateDateTime { get; set; }

        [StringLength(20)]
        public string CallMeInvestigatedBy { get; set; }

        [StringLength(30)]
        public string FunderName { get; set; }

        [StringLength(14)]
        public string Funder_ID { get; set; }

        public DateTime? VisitStartPacificTime { get; set; }

        [StringLength(1)]
        public string VisitStatus { get; set; }

        [StringLength(30)]
        public string ServiceTypeDesc { get; set; }

        [StringLength(5)]
        public string BillUnits { get; set; }

        public decimal? BillRate { get; set; }

        public decimal? BillDur { get; set; }

        [StringLength(50)]
        public string TerritoryStatus { get; set; }

        public DateTime? StartDate1 { get; set; }

        public DateTime? StartDate2 { get; set; }

        public DateTime? StartDate3 { get; set; }

        [StringLength(30)]
        public string EMPLastName { get; set; }

        [StringLength(20)]
        public string EMPFirstName { get; set; }
    }
}
