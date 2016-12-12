namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLRECVAL")]
    public partial class BILLRECVAL
    {
        [Key]
        [StringLength(14)]
        public string BILLVAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOOKUPVAL_ID { get; set; }

        [StringLength(10)]
        public string BILLCODE { get; set; }

        public decimal? BILLRATE { get; set; }

        [StringLength(5)]
        public string BILLUNITS { get; set; }

        [StringLength(20)]
        public string REVCODE { get; set; }

        [StringLength(20)]
        public string EXPCODE { get; set; }

        [StringLength(1)]
        public string USEEMPPAY { get; set; }

        public decimal? OTFACTOR { get; set; }

        [StringLength(10)]
        public string PREMCODE { get; set; }

        public decimal? PREMRATE { get; set; }

        [StringLength(5)]
        public string PREMUNITS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
