namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RAI_NOTES
    {
        [Key]
        [StringLength(14)]
        public string RAI_NOTE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string RAI_ASSESS_ID { get; set; }

        [StringLength(15)]
        public string SECTION { get; set; }

        [StringLength(10)]
        public string QUESTION { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string FOLLOWUP { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(8)]
        public string ASSESSTYPE { get; set; }

        public virtual RAI_ASSESS RAI_ASSESS { get; set; }
    }
}
