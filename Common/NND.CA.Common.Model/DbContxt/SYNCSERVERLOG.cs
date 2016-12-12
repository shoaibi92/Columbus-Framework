namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYNCSERVERLOG")]
    public partial class SYNCSERVERLOG
    {
        [Key]
        [StringLength(14)]
        public string SYNCLOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCR { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string SYNCLOG { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual SYNCSERVER SYNCSERVER { get; set; }
    }
}
