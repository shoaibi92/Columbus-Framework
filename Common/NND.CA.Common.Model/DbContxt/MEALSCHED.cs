namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALSCHED")]
    public partial class MEALSCHED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALSCHED()
        {
            MEALSCHEDMEALS = new HashSet<MEALSCHEDMEAL>();
            MEALVISITS = new HashSet<MEALVISIT>();
        }

        [Key]
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

        [Required]
        [StringLength(1)]
        public string SCHEDTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(1)]
        public string ONSUN { get; set; }

        [StringLength(1)]
        public string ONMON { get; set; }

        [StringLength(1)]
        public string ONTUE { get; set; }

        [StringLength(1)]
        public string ONWED { get; set; }

        [StringLength(1)]
        public string ONTHU { get; set; }

        [StringLength(1)]
        public string ONFRI { get; set; }

        [StringLength(1)]
        public string ONSAT { get; set; }

        [StringLength(1)]
        public string SCHEDGEN { get; set; }

        [StringLength(1)]
        public string NONOTICE { get; set; }

        [StringLength(1)]
        public string PLANNER { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        public DateTime? LGENDATE { get; set; }

        [StringLength(40)]
        public string REASON { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHEDMEAL> MEALSCHEDMEALS { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }
    }
}
