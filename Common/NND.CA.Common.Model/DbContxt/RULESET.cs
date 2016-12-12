namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RULESETS")]
    public partial class RULESET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RULESET()
        {
            EMPCATS = new HashSet<EMPCAT>();
            EMPCATS1 = new HashSet<EMPCAT>();
        }

        [Key]
        [StringLength(14)]
        public string RULESET_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PROPS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPCAT> EMPCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPCAT> EMPCATS1 { get; set; }
    }
}
