namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDCVISITS")]
    public partial class EDCVISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EDCVISIT()
        {
            EDCEXCEPTS = new HashSet<EDCEXCEPT>();
            EDCVISITDETAILS = new HashSet<EDCVISITDETAIL>();
        }

        [Key]
        [StringLength(14)]
        public string CALLVISIT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CALL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CV_ID { get; set; }

        [StringLength(1)]
        public string CVMATCH { get; set; }

        [StringLength(1)]
        public string CVSTATUS { get; set; }

        public DateTime? CVDATE { get; set; }

        public DateTime? CVSTART { get; set; }

        public DateTime? CVSTOP { get; set; }

        public int? CVMINUTES { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public int? CVMILEAGE { get; set; }

        public DateTime? UTCINTAKE { get; set; }

        public DateTime? UTCCHGDATE { get; set; }

        public string PROPS { get; set; }

        public virtual EDCCALL EDCCALL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCEXCEPT> EDCEXCEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCVISITDETAIL> EDCVISITDETAILS { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
