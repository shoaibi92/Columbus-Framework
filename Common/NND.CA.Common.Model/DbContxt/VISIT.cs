namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISITS")]
    public partial class VISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VISIT()
        {
            BILLINGs = new HashSet<BILLING>();
            CLTACTVs = new HashSet<CLTACTV>();
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTPATHVISITS = new HashSet<CLTPATHVISIT>();
            CLTSERVS = new HashSet<CLTSERV>();
            CLTSUPREQs = new HashSet<CLTSUPREQ>();
            EDCVISITS = new HashSet<EDCVISIT>();
            EMPFRMS = new HashSet<EMPFRM>();
            EMPSUPREQs = new HashSet<EMPSUPREQ>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            Oases = new HashSet<OASIS>();
            OVERSERVs = new HashSet<OVERSERV>();
            TIMELOGs = new HashSet<TIMELOG>();
            VISITOFFERLISTS = new HashSet<VISITOFFERLIST>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
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

        public string PROPS { get; set; }

        [StringLength(14)]
        public string ORDPLAN_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTV> CLTACTVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSERV> CLTSERVS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSUPREQ> CLTSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EDCVISIT> EDCVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPSUPREQ> EMPSUPREQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        public virtual ORDER ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual RESVI RESVI { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        public virtual SCHGROUP SCHGROUP { get; set; }

        public virtual SHIFTCODE SHIFTCODE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMELOG> TIMELOGs { get; set; }

        public virtual TIMEPERIOD TIMEPERIOD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISITOFFERLIST> VISITOFFERLISTS { get; set; }

        public virtual VISIT VISITS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
