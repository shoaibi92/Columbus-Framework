namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOGMEMO")]
    public partial class EMPLOGMEMO
    {
        [Key]
        [StringLength(14)]
        public string CHG_ID { get; set; }

        [Column(TypeName = "text")]
        public string OLDMEMO { get; set; }

        [Column(TypeName = "text")]
        public string NEWMEMO { get; set; }

        public virtual EMPLOGCHG EMPLOGCHG { get; set; }
    }
}
