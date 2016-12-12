namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_CallMeAlert
    {
        [Key]
        public int UID { get; set; }

        [StringLength(20)]
        public string AssignedUser { get; set; }

        [StringLength(14)]
        public string Call_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(30)]
        public string EMP_LASTNAME { get; set; }

        [StringLength(20)]
        public string EMP_FIRSTNAME { get; set; }

        [StringLength(12)]
        public string EMP_HOMEPHONE { get; set; }

        [StringLength(12)]
        public string EMP_CELLPHONE { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        public DateTime? LocalTime { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime? VISITSTART { get; set; }

        public DateTime? VISITSTOP { get; set; }

        public short? MinutesLate { get; set; }

        [StringLength(5)]
        public string TimeDifference { get; set; }

        [StringLength(14)]
        public string CV_ID { get; set; }

        public string Dept_ID { get; set; }

        [StringLength(100)]
        public string Dept_Name { get; set; }

        [StringLength(100)]
        public string CLIENTFULLNAME { get; set; }

        [StringLength(12)]
        public string CLIENTHOMEPHONE { get; set; }

        [StringLength(12)]
        public string CLIENTWORKPHONE { get; set; }

        public byte? BatchID { get; set; }

        [StringLength(15)]
        public string TollFree { get; set; }

        public int? Hidden { get; set; }

        [StringLength(10)]
        public string EDCTimeZone { get; set; }

        public int? CallForwardCount { get; set; }

        public DateTime? LastCallForwardDateTime { get; set; }

        [StringLength(16)]
        public string CallForwardNumber { get; set; }

        [StringLength(250)]
        public string CallForwardError { get; set; }

        [StringLength(30)]
        public string Perm_Cntry { get; set; }
    }
}
