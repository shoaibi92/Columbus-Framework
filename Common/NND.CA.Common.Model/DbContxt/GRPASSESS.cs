namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GRPASSESS")]
    public partial class GRPASSESS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string VIEWONLY { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual GROUP GROUP { get; set; }
    }
}
