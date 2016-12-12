namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Reminders
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        public bool? CallMeTextReminderSent { get; set; }

        public DateTime? CallMeTextReminderSentDateTime { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(50)]
        public string EmpMsgAddress { get; set; }

        public int? ReminderType { get; set; }

        [StringLength(500)]
        public string MSGBody { get; set; }
    }
}
