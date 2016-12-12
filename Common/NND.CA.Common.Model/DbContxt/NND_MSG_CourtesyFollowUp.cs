namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_CourtesyFollowUp
    {
        [Key]
        public int UID { get; set; }

        public int? MSG_Planner_UID { get; set; }

        [StringLength(20)]
        public string SPOC { get; set; }

        [StringLength(500)]
        public string CFUBody { get; set; }

        public DateTime? MSGSentDateTime { get; set; }

        [StringLength(20)]
        public string MSGSentbyUser { get; set; }

        [StringLength(500)]
        public string MSGBody { get; set; }
    }
}
