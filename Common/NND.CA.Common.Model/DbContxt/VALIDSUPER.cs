namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VALIDSUPER")]
    public partial class VALIDSUPER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VALIDSUPER()
        {
            SUPERTYPES = new HashSet<SUPERTYPE>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string SUPER_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPERTYPE> SUPERTYPES { get; set; }

        public virtual SUPERVISOR SUPERVISOR { get; set; }
    }
}
