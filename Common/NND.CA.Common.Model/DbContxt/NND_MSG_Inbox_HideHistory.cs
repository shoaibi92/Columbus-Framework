namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Inbox_HideHistory
    {
        [Key]
        public int UID { get; set; }

        public int? MSG_Inbox_UID { get; set; }

        public bool? Hidden { get; set; }

        [StringLength(15)]
        public string HiddenByUser { get; set; }

        public DateTime? HiddenDateTime { get; set; }
    }
}
