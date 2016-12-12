namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLEDX")]
    public partial class BILLEDX
    {
        [Key]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECCLASS { get; set; }

        [StringLength(8)]
        public string PT_ID { get; set; }

        [StringLength(8)]
        public string CAF_NO { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(10)]
        public string REQCODE { get; set; }

        [StringLength(4)]
        public string PROVIDER_ID { get; set; }

        [StringLength(1)]
        public string DC { get; set; }

        public decimal? UNITS { get; set; }

        public decimal? RATE { get; set; }

        public decimal? EDXTIME { get; set; }

        [StringLength(2)]
        public string EDXSERVICE { get; set; }

        [StringLength(20)]
        public string ACTIVITIES { get; set; }

        public DateTime? BATCHDATE { get; set; }

        [StringLength(3)]
        public string BATCHNO { get; set; }

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
