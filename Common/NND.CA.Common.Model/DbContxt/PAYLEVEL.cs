namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYLEVELS")]
    public partial class PAYLEVEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYLEVEL()
        {
            EMPLDEPTs = new HashSet<EMPLDEPT>();
            PAYRECORDS = new HashSet<PAYRECORD>();
        }

        [Key]
        [StringLength(14)]
        public string LEVEL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PAYTAB_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public decimal? LOWHOURS { get; set; }

        public decimal? HIGHHOURS { get; set; }

        [StringLength(1)]
        public string EMPINACTIVE { get; set; }

        [StringLength(14)]
        public string DEFPAYREC { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLDEPT> EMPLDEPTs { get; set; }

        public virtual PAYTABLE PAYTABLE { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS { get; set; }
    }
}
