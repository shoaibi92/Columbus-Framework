namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTASSMEDS")]
    public partial class CLTASSMED
    {
        [Key]
        [StringLength(14)]
        public string CLTASSMED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLTMED_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual CLTMED CLTMED { get; set; }
    }
}
