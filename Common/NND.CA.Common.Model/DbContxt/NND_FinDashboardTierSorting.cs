namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FinDashboardTierSorting
    {
        [Key]
        public int UID { get; set; }

        [StringLength(50)]
        public string Tier { get; set; }

        public int? SortWeight { get; set; }
    }
}
