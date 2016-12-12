namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQPATHDEPENDS")]
    public partial class ASSQPATHDEPEND
    {
        [Key]
        [StringLength(14)]
        public string ASSQPATH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [StringLength(14)]
        public string ITEM_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string DEXPRESS { get; set; }

        [StringLength(20)]
        public string DVALUE { get; set; }

        [StringLength(1)]
        public string DRECTYPE { get; set; }

        [StringLength(14)]
        public string CAT_ID { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual PATHCAT PATHCAT { get; set; }

        public virtual PATHITEM PATHITEM { get; set; }
    }
}
