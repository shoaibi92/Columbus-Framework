namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallForwardHistory
    {
        public int ID { get; set; }

        public int? StepNumber { get; set; }

        [StringLength(25)]
        public string StepStatus { get; set; }

        [StringLength(400)]
        public string StepDescription { get; set; }

        public int? CallForwardCount { get; set; }

        public DateTime? LogDateTime { get; set; }

        [StringLength(16)]
        public string CallForwardNumber { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        [StringLength(50)]
        public string MachineName { get; set; }

        [StringLength(400)]
        public string ErrorDescription { get; set; }
    }
}
