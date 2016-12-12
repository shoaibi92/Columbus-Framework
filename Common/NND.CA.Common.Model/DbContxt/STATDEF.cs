namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STATDEFS")]
    public partial class STATDEF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATDEF()
        {
            STATHOLIDS = new HashSet<STATHOLID>();
        }

        [Key]
        [StringLength(14)]
        public string STATDEF_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STATHOLID> STATHOLIDS { get; set; }
    }
}
