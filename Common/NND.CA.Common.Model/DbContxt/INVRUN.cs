namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVRUNS")]
    public partial class INVRUN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVRUN()
        {
            INVPERIODS = new HashSet<INVPERIOD>();
        }

        [Key]
        [StringLength(14)]
        public string INVRUN_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVPERIOD> INVPERIODS { get; set; }
    }
}
