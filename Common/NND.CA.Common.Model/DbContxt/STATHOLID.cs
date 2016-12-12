namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STATHOLIDS")]
    public partial class STATHOLID
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATHOLID()
        {
            LBRSTATS = new HashSet<LBRSTAT>();
        }

        [Key]
        [StringLength(14)]
        public string HOLIDAY_ID { get; set; }

        [StringLength(14)]
        public string STATDEF_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCR { get; set; }

        public DateTime? STDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRSTAT> LBRSTATS { get; set; }

        public virtual STATDEF STATDEF { get; set; }
    }
}
