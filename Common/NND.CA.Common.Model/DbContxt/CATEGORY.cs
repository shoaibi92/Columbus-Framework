namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            SUBCATEGORies = new HashSet<SUBCATEGORY>();
        }

        [Key]
        [StringLength(14)]
        public string CAT_ID { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string TYPE { get; set; }

        [StringLength(1)]
        public string DEPTSPECIFIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBCATEGORY> SUBCATEGORies { get; set; }
    }
}
