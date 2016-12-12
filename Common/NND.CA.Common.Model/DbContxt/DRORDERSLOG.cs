namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRORDERSLOG")]
    public partial class DRORDERSLOG
    {
        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DRORDER_ID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] LOGDATA { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string SENT { get; set; }

        public DateTime? SENTDATE { get; set; }

        [StringLength(1)]
        public string DATAEXISTS { get; set; }

        [StringLength(10)]
        public string RECTYPE { get; set; }

        [StringLength(200)]
        public string STATREASON { get; set; }

        public virtual DRORDER DRORDER { get; set; }

        public virtual DRORDERSLOGDATA DRORDERSLOGDATA { get; set; }
    }
}
