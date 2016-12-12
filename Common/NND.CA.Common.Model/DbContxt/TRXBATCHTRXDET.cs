namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRXBATCHTRXDET")]
    public partial class TRXBATCHTRXDET
    {
        [Key]
        [StringLength(14)]
        public string TRXDET_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TRXBATCHTRX_ID { get; set; }

        [StringLength(14)]
        public string TRX_ID { get; set; }

        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        public decimal PMTAMT { get; set; }

        [Required]
        [StringLength(1)]
        public string DETAILS { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [StringLength(14)]
        public string BILLING_ID { get; set; }

        [StringLength(30)]
        public string RECEIPTNUM { get; set; }

        public virtual BILLING BILLING { get; set; }

        public virtual BILLINV BILLINV { get; set; }

        public virtual TRXBATCHTRX TRXBATCHTRX { get; set; }

        public virtual TRXTYPE TRXTYPE { get; set; }
    }
}
