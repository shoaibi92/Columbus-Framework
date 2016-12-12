namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_FPGroups
    {
        [Key]
        public int UID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public byte? WindowType { get; set; }

        public int? SplitterDistance { get; set; }

        public bool? ShowWindowTypeButtons { get; set; }

        public int? PullDataFrom { get; set; }

        public int? PullDataUntil { get; set; }
    }
}
