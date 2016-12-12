namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQDEPENDS")]
    public partial class ASSQDEPEND
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASSQDEPEND()
        {
            ASSQADEPENDS = new HashSet<ASSQADEPEND>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DQUESTION_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string DEXPRESS { get; set; }

        [StringLength(80)]
        public string DVALUE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQADEPEND> ASSQADEPENDS { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual ASSQUEST ASSQUEST1 { get; set; }
    }
}
