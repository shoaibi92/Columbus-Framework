namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MDSHCCAPS")]
    public partial class MDSHCCAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CAP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(2)]
        public string TRIGGER_REASON { get; set; }

        public virtual MD MD { get; set; }

        public virtual MDSCAP MDSCAP { get; set; }
    }
}
