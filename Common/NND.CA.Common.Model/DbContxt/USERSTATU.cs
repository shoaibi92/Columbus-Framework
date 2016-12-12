namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERSTATUS")]
    public partial class USERSTATU
    {
        [Key]
        [StringLength(14)]
        public string STATUS_ID { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [StringLength(1)]
        public string KICKOUT { get; set; }

        [StringLength(80)]
        public string USRMESSAGE { get; set; }

        public DateTime? LOGDATE { get; set; }

        public DateTime? POLLDATE { get; set; }

        [StringLength(1)]
        public string TEMPUSER { get; set; }

        [StringLength(80)]
        public string CURRLOC { get; set; }

        [StringLength(255)]
        public string ADDINFO { get; set; }

        [StringLength(1)]
        public string LOOKUPUSER { get; set; }

        [StringLength(1)]
        public string ALWAYSONPOC { get; set; }

        public virtual USER USER { get; set; }
    }
}
