namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTASSLOGCHG")]
    public partial class CLTASSLOGCHG
    {
        [Key]
        [StringLength(14)]
        public string CHG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [StringLength(255)]
        public string OLDVALUE { get; set; }

        [StringLength(255)]
        public string NEWVALUE { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual CLTASSLOG CLTASSLOG { get; set; }

        public virtual CLTASSLOGDATA CLTASSLOGDATA { get; set; }
    }
}
