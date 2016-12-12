namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSGROUPS")]
    public partial class ASSGROUP
    {
        [Key]
        [StringLength(14)]
        public string AGROUP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string AGNAME { get; set; }

        public decimal AGLOWVALUE { get; set; }

        public decimal AGHIGHVALUE { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }
    }
}
