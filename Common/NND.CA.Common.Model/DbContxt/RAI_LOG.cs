namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RAI_LOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RAI_LOG()
        {
            RAI_CHANGE = new HashSet<RAI_CHANGE>();
        }

        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string RAI_ASSESS_ID { get; set; }

        [Required]
        [StringLength(8)]
        public string ASSESSTYPE { get; set; }

        [StringLength(15)]
        public string SECTION { get; set; }

        [StringLength(10)]
        public string QUESTION { get; set; }

        [Required]
        [StringLength(20)]
        public string ACTION { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual RAI_ASSESS RAI_ASSESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_CHANGE> RAI_CHANGE { get; set; }
    }
}
