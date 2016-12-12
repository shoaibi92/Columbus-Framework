namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_DeptPostalLookup
    {
        [StringLength(3)]
        public string FSAbeforeaddingZIPcodes { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        public int? Territory_ID { get; set; }

        [StringLength(5)]
        public string FSA { get; set; }

        [Key]
        public int UID { get; set; }
    }
}
