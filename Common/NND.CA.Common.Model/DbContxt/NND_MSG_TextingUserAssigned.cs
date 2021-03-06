namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_TextingUserAssigned
    {
        public int ID { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        [StringLength(10)]
        public string MsgVisitCode { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        public bool? Assigned { get; set; }

        public int? MSG_Planner_UID { get; set; }
    }
}
