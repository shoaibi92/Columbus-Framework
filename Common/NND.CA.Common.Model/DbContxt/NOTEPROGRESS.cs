namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTEPROGRESS")]
    public partial class NOTEPROGRESS
    {
        [Key]
        [StringLength(14)]
        public string PROGRESS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string NOTE_ID { get; set; }

        public DateTime PNDATE { get; set; }

        [StringLength(30)]
        public string PNSTATUS { get; set; }

        [Column(TypeName = "text")]
        public string PNCONTENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DATEDNOTE DATEDNOTE { get; set; }
    }
}
