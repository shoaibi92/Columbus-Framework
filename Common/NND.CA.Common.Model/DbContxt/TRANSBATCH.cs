namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRANSBATCH")]
    public partial class TRANSBATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANSBATCH()
        {
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string TRANSBATCH_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string BATCHTYPE { get; set; }

        [Required]
        [StringLength(2)]
        public string STATUS { get; set; }

        [StringLength(100)]
        public string BATCH_ID_1 { get; set; }

        [StringLength(100)]
        public string BATCH_ID_2 { get; set; }

        [StringLength(100)]
        public string BATCH_ID_3 { get; set; }

        [Column(TypeName = "text")]
        public string PROPBAG { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }
    }
}
