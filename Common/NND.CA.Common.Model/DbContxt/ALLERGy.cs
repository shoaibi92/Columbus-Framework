namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ALLERGIES")]
    public partial class ALLERGy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALLERGy()
        {
            CLTALLERGIES = new HashSet<CLTALLERGy>();
        }

        [Key]
        [StringLength(14)]
        public string ALERGY_ID { get; set; }

        [StringLength(5)]
        public string CODE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(30)]
        public string INTERVENT { get; set; }

        [StringLength(10)]
        public string TYPE { get; set; }

        [StringLength(15)]
        public string DEGREE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTALLERGy> CLTALLERGIES { get; set; }
    }
}
