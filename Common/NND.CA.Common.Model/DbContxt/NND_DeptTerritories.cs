namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_DeptTerritories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UID { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        public int? Territory_ID { get; set; }
    }
}
