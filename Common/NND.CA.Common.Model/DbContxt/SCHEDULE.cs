namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHEDULES")]
    public partial class SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHEDULE()
        {
            VISITOFFERLISTS = new HashSet<VISITOFFERLIST>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? SCHEDSTART { get; set; }

        public DateTime? SCHEDSTOP { get; set; }

        public DateTime? SCHEDEND { get; set; }

        [StringLength(2)]
        public string SCHEDTYPE { get; set; }

        public int? TYPENUM { get; set; }

        [StringLength(2)]
        public string TYPEMDATE { get; set; }

        public DateTime? LGENDATE { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISITOFFERLIST> VISITOFFERLISTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
