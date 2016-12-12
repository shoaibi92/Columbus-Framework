namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFACTIONS")]
    public partial class WFACTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFACTION()
        {
            WFALERTACTIONS = new HashSet<WFALERTACTION>();
        }

        [Key]
        [StringLength(14)]
        public string WFACTION_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Column(TypeName = "text")]
        public string ACTDATA { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTACTION> WFALERTACTIONS { get; set; }
    }
}
