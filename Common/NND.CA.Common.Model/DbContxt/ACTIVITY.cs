namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACTIVITY")]
    public partial class ACTIVITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTIVITY()
        {
            CLTACTCs = new HashSet<CLTACTC>();
            CLTACTVs = new HashSet<CLTACTV>();
            SERVREQS = new HashSet<SERVREQ>();
        }

        [Key]
        [StringLength(14)]
        public string ACTIVITY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SERVICE_ID { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(20)]
        public string REFNUMBER { get; set; }

        [StringLength(80)]
        public string DEFCOMMENT { get; set; }

        [Column(TypeName = "text")]
        public string DEFDESCR { get; set; }

        [StringLength(1)]
        public string BILLSUB { get; set; }

        [StringLength(1)]
        public string PRICETYPE { get; set; }

        public decimal? FIXEDPRICE { get; set; }

        public decimal? HOURPRICE { get; set; }

        public decimal? BILLDUR { get; set; }

        public decimal? PAYDUR { get; set; }

        [StringLength(10)]
        public string DEFMON { get; set; }

        [StringLength(10)]
        public string DEFTUES { get; set; }

        [StringLength(10)]
        public string DEFWED { get; set; }

        [StringLength(10)]
        public string DEFTHURS { get; set; }

        [StringLength(10)]
        public string DEFFRI { get; set; }

        [StringLength(10)]
        public string DEFSATUR { get; set; }

        [StringLength(10)]
        public string DEFSUN { get; set; }

        [StringLength(1)]
        public string FREQTYPE { get; set; }

        [StringLength(1)]
        public string DAYFREQ { get; set; }

        public DateTime? TIMEONE { get; set; }

        public DateTime? TIMETWO { get; set; }

        public DateTime? TIMETHREE { get; set; }

        public DateTime? TIMEFOUR { get; set; }

        public int? OTHFREQ { get; set; }

        [StringLength(10)]
        public string OTHFRQTYPE { get; set; }

        [StringLength(14)]
        public string GOALTAB_ID { get; set; }

        [StringLength(14)]
        public string OUTTABLE_ID { get; set; }

        [StringLength(1)]
        public string USEBILLREC { get; set; }

        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [StringLength(1)]
        public string ASSENABLED { get; set; }

        [StringLength(1)]
        public string ASSDURATIONS { get; set; }

        [StringLength(1)]
        public string ASSFREQ { get; set; }

        [StringLength(1)]
        public string ASSCOMMENTS { get; set; }

        [StringLength(1)]
        public string ASSDESCR { get; set; }

        [StringLength(1)]
        public string ASSGOAL { get; set; }

        [StringLength(1)]
        public string ASSOUTCOME { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public int? EDCCODE { get; set; }

        [StringLength(30)]
        public string AUXCODE { get; set; }

        public virtual SERVICE SERVICE { get; set; }

        public virtual OUTTABLE OUTTABLE { get; set; }

        public virtual OUTTABLE OUTTABLE1 { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTC> CLTACTCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTACTV> CLTACTVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVREQ> SERVREQS { get; set; }
    }
}
