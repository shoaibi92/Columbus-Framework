namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_DatedNoteExcludedUsers
    {
        [Key]
        public int UID { get; set; }

        [StringLength(10)]
        public string CHGUser { get; set; }

        public DateTime? ExcludeDateTimeStamp { get; set; }

        [StringLength(50)]
        public string ExcludedBY { get; set; }
    }
}
