namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDSNOTES")]
    public partial class MDSNOTE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string SECTION { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string QUEST { get; set; }

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

        [StringLength(1)]
        public string RECTYPE { get; set; }

        public virtual MD MD { get; set; }
    }
}
