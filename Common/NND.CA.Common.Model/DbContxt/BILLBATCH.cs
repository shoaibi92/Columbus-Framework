namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLBATCH")]
    public partial class BILLBATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLBATCH()
        {
            FUNDBATCHes = new HashSet<FUNDBATCH>();
        }

        [Key]
        [StringLength(14)]
        public string BATCH_ID { get; set; }

        public int BATCHNO { get; set; }

        [Required]
        [StringLength(30)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? CALCDATE { get; set; }

        [StringLength(255)]
        public string CALCUSER { get; set; }

        public DateTime? BBDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDBATCH> FUNDBATCHes { get; set; }
    }
}
