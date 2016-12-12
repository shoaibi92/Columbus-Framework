namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EBILLFORMATS")]
    public partial class EBILLFORMAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EBILLFORMAT()
        {
            FUNDDEPTs = new HashSet<FUNDDEPT>();
        }

        [Key]
        [StringLength(14)]
        public string FORMAT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }
    }
}
