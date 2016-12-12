namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSAPPSLOG")]
    public partial class SYSAPPSLOG
    {
        [Key]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SYSAPP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(200)]
        public string DESCR { get; set; }

        public int LOGCOUNTER { get; set; }

        public virtual SYSAPP SYSAPP { get; set; }
    }
}
