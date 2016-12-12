namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOGUSER")]
    public partial class LOGUSER
    {
        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(255)]
        public string RECREASON { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public DateTime? UTCINTAKE { get; set; }

        public virtual USER USER { get; set; }
    }
}
