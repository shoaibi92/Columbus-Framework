namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALVISITS")]
    public partial class MEALVISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALVISIT()
        {
            MEALVISITMEALS = new HashSet<MEALVISITMEAL>();
        }

        [Key]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [StringLength(14)]
        public string DAY_ID { get; set; }

        public DateTime VISITDATE { get; set; }

        [StringLength(1)]
        public string VISITTYPE { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(1)]
        public string NONOTICE { get; set; }

        [StringLength(1)]
        public string PLANNER { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [StringLength(40)]
        public string REASON { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual MEALSCHED MEALSCHED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISITMEAL> MEALVISITMEALS { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        public virtual ROUTEDAY ROUTEDAY { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }
    }
}
