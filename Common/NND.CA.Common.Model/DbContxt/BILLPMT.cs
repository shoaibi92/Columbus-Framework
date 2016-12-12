namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLPMTS")]
    public partial class BILLPMT
    {
        [Key]
        [StringLength(14)]
        public string BILLPMT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string INVOICE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PAYMENT_ID { get; set; }

        public decimal? PMTAMT { get; set; }

        public decimal? TOTPMTAMT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(14)]
        public string BILLING_ID { get; set; }

        [StringLength(60)]
        public string SVCBILLCODE { get; set; }

        public decimal? SVCUNITS { get; set; }

        public virtual BILLING BILLING { get; set; }

        public virtual BILLINV BILLINV { get; set; }

        public virtual BILLINV BILLINV1 { get; set; }
    }
}
