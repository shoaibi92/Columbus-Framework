namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSSECTSLAYOUTS")]
    public partial class ASSSECTSLAYOUT
    {
        [Key]
        [StringLength(14)]
        public string LAYOUT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SECTION_ID { get; set; }

        public int LROW { get; set; }

        public int LCOL { get; set; }

        public decimal LPERCENT { get; set; }

        public virtual ASSSECT ASSSECT { get; set; }
    }
}
