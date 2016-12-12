namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSSECTS")]
    public partial class ASSSECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASSSECT()
        {
            ASSQUESTS = new HashSet<ASSQUEST>();
            ASSSECTSLAYOUTS = new HashSet<ASSSECTSLAYOUT>();
        }

        [Key]
        [StringLength(14)]
        public string SECTION_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string SNAME { get; set; }

        [Column(TypeName = "text")]
        public string SINTRO { get; set; }

        [Required]
        [StringLength(3)]
        public string SSORTORDER { get; set; }

        [StringLength(30)]
        public string SCUSTNUMBER { get; set; }

        [StringLength(100)]
        public string SREFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string SRECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string OASISGROUP_ID { get; set; }

        [StringLength(14)]
        public string MDSGROUP_ID { get; set; }

        [StringLength(1)]
        public string GROUPLAYOUT { get; set; }

        [StringLength(14)]
        public string CAT_ID { get; set; }

        [StringLength(14)]
        public string FCAT_ID { get; set; }

        [StringLength(14)]
        public string DCAT_ID { get; set; }

        [Column(TypeName = "text")]
        public string SGUIDELINES { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECTSLAYOUT> ASSSECTSLAYOUTS { get; set; }

        public virtual PATHCAT PATHCAT { get; set; }

        public virtual PATHCAT PATHCAT1 { get; set; }

        public virtual PATHCAT PATHCAT2 { get; set; }
    }
}
