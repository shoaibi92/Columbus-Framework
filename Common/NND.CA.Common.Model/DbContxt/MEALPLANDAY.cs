namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALPLANDAY")]
    public partial class MEALPLANDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALPLANDAY()
        {
            MEALITEMS = new HashSet<MEALITEM>();
        }

        [Key]
        [StringLength(14)]
        public string DAY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PLAN_ID { get; set; }

        public DateTime DAYDATE { get; set; }

        public virtual MEALPLAN MEALPLAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALITEM> MEALITEMS { get; set; }
    }
}
