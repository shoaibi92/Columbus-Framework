namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_SMS_Recipients
    {
        [Key]
        public int UID { get; set; }

        public int? MSG_SMS_UID { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(50)]
        public string EmpMsgAddress { get; set; }

        public int? SendResult { get; set; }

        public DateTime? ActualMSGSendDate { get; set; }

        public int? SendAttemptCount { get; set; }
    }
}
