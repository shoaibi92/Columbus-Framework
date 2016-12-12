namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DISTRICTS")]
    public partial class DISTRICT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTRICT()
        {
            CLTDEPTs = new HashSet<CLTDEPT>();
            EMPDISTs = new HashSet<EMPDIST>();
            KITCHDISTs = new HashSet<KITCHDIST>();
            ROUTES = new HashSet<ROUTE>();
        }

        [Key]
        [StringLength(14)]
        public string DISTRICT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [StringLength(40)]
        public string ADDR1 { get; set; }

        [StringLength(40)]
        public string ADDR2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROV { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(30)]
        public string CONTACT { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(10)]
        public string EXT { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(14)]
        public string DEFKITCH_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual KITCHEN KITCHEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDIST> EMPDISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KITCHDIST> KITCHDISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUTE> ROUTES { get; set; }
    }
}
