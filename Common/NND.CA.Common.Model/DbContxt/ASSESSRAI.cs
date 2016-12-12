namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSESSRAI")]
    public partial class ASSESSRAI
    {
        [Key]
        [StringLength(14)]
        public string ASSRAI_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string RFA_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
