namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIMECHANGE")]
    public partial class TIMECHANGE
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOG_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string FIELDNAME { get; set; }

        [Required]
        [StringLength(30)]
        public string OLDVALUE { get; set; }

        [Required]
        [StringLength(30)]
        public string NEWVALUE { get; set; }

        public virtual TIMELOG TIMELOG { get; set; }
    }
}
