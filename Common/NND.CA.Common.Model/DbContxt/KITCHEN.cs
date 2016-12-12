namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KITCHENS")]
    public partial class KITCHEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KITCHEN()
        {
            DISTRICTS = new HashSet<DISTRICT>();
            KITCHDISTs = new HashSet<KITCHDIST>();
            MEALPLANs = new HashSet<MEALPLAN>();
            MEALSCHEDMEALS = new HashSet<MEALSCHEDMEAL>();
            MEALVISITMEALS = new HashSet<MEALVISITMEAL>();
        }

        [Key]
        [StringLength(14)]
        public string KITCHEN_ID { get; set; }

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

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISTRICT> DISTRICTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KITCHDIST> KITCHDISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPLAN> MEALPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHEDMEAL> MEALSCHEDMEALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISITMEAL> MEALVISITMEALS { get; set; }
    }
}
