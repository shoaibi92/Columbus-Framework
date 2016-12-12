namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OUTCOMES")]
    public partial class OUTCOME
    {
        [Key]
        [StringLength(14)]
        public string OUTCOME_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string OUTTABLE_ID { get; set; }

        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [Column(TypeName = "image")]
        public byte[] COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual OUTTABLE OUTTABLE { get; set; }
    }
}
