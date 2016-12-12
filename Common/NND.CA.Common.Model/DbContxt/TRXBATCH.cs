namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRXBATCH")]
    public partial class TRXBATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRXBATCH()
        {
            TRXBATCHTRXes = new HashSet<TRXBATCHTRX>();
            TRXBATCHFUNDERS = new HashSet<TRXBATCHFUNDER>();
        }

        [Key]
        [StringLength(14)]
        public string TRXBATCH_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string BNAME { get; set; }

        public DateTime? BTRXDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string BTRXTYPE { get; set; }

        [StringLength(14)]
        public string BTRX_ID { get; set; }

        [StringLength(30)]
        public string BPAYMETHOD { get; set; }

        [StringLength(30)]
        public string BGROUPNUM { get; set; }

        [StringLength(255)]
        public string BCOMMENTS { get; set; }

        [StringLength(14)]
        public string NUMBER_ID { get; set; }

        public decimal? BCOMPTOTAL { get; set; }

        [Required]
        [StringLength(1)]
        public string BREFNUMLOGIC { get; set; }

        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string BPRINTRECEIPTS { get; set; }

        [Required]
        [StringLength(1)]
        public string BPRINTTRXS { get; set; }

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

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual TRXTYPE TRXTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHTRX> TRXBATCHTRXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHFUNDER> TRXBATCHFUNDERS { get; set; }
    }
}
