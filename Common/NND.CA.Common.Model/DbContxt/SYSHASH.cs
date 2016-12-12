namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSHASH")]
    public partial class SYSHASH
    {
        [Key]
        [StringLength(200)]
        public string HASHDATA { get; set; }

        public DateTime UTCCHGDATE { get; set; }
    }
}
