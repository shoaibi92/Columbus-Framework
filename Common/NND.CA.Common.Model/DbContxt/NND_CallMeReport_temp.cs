namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallMeReport_temp
    {
        [StringLength(56)]
        public string Location { get; set; }

        [Key]
        [Column("Emp name", Order = 0)]
        [StringLength(51)]
        public string Emp_name { get; set; }

        [Column("Visit start")]
        [StringLength(20)]
        public string Visit_start { get; set; }

        [Column("Visit stop")]
        [StringLength(20)]
        public string Visit_stop { get; set; }

        [Column("Local Time")]
        [StringLength(20)]
        public string Local_Time { get; set; }

        [Column("CallMe popup")]
        [StringLength(51)]
        public string CallMe_popup { get; set; }

        [Column("Hidden on")]
        [StringLength(20)]
        public string Hidden_on { get; set; }

        [Column("CSC Agent and action date stamp")]
        [StringLength(43)]
        public string CSC_Agent_and_action_date_stamp { get; set; }

        [Column("CallMe Start")]
        [StringLength(20)]
        public string CallMe_Start { get; set; }

        [Column("CallMe Stop")]
        [StringLength(20)]
        public string CallMe_Stop { get; set; }

        [Column("Telephony received")]
        [StringLength(20)]
        public string Telephony_received { get; set; }

        [Key]
        [Column("Caring Consult Visit", Order = 1)]
        [StringLength(3)]
        public string Caring_Consult_Visit { get; set; }

        [Key]
        [Column("Dummy Visit (< 5 mins)", Order = 2)]
        [StringLength(5)]
        public string Dummy_Visit____5_mins_ { get; set; }

        [Key]
        [Column("Double Visits", Order = 3)]
        [StringLength(10)]
        public string Double_Visits { get; set; }

        [StringLength(10)]
        public string EDCTimeZone { get; set; }

        [StringLength(12)]
        public string HOMEPHONE { get; set; }

        [StringLength(12)]
        public string CELLPHONE { get; set; }

        [Key]
        [Column("Client Name", Order = 4)]
        [StringLength(51)]
        public string Client_Name { get; set; }

        public double? TimeDifference { get; set; }

        [Column("Client Home Phone")]
        [StringLength(12)]
        public string Client_Home_Phone { get; set; }

        [Column("Client Work Phone")]
        [StringLength(12)]
        public string Client_Work_Phone { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string CV_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Column("CSC Agent")]
        [StringLength(20)]
        public string CSC_Agent { get; set; }

        [Column("CSC Date stamp")]
        public DateTime? CSC_Date_stamp { get; set; }
    }
}
