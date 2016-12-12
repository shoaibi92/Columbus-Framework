namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOGCHG")]
    public partial class EMPLOGCHG
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

        public virtual EMPLOG EMPLOG { get; set; }

        public virtual EMPLOGMEMO EMPLOGMEMO { get; set; }
    }
}
