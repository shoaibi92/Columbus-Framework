namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYRECVAL")]
    public partial class PAYRECVAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYRECVAL()
        {
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
        }

        [Key]
        [StringLength(14)]
        public string PAYVAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOOKUPVAL_ID { get; set; }

        [StringLength(10)]
        public string PAYCODE { get; set; }

        public decimal? PAYRATE { get; set; }

        [StringLength(5)]
        public string PAYUNITS { get; set; }

        public decimal? OTFACTOR { get; set; }

        [StringLength(10)]
        public string PREMCODE { get; set; }

        public decimal? PREMRATE { get; set; }

        [StringLength(5)]
        public string PREMUNITS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }
    }
}
