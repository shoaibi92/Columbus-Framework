namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALUSEREVENTS")]
    public partial class PORTALUSEREVENT
    {
        [Key]
        [StringLength(14)]
        public string USEREVENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string EVENTCODE { get; set; }

        public int? EVENTCOUNTER { get; set; }

        public DateTime? EVENTDATE { get; set; }

        [StringLength(8000)]
        public string EVENTDETAILS { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        public DateTime UTCINTAKE { get; set; }

        public virtual PORTALUSER PORTALUSER { get; set; }
    }
}
