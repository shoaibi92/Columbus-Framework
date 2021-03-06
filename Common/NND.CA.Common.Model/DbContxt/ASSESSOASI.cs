namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSESSOASIS")]
    public partial class ASSESSOASI
    {
        [Key]
        [StringLength(14)]
        public string ASSOASIS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string RFA_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
