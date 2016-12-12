namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIAGNOSIS")]
    public partial class DIAGNOSI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIAGNOSI()
        {
            CLTDIAGs = new HashSet<CLTDIAG>();
        }

        [Key]
        [StringLength(14)]
        public string DIAGNOS_ID { get; set; }

        [StringLength(10)]
        public string CODETYPE { get; set; }

        [StringLength(20)]
        public string CODE { get; set; }

        [StringLength(300)]
        public string DESCR { get; set; }

        [StringLength(20)]
        public string INTERVENT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public string PROPS { get; set; }

        [StringLength(2)]
        public string HCWARNING { get; set; }

        public string HCWARNINGMSG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDIAG> CLTDIAGs { get; set; }
    }
}
