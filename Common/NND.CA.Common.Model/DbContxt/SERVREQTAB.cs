namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVREQTAB")]
    public partial class SERVREQTAB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVREQTAB()
        {
            DEPTSRVREQs = new HashSet<DEPTSRVREQ>();
            SERVREQS = new HashSet<SERVREQ>();
        }

        [Key]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTSRVREQ> DEPTSRVREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVREQ> SERVREQS { get; set; }
    }
}
