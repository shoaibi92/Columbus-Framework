namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Planner_AssignHistory
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string ClientOrVisit_ID { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        [StringLength(15)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        public bool? Assigned { get; set; }

        [StringLength(80)]
        public string Comment { get; set; }

        public int? MSG_Planner_UID { get; set; }
    }
}
