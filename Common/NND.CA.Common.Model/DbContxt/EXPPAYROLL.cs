namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXPPAYROLL")]
    public partial class EXPPAYROLL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXPPAYROLL()
        {
            DEPARTMENTS = new HashSet<DEPARTMENT>();
        }

        [Key]
        [StringLength(14)]
        public string PAYROLL_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        [StringLength(14)]
        public string EMPNUM { get; set; }

        [StringLength(14)]
        public string CLTNUM { get; set; }

        [MaxLength(39)]
        public byte[] VALIDKEY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }

        public virtual NUMBER NUMBER { get; set; }

        public virtual NUMBER NUMBER1 { get; set; }
    }
}
