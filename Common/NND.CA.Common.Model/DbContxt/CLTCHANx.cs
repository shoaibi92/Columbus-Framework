namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTCHANGES")]
    public partial class CLTCHANx
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        [Required]
        [StringLength(200)]
        public string DESCR { get; set; }

        [StringLength(200)]
        public string USERDATA { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
