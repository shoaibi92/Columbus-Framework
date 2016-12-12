namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDCEXCEPTS")]
    public partial class EDCEXCEPT
    {
        [Key]
        [StringLength(14)]
        public string EXCEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CALLVISIT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VAR_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSOURCE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual EDCVARIANCE EDCVARIANCE { get; set; }

        public virtual EDCVISIT EDCVISIT { get; set; }
    }
}
