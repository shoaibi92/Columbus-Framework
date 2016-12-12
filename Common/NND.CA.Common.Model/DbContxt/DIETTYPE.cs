namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIETTYPE")]
    public partial class DIETTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIETTYPE()
        {
            CLTDEPTs = new HashSet<CLTDEPT>();
            MEALSCHEDMEALS = new HashSet<MEALSCHEDMEAL>();
            MEALVISITMEALS = new HashSet<MEALVISITMEAL>();
        }

        [Key]
        [StringLength(14)]
        public string TYPE_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [Column("DIETTYPE")]
        [StringLength(30)]
        public string DIETTYPE1 { get; set; }

        [StringLength(1)]
        public string DESSERT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALSCHEDMEAL> MEALSCHEDMEALS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALVISITMEAL> MEALVISITMEALS { get; set; }
    }
}
