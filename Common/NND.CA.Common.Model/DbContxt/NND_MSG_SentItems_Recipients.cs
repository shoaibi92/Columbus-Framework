namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_SentItems_Recipients
    {
        [Key]
        public int UID { get; set; }

        public int? MSG_SentItems_UID { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(50)]
        public string EmpMsgAddress { get; set; }

        public bool? CourtesyFollowUpSent { get; set; }

        public DateTime? CourtesyFollowUpSentDateTime { get; set; }

        public bool? SendMSGCancelled { get; set; }

        public int? SendResult { get; set; }

        public DateTime? ActualMSGSendDate { get; set; }

        public int? SendAttemptCount { get; set; }

        public int? CourtesyFollowUpSendResult { get; set; }

        public int? CourtesyFollowUpSendAttemptCount { get; set; }
    }
}
