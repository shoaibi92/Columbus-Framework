namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTACTV")]
    public partial class CLTACTV
    {
        [Key]
        [StringLength(14)]
        public string CLTACTV_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ACTIVITY_ID { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? PAYDUR { get; set; }

        public DateTime? CHGDATE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [Required]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string CVSTATUS { get; set; }

        [StringLength(30)]
        public string CVSTATUSREASON { get; set; }

        public virtual ACTIVITY ACTIVITY { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
