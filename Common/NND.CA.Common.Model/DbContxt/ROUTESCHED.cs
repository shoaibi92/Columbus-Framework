namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTESCHED")]
    public partial class ROUTESCHED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUTESCHED()
        {
            ROUTEDAYS = new HashSet<ROUTEDAY>();
            ROUTEDDEFS = new HashSet<ROUTEDDEF>();
            ROUTESDEFS = new HashSet<ROUTESDEF>();
        }

        [Key]
        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? STARTDATE { get; set; }

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

        public DateTime? LGENDATE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDAY> ROUTEDAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDDEF> ROUTEDDEFS { get; set; }

        public virtual ROUTE ROUTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTESDEF> ROUTESDEFS { get; set; }
    }
}
