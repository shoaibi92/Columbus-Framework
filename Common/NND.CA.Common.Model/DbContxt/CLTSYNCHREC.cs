namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSYNCHRECS")]
    public partial class CLTSYNCHREC
    {
        [Key]
        [StringLength(14)]
        public string SYNCRECORD_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SYNCH_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string TABLENAME { get; set; }

        [Required]
        [StringLength(40)]
        public string KEYFIELDNAME { get; set; }

        [Required]
        [StringLength(14)]
        public string NEW_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string OLD_ID { get; set; }

        public virtual CLTSYNCH CLTSYNCH { get; set; }
    }
}
