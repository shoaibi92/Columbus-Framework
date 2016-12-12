namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRORDERSLOGDATA")]
    public partial class DRORDERSLOGDATA
    {
        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string XMLDATA { get; set; }

        public virtual DRORDERSLOG DRORDERSLOG { get; set; }
    }
}
