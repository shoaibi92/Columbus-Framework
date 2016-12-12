namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CRM_Area
    {
        [Key]
        public int UID { get; set; }

        [StringLength(10)]
        public string PostalZIP { get; set; }

        [StringLength(6)]
        public string Country { get; set; }

        [StringLength(26)]
        public string ProvState { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(3)]
        public string NPA { get; set; }

        [StringLength(3)]
        public string NXX { get; set; }
    }
}
