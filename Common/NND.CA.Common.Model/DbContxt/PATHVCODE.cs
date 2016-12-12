namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHVCODES")]
    public partial class PATHVCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHVCODE()
        {
            PATHVSUBCODES = new HashSet<PATHVSUBCODE>();
        }

        [Key]
        [StringLength(14)]
        public string VCODE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [Required]
        [StringLength(5)]
        public string CODE { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string NOTAPPLICABLE { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual PATHVCODETABLE PATHVCODETABLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHVSUBCODE> PATHVSUBCODES { get; set; }
    }
}
