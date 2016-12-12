namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDSCHANGE")]
    public partial class MDSCHANGE
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [StringLength(10)]
        public string QUEST { get; set; }

        [StringLength(40)]
        public string OLDVALUE { get; set; }

        [StringLength(40)]
        public string NEWVALUE { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        public virtual MDSLOG MDSLOG { get; set; }
    }
}
