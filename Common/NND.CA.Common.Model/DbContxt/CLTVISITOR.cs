namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTVISITORS")]
    public partial class CLTVISITOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTVISITOR()
        {
            CLNTRESORCs = new HashSet<CLNTRESORC>();
            CLTDEPTs = new HashSet<CLTDEPT>();
            PAYRECORDS = new HashSet<PAYRECORD>();
        }

        [Key]
        [StringLength(14)]
        public string CLTVISITOR_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string TYPE { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTRESORC> CLNTRESORCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS { get; set; }
    }
}
