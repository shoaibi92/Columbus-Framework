namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDCVARIANCES")]
    public partial class EDCVARIANCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EDCVARIANCE()
        {
            EDCEXCEPTS = new HashSet<EDCEXCEPT>();
        }

        [Key]
        [StringLength(14)]
        public string VAR_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string VARENABLED { get; set; }

        public int? VARVALUE { get; set; }

        [Required]
        [StringLength(1)]
        public string VARUSEVISIT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string VARCODE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCEXCEPT> EDCEXCEPTS { get; set; }
    }
}
