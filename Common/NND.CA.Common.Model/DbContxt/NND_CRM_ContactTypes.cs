namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CRM_ContactTypes
    {
        [Key]
        public int UID { get; set; }

        public int? ContactType_ID { get; set; }

        [StringLength(20)]
        public string ContactTypeName { get; set; }
    }
}
