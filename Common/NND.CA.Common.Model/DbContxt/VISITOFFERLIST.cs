namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISITOFFERLISTS")]
    public partial class VISITOFFERLIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VISITOFFERLIST()
        {
            VISITOFFERS = new HashSet<VISITOFFER>();
        }

        [Key]
        [StringLength(14)]
        public string VOFFERLIST_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string OFFERTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime DUEDATE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        public DateTime? UTCDUEDATE { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISITOFFER> VISITOFFERS { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
