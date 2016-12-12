namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUPERVISORS")]
    public partial class SUPERVISOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPERVISOR()
        {
            CLTSUPERS = new HashSet<CLTSUPER>();
            CLTSUPREQs = new HashSet<CLTSUPREQ>();
            EMPSUPERS = new HashSet<EMPSUPER>();
            EMPSUPREQs = new HashSet<EMPSUPREQ>();
            VALIDSUPERs = new HashSet<VALIDSUPER>();
        }

        [Key]
        [StringLength(14)]
        public string SUPER_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPER> CLTSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPREQ> CLTSUPREQs { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPER> EMPSUPERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPREQ> EMPSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VALIDSUPER> VALIDSUPERs { get; set; }
    }
}
