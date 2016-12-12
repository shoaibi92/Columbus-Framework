namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDDATES")]
    public partial class ORDDATE
    {
        [Key]
        [StringLength(14)]
        public string ORDDATE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOOKUPVAL_ID { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(30)]
        public string REASON { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(10)]
        public string SERVTYPE { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
