namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KITCHDIST")]
    public partial class KITCHDIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KITCHDIST()
        {
            MEALPACKS = new HashSet<MEALPACK>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string KITCHEN_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DISTRICT_ID { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        public virtual KITCHEN KITCHEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPACK> MEALPACKS { get; set; }
    }
}
