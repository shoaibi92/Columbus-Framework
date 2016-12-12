namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQMDSHCDEPENDS")]
    public partial class ASSQMDSHCDEPEND
    {
        [Key]
        [StringLength(14)]
        public string ASSQMDSHC_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string DRECTYPE { get; set; }

        [Required]
        [StringLength(10)]
        public string DEXPRESS { get; set; }

        [StringLength(80)]
        public string DVALUE { get; set; }

        [StringLength(14)]
        public string CAP_ID { get; set; }

        [StringLength(14)]
        public string MDSQUEST_ID { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual MDSCAP MDSCAP { get; set; }
    }
}
