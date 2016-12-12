namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEDICATION")]
    public partial class MEDICATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICATION()
        {
            CLTMEDS = new HashSet<CLTMED>();
        }

        [Key]
        [StringLength(14)]
        public string MED_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(180)]
        public string DESCR { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(60)]
        public string BRANDNAME { get; set; }

        [StringLength(30)]
        public string DRUGNUMBER { get; set; }

        [Column(TypeName = "text")]
        public string INSTRUCTIONS { get; set; }

        [StringLength(30)]
        public string DRUGFAMILY { get; set; }

        [StringLength(255)]
        public string WEBURL { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMED> CLTMEDS { get; set; }
    }
}
