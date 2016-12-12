namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALPACKS")]
    public partial class MEALPACK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALPACK()
        {
            CLTDEPTs = new HashSet<CLTDEPT>();
            MEALSCHEDMEALS = new HashSet<MEALSCHEDMEAL>();
            MEALVISITMEALS = new HashSet<MEALVISITMEAL>();
            KITCHDISTs = new HashSet<KITCHDIST>();
            MEALITEMS = new HashSet<MEALITEM>();
        }

        [Key]
        [StringLength(14)]
        public string PACKAGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(60)]
        public string NAME { get; set; }

        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [StringLength(1)]
        public string HOTMEAL { get; set; }

        [StringLength(1)]
        public string FROZENMEAL { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        public virtual MEALTAB MEALTAB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHEDMEAL> MEALSCHEDMEALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISITMEAL> MEALVISITMEALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KITCHDIST> KITCHDISTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALITEM> MEALITEMS { get; set; }
    }
}
