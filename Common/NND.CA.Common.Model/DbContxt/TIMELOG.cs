namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIMELOG")]
    public partial class TIMELOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMELOG()
        {
            TIMECHANGEs = new HashSet<TIMECHANGE>();
        }

        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string ACTION { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMECHANGE> TIMECHANGEs { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
