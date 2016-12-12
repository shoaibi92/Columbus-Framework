namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_PlannerInvestigated
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Planner_ID { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        public int? Hidden { get; set; }

        public int? Status { get; set; }
    }
}
