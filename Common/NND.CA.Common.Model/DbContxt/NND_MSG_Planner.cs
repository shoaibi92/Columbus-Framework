namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_Planner
    {
        [Key]
        public int UID { get; set; }

        [StringLength(20)]
        public string AssignedUser { get; set; }

        [StringLength(3)]
        public string DayName { get; set; }

        [StringLength(14)]
        public string Dept_ID { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(50)]
        public string ClientFirstName { get; set; }

        [StringLength(10)]
        public string Dur { get; set; }

        public DateTime? VisitStart { get; set; }

        [StringLength(25)]
        public string VisitType { get; set; }

        [StringLength(14)]
        public string Planner_ID { get; set; }

        [StringLength(14)]
        public string Visit_ID { get; set; }

        [StringLength(14)]
        public string emp_ID { get; set; }

        public int? BatchID { get; set; }

        public int? Hidden { get; set; }

        public bool? VisitIsfilled { get; set; }

        [StringLength(15)]
        public string MsgCode { get; set; }

        public DateTime? VisitFileCHGDATE { get; set; }

        public DateTime? DataPullDate { get; set; }

        public DateTime? FirstOpenVisitStart { get; set; }

        public int? NumberUnfilledVisits { get; set; }

        public int? NumberMsgSent { get; set; }

        public int? NumberFeedBackReceived { get; set; }

        public int? NumberMsgSentGrouped { get; set; }

        public int? NumberFeedBackReceivedGrouped { get; set; }

        [StringLength(10)]
        public string PayCode { get; set; }

        [StringLength(15)]
        public string AssignUserGroup { get; set; }

        [StringLength(50)]
        public string ClientLastName { get; set; }

        [StringLength(14)]
        public string AcceptedEmp_ID { get; set; }

        public DateTime? AcceptedDateTime { get; set; }

        [StringLength(20)]
        public string AcceptedByUser { get; set; }

        public bool? ClientIsFilled { get; set; }

        [StringLength(14)]
        public string CV_ID { get; set; }

        public DateTime? VisitStop { get; set; }

        [StringLength(1)]
        public string VisitStatus { get; set; }
    }
}
