namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_EventLog
    {
        [Key]
        public int UID { get; set; }

        public int? EventCode { get; set; }

        public int? EventType { get; set; }

        [StringLength(1000)]
        public string EventDescription { get; set; }

        public DateTime? EventDateTime { get; set; }
    }
}
