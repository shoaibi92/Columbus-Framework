namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALPLAN")]
    public partial class MEALPLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEALPLAN()
        {
            MEALPLANDAYs = new HashSet<MEALPLANDAY>();
        }

        [Key]
        [StringLength(14)]
        public string PLAN_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        public DateTime PLANSTART { get; set; }

        public DateTime PLANSTOP { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string KITCHEN_ID { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual KITCHEN KITCHEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPLANDAY> MEALPLANDAYs { get; set; }
    }
}
