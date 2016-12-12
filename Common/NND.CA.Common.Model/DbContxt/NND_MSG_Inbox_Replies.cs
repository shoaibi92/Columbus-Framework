namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Inbox_Replies
    {
        [Key]
        public int UID { get; set; }

        [StringLength(500)]
        public string MSGBody { get; set; }

        public DateTime? MSGSaveDateTime { get; set; }

        [StringLength(30)]
        public string MSGSentByUser { get; set; }

        [StringLength(50)]
        public string EmpMSGAddress { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        public int? SendResult { get; set; }

        public int? SendAttemptCount { get; set; }

        public int? MSG_SentItems_Recipients_UID { get; set; }

        public int? MSG_Inbox_UID { get; set; }

        public DateTime? ActualMSGSendDate { get; set; }
    }
}
