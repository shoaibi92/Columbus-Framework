namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRXBATCHTRX")]
    public partial class TRXBATCHTRX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRXBATCHTRX()
        {
            TRXBATCHTRXDETs = new HashSet<TRXBATCHTRXDET>();
        }

        [Key]
        [StringLength(14)]
        public string TRXBATCHTRX_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TRXBATCH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        public DateTime TRXDATE { get; set; }

        [Required]
        [StringLength(14)]
        public string TRX_ID { get; set; }

        [StringLength(30)]
        public string PAYMETHOD { get; set; }

        [Required]
        [StringLength(40)]
        public string REFNUMBER { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [StringLength(30)]
        public string GROUPNUM { get; set; }

        public decimal PMTAMT { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? RECEIPTPRINTED { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string LINEITEMPOST { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual TRXBATCH TRXBATCH { get; set; }

        public virtual TRXTYPE TRXTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRXDET> TRXBATCHTRXDETs { get; set; }
    }
}
