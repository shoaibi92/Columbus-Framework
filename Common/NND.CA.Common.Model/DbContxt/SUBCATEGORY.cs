namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUBCATEGORY")]
    public partial class SUBCATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBCATEGORY()
        {
            CLTSUBCATS = new HashSet<CLTSUBCAT>();
            CONSUBCATS = new HashSet<CONSUBCAT>();
            EMPSUBCATS = new HashSet<EMPSUBCAT>();
        }

        [Key]
        [StringLength(14)]
        public string SUBCAT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CAT_ID { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string LABELNAME { get; set; }

        [Required]
        [StringLength(1)]
        public string LABELTYPE { get; set; }

        [StringLength(30)]
        public string REFNAME { get; set; }

        [StringLength(1)]
        public string REFTYPE { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUBCAT> CLTSUBCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSUBCAT> CONSUBCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUBCAT> EMPSUBCATS { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }
    }
}
