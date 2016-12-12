namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTPATHITEMSX")]
    public partial class CLTPATHITEMSX
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string ITEM_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECACTION { get; set; }

        [StringLength(14)]
        public string STEP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLTPATHWAY CLTPATHWAY { get; set; }

        public virtual PATHITEM PATHITEM { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }
    }
}
