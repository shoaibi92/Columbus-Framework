namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_MatchResult
    {
        [Key]
        public int UID { get; set; }

        public int? NND_MSG_Inbox_UID { get; set; }

        public int? MatchType { get; set; }

        [StringLength(250)]
        public string MatchDescription { get; set; }

        [StringLength(10)]
        public string MSGCode { get; set; }
    }
}
