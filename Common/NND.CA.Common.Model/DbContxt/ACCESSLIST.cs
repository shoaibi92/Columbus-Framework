namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCESSLIST")]
    public partial class ACCESSLIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCESSLIST()
        {
            GRPACCESSes = new HashSet<GRPACCESS>();
            USERACCESSes = new HashSet<USERACCESS>();
        }

        [Key]
        [StringLength(14)]
        public string ACCESS_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [StringLength(10)]
        public string ACCESSTYPE { get; set; }

        [StringLength(80)]
        public string PARENTDESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRPACCESS> GRPACCESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERACCESS> USERACCESSes { get; set; }
    }
}
