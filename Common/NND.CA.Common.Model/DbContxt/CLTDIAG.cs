namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTDIAG")]
    public partial class CLTDIAG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTDIAG()
        {
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string CLTDIAG_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string DIAGNOS_ID { get; set; }

        public DateTime? REPORTDATE { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? DIAGNSDATE { get; set; }

        [StringLength(20)]
        public string SEVCODE { get; set; }

        [StringLength(30)]
        public string HISTOUTCOM { get; set; }

        [StringLength(20)]
        public string HISTCODE { get; set; }

        public DateTime? HISTDATE { get; set; }

        [StringLength(20)]
        public string DISCODE { get; set; }

        [StringLength(10)]
        public string CODETYPE { get; set; }

        [StringLength(300)]
        public string DESCR { get; set; }

        [StringLength(20)]
        public string INTERVENT { get; set; }

        [StringLength(20)]
        public string CODE { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(1)]
        public string ONSET { get; set; }

        [StringLength(1)]
        public string DEPTDIAG { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual DIAGNOSI DIAGNOSI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }
    }
}
