namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPFRMLOGDATA")]
    public partial class EMPFRMLOGDATA
    {
        [Key]
        [StringLength(14)]
        public string CHG_ID { get; set; }

        [Column(TypeName = "image")]
        public byte[] OLDDATA { get; set; }

        [Column(TypeName = "image")]
        public byte[] NEWDATA { get; set; }

        [Column(TypeName = "text")]
        public string OLDTEXT { get; set; }

        [Column(TypeName = "text")]
        public string NEWTEXT { get; set; }

        public virtual EMPFRMLOGCHG EMPFRMLOGCHG { get; set; }
    }
}
