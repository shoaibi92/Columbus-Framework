namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHVCODETABLES")]
    public partial class PATHVCODETABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHVCODETABLE()
        {
            PATHVCODES = new HashSet<PATHVCODE>();
            PATHWAYS = new HashSet<PATHWAY>();
        }

        [Key]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHVCODE> PATHVCODES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHWAY> PATHWAYS { get; set; }
    }
}
