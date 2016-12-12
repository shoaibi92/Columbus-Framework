namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDCCALLS")]
    public partial class EDCCALL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EDCCALL()
        {
            EDCVISITS = new HashSet<EDCVISIT>();
        }

        [Key]
        [StringLength(14)]
        public string CALL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string CALLMODE { get; set; }

        [Required]
        [StringLength(1)]
        public string CALLSTATUS { get; set; }

        [StringLength(12)]
        public string PHONESTART { get; set; }

        [StringLength(12)]
        public string PHONESTOP { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? CALLDATESTART { get; set; }

        public DateTime? CALLDATESTOP { get; set; }

        [StringLength(1)]
        public string MANUALPSTART { get; set; }

        [StringLength(1)]
        public string MANUALPSTOP { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public DateTime? UTCINTAKE { get; set; }

        public DateTime? UTCCHGDATE { get; set; }

        [StringLength(255)]
        public string CALLSOURCE { get; set; }

        public string PROPS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCVISIT> EDCVISITS { get; set; }
    }
}
