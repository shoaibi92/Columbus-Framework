namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CRM_ContactDepts
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(14)]
        public string Contact_ID { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public int? ContactType_ID { get; set; }
    }
}
