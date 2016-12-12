namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDBATCH")]
    public partial class FUNDBATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNDBATCH()
        {
            FUNDEPTPERs = new HashSet<FUNDEPTPER>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string BATCH_ID { get; set; }

        public virtual BILLBATCH BILLBATCH { get; set; }

        public virtual FUNDDEPT FUNDDEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDEPTPER> FUNDEPTPERs { get; set; }
    }
}
