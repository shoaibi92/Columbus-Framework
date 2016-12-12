namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERLOG")]
    public partial class USERLOG
    {
        [Key]
        [StringLength(14)]
        public string UL_ID { get; set; }

        public DateTime LOGTIME { get; set; }

        [Required]
        [StringLength(255)]
        public string LOGUSER { get; set; }

        [Required]
        [StringLength(80)]
        public string LOGCMT { get; set; }

        public int? LOGINT { get; set; }

        public int? LOGINT2 { get; set; }

        public int? LOGINT3 { get; set; }
    }
}
