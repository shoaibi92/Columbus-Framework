namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTES")]
    public partial class ROUTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUTE()
        {
            CLTDEPTs = new HashSet<CLTDEPT>();
            EMPROUTES = new HashSet<EMPROUTE>();
            MEALSCHEDs = new HashSet<MEALSCHED>();
            MEALSORTs = new HashSet<MEALSORT>();
            MEALVISITS = new HashSet<MEALVISIT>();
            ROUTEDAYS = new HashSet<ROUTEDAY>();
            ROUTESCHEDs = new HashSet<ROUTESCHED>();
        }

        [Key]
        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DISTRICT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        public int? NUMVOLS { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        public int? MAXCLIENTS { get; set; }

        public int? MINCLIENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        public virtual DISTRICT DISTRICT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPROUTE> EMPROUTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHED> MEALSCHEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSORT> MEALSORTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISIT> MEALVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDAY> ROUTEDAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTESCHED> ROUTESCHEDs { get; set; }
    }
}
