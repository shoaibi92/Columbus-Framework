namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_AppSettings
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string TabcmdFolder { get; set; }

        [StringLength(40)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(300)]
        public string TableauServerName { get; set; }

        [StringLength(500)]
        public string ReportTargetRootFolder { get; set; }

        [StringLength(2500)]
        public string ReportScriptTemplate { get; set; }

        [StringLength(200)]
        public string smtpServerName { get; set; }

        [StringLength(200)]
        public string ReportCopyMailbox { get; set; }

        [StringLength(200)]
        public string ReportSendFromAddress { get; set; }

        public int? ReportAppStatus { get; set; }

        [StringLength(2500)]
        public string ReportAppStatusDescription { get; set; }

        public DateTime? ReportAppStatusDateStamp { get; set; }

        [StringLength(200)]
        public string ReportMsgSubject { get; set; }

        [StringLength(2500)]
        public string ReportMsgBody { get; set; }
    }
}
