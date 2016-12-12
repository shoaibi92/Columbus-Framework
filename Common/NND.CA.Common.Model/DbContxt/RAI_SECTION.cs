namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RAI_SECTION
    {
        [Key]
        [StringLength(14)]
        public string RAI_SECTION_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string RAI_ASSESS_ID { get; set; }

        [Required]
        [StringLength(8)]
        public string ASSESSTYPE { get; set; }

        [Required]
        [StringLength(15)]
        public string SECTION { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime STATUSDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string STATUSUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual RAI_ASSESS RAI_ASSESS { get; set; }
    }
}
