namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTESDEFS")]
    public partial class ROUTESDEF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROUTESDEF()
        {
            ROUTEDDEFS = new HashSet<ROUTEDDEF>();
        }

        [Key]
        [StringLength(14)]
        public string ROUTEDEF_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string REQDEF_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(1)]
        public string PAYABLE { get; set; }

        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        public virtual REQDEF REQDEF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTEDDEF> ROUTEDDEFS { get; set; }

        public virtual ROUTESCHED ROUTESCHED { get; set; }
    }
}
