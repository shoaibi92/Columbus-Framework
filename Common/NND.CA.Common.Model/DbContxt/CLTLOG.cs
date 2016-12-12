namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTLOG")]
    public partial class CLTLOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTLOG()
        {
            CLTLOGCHGs = new HashSet<CLTLOGCHG>();
        }

        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string RECTYPE { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [StringLength(255)]
        public string RECINFO { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? UTCINTAKE { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTLOGCHG> CLTLOGCHGs { get; set; }
    }
}
