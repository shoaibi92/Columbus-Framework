namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_DatedNoteExcludedDepts
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        public DateTime? ExcludeDateTimeStamp { get; set; }

        [StringLength(10)]
        public string ExcludedBy { get; set; }
    }
}
