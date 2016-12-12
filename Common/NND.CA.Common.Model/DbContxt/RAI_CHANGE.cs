namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RAI_CHANGE
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(255)]
        public string OLDVALUE { get; set; }

        [StringLength(255)]
        public string NEWVALUE { get; set; }

        public virtual RAI_LOG RAI_LOG { get; set; }
    }
}
