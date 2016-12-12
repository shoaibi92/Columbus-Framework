namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALUSERCHANGES")]
    public partial class PORTALUSERCHANx
    {
        [Key]
        [StringLength(14)]
        public string CHANGE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        [Required]
        [StringLength(200)]
        public string DESCR { get; set; }

        [StringLength(200)]
        public string USERDATA { get; set; }

        public virtual PORTALUSER PORTALUSER { get; set; }
    }
}
