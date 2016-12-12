namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALSCHEDMEALS")]
    public partial class MEALSCHEDMEAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALSCHEDMEAL()
        {
            MEALVISITMEALS = new HashSet<MEALVISITMEAL>();
        }

        [Key]
        [StringLength(14)]
        public string VISMEAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PACKAGE_ID { get; set; }

        [StringLength(14)]
        public string TYPE_ID { get; set; }

        public int MEALUNITS { get; set; }

        [StringLength(1)]
        public string BILLABLE { get; set; }

        [StringLength(14)]
        public string KITCHEN_ID { get; set; }

        public virtual DIETTYPE DIETTYPE { get; set; }

        public virtual KITCHEN KITCHEN { get; set; }

        public virtual MEALPACK MEALPACK { get; set; }

        public virtual MEALSCHED MEALSCHED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISITMEAL> MEALVISITMEALS { get; set; }
    }
}
