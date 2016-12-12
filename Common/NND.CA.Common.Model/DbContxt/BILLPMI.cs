namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLPMI")]
    public partial class BILLPMI
    {
        [Key]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [StringLength(10)]
        public string VENDERID { get; set; }

        [StringLength(10)]
        public string SERVICECODE { get; set; }

        public decimal? QUANTITY { get; set; }

        [StringLength(48)]
        public string SERVICEACT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual BILLINV BILLINV { get; set; }
    }
}
