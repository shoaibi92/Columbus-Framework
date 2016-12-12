namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LBRRULES")]
    public partial class LBRRULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LBRRULE()
        {
            CATRULES = new HashSet<CATRULE>();
        }

        [Key]
        [StringLength(14)]
        public string RULE_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public decimal? VAL { get; set; }

        public DateTime? PERSTART { get; set; }

        public int? PERIODDAYS { get; set; }

        [StringLength(1)]
        public string MIDNITEACT { get; set; }

        [StringLength(10)]
        public string RULECODE { get; set; }

        [StringLength(1)]
        public string EVENACTION { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATRULE> CATRULES { get; set; }
    }
}
