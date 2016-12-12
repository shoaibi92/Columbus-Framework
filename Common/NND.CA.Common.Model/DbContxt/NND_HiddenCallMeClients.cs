namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_HiddenCallMeClients
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime? DATETIMESTAMP { get; set; }

        [StringLength(20)]
        public string USERNAME { get; set; }
    }
}
