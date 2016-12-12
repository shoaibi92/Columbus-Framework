namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EXPMILEAGE")]
    public partial class EXPMILEAGE
    {
        [Key]
        [StringLength(14)]
        public string EXP_ID { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(30)]
        public string RECTYPE { get; set; }

        [StringLength(1)]
        public string STANDALONE { get; set; }

        public DateTime? EXPDATE { get; set; }

        [StringLength(1)]
        public string PAID { get; set; }

        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        public decimal? PAYUNITS { get; set; }

        [StringLength(1)]
        public string BILLED { get; set; }

        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        public decimal? BILLUNITS { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(1)]
        public string EXPPAYROLL { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string PAYVAL_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string RECSUBTYPE { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        public virtual VISIT VISIT { get; set; }

        public virtual TIMEPERIOD TIMEPERIOD { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PAYRECVAL PAYRECVAL { get; set; }
    }
}
