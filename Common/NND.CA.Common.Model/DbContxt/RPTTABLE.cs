namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTTABLES")]
    public partial class RPTTABLE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(60)]
        public string RTABLENAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string RTABLEALIAS { get; set; }

        [StringLength(1)]
        public string RCUSTOM { get; set; }
    }
}
