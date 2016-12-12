namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FPGroupUsers
    {
        [Key]
        public int UID { get; set; }

        public int? FPGroupFK { get; set; }

        [StringLength(14)]
        public string User_ID { get; set; }

        [StringLength(50)]
        public string AliasName { get; set; }
    }
}
