namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ICDGEM")]
    public partial class ICDGEM
    {
        [Key]
        [StringLength(14)]
        public string ICDGEM_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string CODETYPE { get; set; }

        [Required]
        [StringLength(10)]
        public string ICD9_CODE { get; set; }

        [Required]
        [StringLength(10)]
        public string ICD10_CODE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public string PROPS { get; set; }
    }
}
