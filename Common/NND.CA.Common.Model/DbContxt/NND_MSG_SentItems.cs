namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_MSG_SentItems
    {
        [Key]
        public int UID { get; set; }

        [StringLength(14)]
        public string dept_ID { get; set; }

        [StringLength(15)]
        public string MSGCode { get; set; }

        [StringLength(20)]
        public string SPOC { get; set; }

        [StringLength(5000)]
        public string MSGBody { get; set; }

        public DateTime? MSGSentDateTime { get; set; }

        [StringLength(20)]
        public string MSGSentByUser { get; set; }

        [StringLength(14)]
        public string Client_ID { get; set; }

        public int? MSG_Planner_UID { get; set; }

        public int? MSGSendType { get; set; }
    }
}
