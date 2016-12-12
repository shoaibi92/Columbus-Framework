namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIFTCODES")]
    public partial class SHIFTCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHIFTCODE()
        {
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string CODE_ID { get; set; }

        [Column("SHIFTCODE")]
        [Required]
        [StringLength(5)]
        public string SHIFTCODE1 { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(10)]
        public string SORTORDER { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(1)]
        public string DEFTIMES { get; set; }

        public DateTime? STARTTIME { get; set; }

        public DateTime? STOPTIME { get; set; }

        [StringLength(1)]
        public string DEFDUR { get; set; }

        public decimal? DURATION { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? PAYDUR { get; set; }

        [StringLength(40)]
        public string REFNUMBER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
