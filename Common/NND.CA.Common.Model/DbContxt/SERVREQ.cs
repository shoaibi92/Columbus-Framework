namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVREQS")]
    public partial class SERVREQ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVREQ()
        {
            CLTSERVS = new HashSet<CLTSERV>();
            EMPSERVS = new HashSet<EMPSERV>();
            REQDEFS = new HashSet<REQDEF>();
            ACTIVITies = new HashSet<ACTIVITY>();
        }

        [Key]
        [StringLength(14)]
        public string SERV_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [Column(TypeName = "text")]
        public string DETDESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSERV> CLTSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSERV> EMPSERVS { get; set; }

        public virtual SERVREQTAB SERVREQTAB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQDEF> REQDEFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVITY> ACTIVITies { get; set; }
    }
}
