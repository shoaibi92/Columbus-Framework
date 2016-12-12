namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHSTEPITEMLINKS")]
    public partial class PATHSTEPITEMLINK
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string PARENTITEM_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CHILDITEM_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string STEP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual PATHITEM PATHITEM { get; set; }

        public virtual PATHITEM PATHITEM1 { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }
    }
}
