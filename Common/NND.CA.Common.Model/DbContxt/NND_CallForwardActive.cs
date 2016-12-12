namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallForwardActive
    {
        [Key]
        public int UID { get; set; }

        [StringLength(16)]
        public string VISIT_ID { get; set; }

        public int? CallForwardCount { get; set; }

        public DateTime? FirstCallForwardDateTime { get; set; }

        public DateTime? LastCallForwardDateTime { get; set; }
    }
}
