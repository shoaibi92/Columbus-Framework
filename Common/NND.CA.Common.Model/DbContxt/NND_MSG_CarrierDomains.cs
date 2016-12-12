namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_CarrierDomains
    {
        [Key]
        public int UID { get; set; }

        [StringLength(50)]
        public string Carrier { get; set; }

        [StringLength(50)]
        public string domain { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
    }
}
