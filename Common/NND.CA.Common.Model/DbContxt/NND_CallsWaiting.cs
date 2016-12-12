namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallsWaiting
    {
        public int ID { get; set; }

        public int? CallsWaiting { get; set; }

        [StringLength(20)]
        public string CallsWaitingTime { get; set; }
    }
}
