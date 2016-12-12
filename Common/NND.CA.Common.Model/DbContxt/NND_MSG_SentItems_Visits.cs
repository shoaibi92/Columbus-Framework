namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_SentItems_Visits
    {
        [Key]
        public int UID { get; set; }

        public int? MSG_Planner_UID { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }
    }
}
