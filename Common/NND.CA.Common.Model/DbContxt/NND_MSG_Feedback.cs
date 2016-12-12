namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Feedback
    {
        [Key]
        public int UID { get; set; }

        [StringLength(15)]
        public string MSGCode { get; set; }

        [StringLength(50)]
        public string ReplyAddress { get; set; }

        [StringLength(500)]
        public string ReplyMsg { get; set; }

        public DateTime? ReplyDateTime { get; set; }
    }
}
