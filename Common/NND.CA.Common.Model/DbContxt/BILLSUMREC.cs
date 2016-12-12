namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLSUMREC")]
    public partial class BILLSUMREC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLSUMREC()
        {
            BILLINGs = new HashSet<BILLING>();
        }

        [Key]
        [StringLength(14)]
        public string SUMMARY_ID { get; set; }

        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string SUMMFORMAT { get; set; }

        public decimal? TOTSDUR { get; set; }

        public decimal? TOTSUNITS { get; set; }

        public decimal? TOTSAMT { get; set; }

        public int? ORDRULE { get; set; }

        public decimal? ORDMAX { get; set; }

        public decimal? TOTDUR { get; set; }

        public decimal? TOTHUNITS { get; set; }

        public decimal? TOTVUNITS { get; set; }

        public int? TOTVIS { get; set; }

        public int? TOTVISDAYS { get; set; }

        public int? ORDCCRULE { get; set; }

        public decimal? ORDCCMAX { get; set; }

        public decimal? TOTAMT { get; set; }

        public decimal? TOTTAX1 { get; set; }

        public decimal? TOTTAX2 { get; set; }

        public decimal? TOTAHUNITS { get; set; }

        public decimal? TOTAVUNITS { get; set; }

        public decimal? TOTADJ { get; set; }

        public decimal? TOTATAX1 { get; set; }

        public decimal? TOTATAX2 { get; set; }

        public decimal? TOTCAHUNITS { get; set; }

        public decimal? TOTCAVUNITS { get; set; }

        public decimal? TOTCADJ { get; set; }

        public decimal? TOTCATAX1 { get; set; }

        public decimal? TOTCATAX2 { get; set; }

        public DateTime? DATELAST { get; set; }

        [StringLength(10)]
        public string BILLCODE { get; set; }

        public decimal? CCVALUE { get; set; }

        public decimal? CCVALTOT { get; set; }

        public decimal? LTCAMOUNT { get; set; }

        public int? LINENUM { get; set; }

        public int? INVNUM { get; set; }

        [StringLength(7)]
        public string CCNUMBER { get; set; }

        [StringLength(3)]
        public string CARELEVEL { get; set; }

        [StringLength(5)]
        public string PROVID { get; set; }

        public DateTime? INVDATE { get; set; }

        public decimal? AUTHHOURS { get; set; }

        public decimal? SOCVALUE { get; set; }

        public decimal? SOCCOLLECT { get; set; }

        [StringLength(1)]
        public string RELATION { get; set; }

        [StringLength(8)]
        public string RECIPNUM { get; set; }

        [StringLength(9)]
        public string CLTSSN { get; set; }

        public decimal? CTRTRATE { get; set; }

        public DateTime? CLOSED { get; set; }

        [StringLength(1)]
        public string INVOICED { get; set; }

        [StringLength(1)]
        public string EXPORTAR { get; set; }

        public decimal? TOTCNTRAMT { get; set; }

        public decimal? TOTCNTRTAX1 { get; set; }

        public decimal? TOTCNTRTAX2 { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
