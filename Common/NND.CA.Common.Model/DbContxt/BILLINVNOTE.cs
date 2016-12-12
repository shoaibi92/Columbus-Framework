namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLINVNOTES")]
    public partial class BILLINVNOTE
    {
        [Key]
        [StringLength(14)]
        public string BILLINVNOTE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string INVSTATUS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual BILLINV BILLINV { get; set; }
    }
}
