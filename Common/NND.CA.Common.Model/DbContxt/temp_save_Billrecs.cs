namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class temp_save_Billrecs
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [StringLength(10)]
        public string SERVTYPE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(10)]
        public string BILLCODE { get; set; }

        public decimal? BILLRATE { get; set; }

        [StringLength(5)]
        public string BILLUNITS { get; set; }

        [StringLength(1)]
        public string USEEMPPAY { get; set; }

        [StringLength(20)]
        public string REVCODE { get; set; }

        [StringLength(20)]
        public string EXPCODE { get; set; }

        [StringLength(10)]
        public string STATCODE { get; set; }

        public decimal? STATRATE { get; set; }

        [StringLength(5)]
        public string STATUNITS { get; set; }

        [StringLength(1)]
        public string STATEMPPAY { get; set; }

        [StringLength(20)]
        public string STATREV { get; set; }

        [StringLength(20)]
        public string STATEXP { get; set; }

        [StringLength(1)]
        public string TRAVEL { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(1)]
        public string LIVEIN { get; set; }

        [StringLength(1)]
        public string USEPAYOVER { get; set; }

        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        [StringLength(1)]
        public string SOURCE { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(1)]
        public string USETAX1 { get; set; }

        [StringLength(1)]
        public string USETAX2 { get; set; }

        [StringLength(14)]
        public string EMPPAYREC_ID { get; set; }

        [StringLength(20)]
        public string AUXCODE { get; set; }

        [StringLength(20)]
        public string REQCODE { get; set; }

        [StringLength(30)]
        public string MASTACCT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(10)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(10)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string TRX_ID { get; set; }

        public decimal? ESTCOST { get; set; }

        [StringLength(20)]
        public string RATEGROUPER { get; set; }

        [StringLength(20)]
        public string DISCIPLINE { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(14)]
        public string PARENT_ID { get; set; }

        [StringLength(1)]
        public string EXPIRED { get; set; }

        public decimal? CNTRRATE { get; set; }

        public decimal? CNTRSTATRATE { get; set; }

        [StringLength(1)]
        public string USECLIENTRATES { get; set; }
    }
}
