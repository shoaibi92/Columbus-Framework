namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Inbox_AssignHistory
    {
        [Key]
        public int UID { get; set; }

        public DateTime? DateTimeStamp { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        public bool? Assigned { get; set; }

        public int? MSG_Inbox_UID { get; set; }
    }
}
