namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTLOGCHG")]
    public partial class CLTLOGCHG
    {
        [Key]
        [StringLength(14)]
        public string CHG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string FIELDLABEL { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(80)]
        public string OLDVALUE { get; set; }

        [StringLength(80)]
        public string NEWVALUE { get; set; }

        public virtual CLTLOG CLTLOG { get; set; }

        public virtual CLTLOGMEMO CLTLOGMEMO { get; set; }
    }
}
