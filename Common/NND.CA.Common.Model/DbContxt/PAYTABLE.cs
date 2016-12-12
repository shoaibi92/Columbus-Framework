namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYTABLES")]
    public partial class PAYTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYTABLE()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
            LBRPAYTABS = new HashSet<LBRPAYTAB>();
            PAYLEVELS = new HashSet<PAYLEVEL>();
        }

        [Key]
        [StringLength(14)]
        public string PAYTAB_ID { get; set; }

        [StringLength(20)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string EMPINACTIVE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRPAYTAB> LBRPAYTABS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYLEVEL> PAYLEVELS { get; set; }
    }
}
