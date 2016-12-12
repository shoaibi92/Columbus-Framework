namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Territories
    {
        [Key]
        public int UID { get; set; }

        [StringLength(50)]
        public string TerritoryName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDateLegal { get; set; }
    }
}
