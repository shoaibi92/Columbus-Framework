namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Inbox
    {
        [Key]
        public int UID { get; set; }

        [StringLength(10)]
        public string EmailID { get; set; }

        [StringLength(500)]
        public string ExchMsgID { get; set; }

        [StringLength(80)]
        public string MsgSubject { get; set; }

        [StringLength(500)]
        public string MsgBody2 { get; set; }

        [StringLength(10)]
        public string MsgCode { get; set; }

        [StringLength(14)]
        public string ManualMatchByUser { get; set; }

        public DateTime? ManualMatchOnDate { get; set; }

        public DateTime? MsgReceivedDate { get; set; }

        public DateTime? MsgCreateDate { get; set; }

        [StringLength(5)]
        public string MsgType { get; set; }

        public DateTime? MsgProcessDate { get; set; }

        [StringLength(11)]
        public string MsgSeriesCode { get; set; }

        [StringLength(150)]
        public string MSGSenderAddress { get; set; }

        [StringLength(14)]
        public string Emp_ID { get; set; }

        [StringLength(20)]
        public string AssignedUser { get; set; }

        public bool? Hidden { get; set; }

        [StringLength(30)]
        public string ProcessCountry { get; set; }

        [StringLength(5000)]
        public string MsgBody { get; set; }
    }
}
