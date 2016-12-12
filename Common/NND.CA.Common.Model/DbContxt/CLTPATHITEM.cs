namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTPATHITEMS")]
    public partial class CLTPATHITEM
    {
        [Key]
        [StringLength(14)]
        public string PATHITEM_ID { get; set; }

        [StringLength(14)]
        public string PATHVISIT_ID { get; set; }

        [StringLength(14)]
        public string ITEM_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string COMPLETE { get; set; }

        [StringLength(14)]
        public string OPATHVISIT_ID { get; set; }

        [StringLength(14)]
        public string OSTEP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string VSUBCODE_ID { get; set; }

        public virtual CLTPATHVISIT CLTPATHVISIT { get; set; }

        public virtual CLTPATHVISIT CLTPATHVISIT1 { get; set; }

        public virtual PATHITEM PATHITEM { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }

        public virtual PATHVSUBCODE PATHVSUBCODE { get; set; }
    }
}
