namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_VAN_VISITS
    {
        [Key]
        [Column(Order = 0)]
        public int UID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(2)]
        public string VISITTYPE { get; set; }

        public DateTime? VISITSTART { get; set; }

        public DateTime? VISITSTOP { get; set; }

        [StringLength(14)]
        public string SHIFTCODE { get; set; }

        public decimal? DURATION { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? PAYDUR { get; set; }

        [StringLength(1)]
        public string ESSERVICE { get; set; }

        [StringLength(1)]
        public string DIRECT { get; set; }

        [StringLength(1)]
        public string PAYABLE { get; set; }

        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        [StringLength(1)]
        public string BILLABLE { get; set; }

        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        [StringLength(80)]
        public string STATREASON { get; set; }

        [StringLength(1)]
        public string NONOTICE { get; set; }

        [StringLength(1)]
        public string EMPCONFIRM { get; set; }

        [StringLength(1)]
        public string CLTCONFIRM { get; set; }

        [StringLength(1)]
        public string KEEPONPLAN { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string TIMESTATUS { get; set; }

        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(1)]
        public string RECSOURCE { get; set; }

        [StringLength(14)]
        public string CV_ID { get; set; }

        [StringLength(1)]
        public string PERMVIS { get; set; }

        [StringLength(1)]
        public string REFCON { get; set; }

        [StringLength(10)]
        public string PAYCODE { get; set; }

        public decimal? PAYRATE { get; set; }

        [StringLength(5)]
        public string PAYUNITS { get; set; }

        [StringLength(1)]
        public string EXPPAYROLL { get; set; }

        [StringLength(1)]
        public string EXCLUDETK { get; set; }

        [StringLength(10)]
        public string PRICODE { get; set; }

        [StringLength(10)]
        public string PAYRTCODE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? SORTDATE { get; set; }

        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [StringLength(10)]
        public string VREF { get; set; }

        [StringLength(14)]
        public string EMP_ID2 { get; set; }

        [StringLength(1)]
        public string OFFERSTATUS { get; set; }

        [StringLength(1)]
        public string VRECTYPE { get; set; }

        public DateTime? UTCINTAKE { get; set; }

        public DateTime? UTCCHGDATE { get; set; }

        public DateTime? RunDate { get; set; }
    }
}
