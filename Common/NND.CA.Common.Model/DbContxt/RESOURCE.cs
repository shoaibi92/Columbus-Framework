namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RESOURCES")]
    public partial class RESOURCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESOURCE()
        {
            CLNTRESORCs = new HashSet<CLNTRESORC>();
            EMPSUBCATS = new HashSet<EMPSUBCAT>();
        }

        [Key]
        [StringLength(14)]
        public string RES_ID { get; set; }

        [StringLength(1)]
        public string RESTYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLNTRESORC> CLNTRESORCs { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUBCAT> EMPSUBCATS { get; set; }

        public virtual RESVI RESVI { get; set; }
    }
}
