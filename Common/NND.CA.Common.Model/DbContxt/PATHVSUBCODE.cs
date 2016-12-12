namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHVSUBCODES")]
    public partial class PATHVSUBCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHVSUBCODE()
        {
            CLTPATHITEMS = new HashSet<CLTPATHITEM>();
        }

        [Key]
        [StringLength(14)]
        public string VSUBCODE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VCODE_ID { get; set; }

        [Required]
        [StringLength(5)]
        public string SUBCODE { get; set; }

        [Required]
        [StringLength(1000)]
        public string SUBDESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEM> CLTPATHITEMS { get; set; }

        public virtual PATHVCODE PATHVCODE { get; set; }
    }
}
