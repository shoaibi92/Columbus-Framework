namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FPGroupLocations
    {
        [Key]
        public int UID { get; set; }

        public int? FPGroupFK { get; set; }

        [StringLength(30)]
        public string Dept_ID { get; set; }
    }
}
