namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALITEMS")]
    public partial class MEALITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALITEM()
        {
            MEALDIS = new HashSet<MEALDI>();
            MEALPLANDAYs = new HashSet<MEALPLANDAY>();
            MEALPACKS = new HashSet<MEALPACK>();
        }

        [Key]
        [StringLength(14)]
        public string ITEM_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [StringLength(1)]
        public string DESSERT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALDI> MEALDIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPLANDAY> MEALPLANDAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPACK> MEALPACKS { get; set; }
    }
}
