namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESVIS")]
    public partial class RESVI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESVI()
        {
            EMPLDEPTs = new HashSet<EMPLDEPT>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string RESVIS_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string TYPE { get; set; }

        [StringLength(1)]
        public string ONETIME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs { get; set; }

        public virtual RESOURCE RESOURCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
