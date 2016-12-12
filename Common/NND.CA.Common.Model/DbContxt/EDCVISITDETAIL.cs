namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDCVISITDETAILS")]
    public partial class EDCVISITDETAIL
    {
        [Key]
        [StringLength(14)]
        public string EDCVISITDET_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CALLVISIT_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(100)]
        public string CODE { get; set; }

        [StringLength(100)]
        public string VALUE { get; set; }

        public DateTime UTCINTAKE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public virtual EDCVISIT EDCVISIT { get; set; }
    }
}
