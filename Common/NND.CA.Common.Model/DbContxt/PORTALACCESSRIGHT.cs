namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALACCESSRIGHTS")]
    public partial class PORTALACCESSRIGHT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PORTALACCESSRIGHT()
        {
            PORTALGROUPACCESSes = new HashSet<PORTALGROUPACCESS>();
        }

        [Key]
        [StringLength(14)]
        public string ACCESS_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string ACCESSTYPE { get; set; }

        [StringLength(80)]
        public string PARENTDESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALGROUPACCESS> PORTALGROUPACCESSes { get; set; }
    }
}
