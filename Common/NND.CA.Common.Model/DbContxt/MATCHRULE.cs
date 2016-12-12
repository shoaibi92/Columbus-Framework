namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MATCHRULES")]
    public partial class MATCHRULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATCHRULE()
        {
            MATCHRULEDEPTS = new HashSet<MATCHRULEDEPT>();
        }

        [Key]
        [StringLength(14)]
        public string MATCHRULE_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCR { get; set; }

        public int SORTORDER { get; set; }

        public int DEFRULEWEIGHT { get; set; }

        [Column(TypeName = "text")]
        public string DEFRULEDATA { get; set; }

        [StringLength(1)]
        public string RULEREQ { get; set; }

        public int? DEFDROPRATIO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATCHRULEDEPT> MATCHRULEDEPTS { get; set; }
    }
}
