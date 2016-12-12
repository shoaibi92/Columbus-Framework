namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTEDAYS")]
    public partial class ROUTEDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUTEDAY()
        {
            MEALVISITS = new HashSet<MEALVISIT>();
            ROUTEDDEFS = new HashSet<ROUTEDDEF>();
        }

        [Key]
        [StringLength(14)]
        public string DAY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        public DateTime ROUTEDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        public virtual ROUTESCHED ROUTESCHED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDDEF> ROUTEDDEFS { get; set; }
    }
}
