namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEALVISITMEALS")]
    public partial class MEALVISITMEAL
    {
        [Key]
        [StringLength(14)]
        public string VISMEAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PACKAGE_ID { get; set; }

        [StringLength(14)]
        public string TYPE_ID { get; set; }

        public int MEALUNITS { get; set; }

        [StringLength(1)]
        public string BILLABLE { get; set; }

        [StringLength(14)]
        public string VISSMEAL_ID { get; set; }

        [StringLength(14)]
        public string KITCHEN_ID { get; set; }

        public virtual DIETTYPE DIETTYPE { get; set; }

        public virtual KITCHEN KITCHEN { get; set; }

        public virtual MEALPACK MEALPACK { get; set; }

        public virtual MEALSCHEDMEAL MEALSCHEDMEAL { get; set; }

        public virtual MEALVISIT MEALVISIT { get; set; }
    }
}
