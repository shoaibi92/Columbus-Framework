namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDPLANCANCEL")]
    public partial class ORDPLANCANCEL
    {
        [Key]
        [StringLength(14)]
        public string ORDPLANCANCEL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDPLAN_ID { get; set; }

        public DateTime? SENTDATE { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [Column(TypeName = "text")]
        public string REFDATA { get; set; }

        public virtual ORDPLAN ORDPLAN { get; set; }
    }
}
