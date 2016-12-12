namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSYNCHERR")]
    public partial class CLTSYNCHERR
    {
        [Key]
        [StringLength(14)]
        public string SYNCHERR_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SYNCH_ID { get; set; }

        [Column(TypeName = "text")]
        public string DETAILS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(255)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(1)]
        public string ERRORS { get; set; }

        public int? NOTES { get; set; }

        public int? SYNCTIME { get; set; }

        public int? ERRCOUNT { get; set; }

        public virtual CLTSYNCH CLTSYNCH { get; set; }
    }
}
