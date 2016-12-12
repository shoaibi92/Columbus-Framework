namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_AppReportRequests
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string ReportName { get; set; }

        [StringLength(40)]
        public string PageLayout { get; set; }

        [StringLength(500)]
        public string ReportEndUserName { get; set; }

        public int? AppReportsCollectionUID { get; set; }

        [StringLength(500)]
        public string TabcmdFolder { get; set; }

        [StringLength(500)]
        public string ReportTargetRootFolder { get; set; }

        [StringLength(2500)]
        public string ReportScriptTemplate { get; set; }

        [StringLength(50)]
        public string RequestUserName { get; set; }

        public DateTime? RequestDateTime { get; set; }

        [StringLength(50)]
        public string RequestComputerName { get; set; }

        [StringLength(150)]
        public string RequestEmailAddress { get; set; }

        public DateTime? ProcessSaveDateTime { get; set; }

        public DateTime? ReportEmailDateTime { get; set; }

        public short? RequestStatus { get; set; }

        [StringLength(50)]
        public string DeptName { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(2500)]
        public string ErrorDescription { get; set; }
    }
}
