namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSTEMLOG")]
    public partial class SYSTEMLOG
    {
        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string LOGCODE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? UTCINTAKE { get; set; }
    }
}
