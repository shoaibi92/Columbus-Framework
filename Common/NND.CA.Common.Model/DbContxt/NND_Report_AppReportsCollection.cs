namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_AppReportsCollection
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string ReportName { get; set; }

        [StringLength(40)]
        public string PageLayout { get; set; }

        [StringLength(500)]
        public string ReportEndUserName { get; set; }

        [StringLength(2500)]
        public string ReportScriptTemplate { get; set; }

        public short? ReportStatus { get; set; }

        public DateTime? LastSavedDate { get; set; }

        [StringLength(50)]
        public string LastSavedByUser { get; set; }
    }
}
