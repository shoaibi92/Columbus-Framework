namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYNCSERVER")]
    public partial class SYNCSERVER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYNCSERVER()
        {
            SYNCSERVERLOGs = new HashSet<SYNCSERVERLOG>();
        }

        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCR { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] SYNCDATA { get; set; }

        public int ERRCOUNT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? PROCDATE { get; set; }

        [StringLength(255)]
        public string PROCUSER { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(100)]
        public string USERHASH { get; set; }

        public DateTime? SYNCDATE { get; set; }

        [StringLength(255)]
        public string SYNCUSER { get; set; }

        public int? SYNCTIME { get; set; }

        public int? PROCTIME { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYNCSERVERLOG> SYNCSERVERLOGs { get; set; }
    }
}
