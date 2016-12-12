namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDSCAPS")]
    public partial class MDSCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MDSCAP()
        {
            ASSQMDSHCDEPENDS = new HashSet<ASSQMDSHCDEPEND>();
            MDSHCCAPS = new HashSet<MDSHCCAP>();
        }

        [Key]
        [StringLength(14)]
        public string CAP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CAPDOMAIN { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQMDSHCDEPEND> ASSQMDSHCDEPENDS { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSHCCAP> MDSHCCAPS { get; set; }
    }
}
