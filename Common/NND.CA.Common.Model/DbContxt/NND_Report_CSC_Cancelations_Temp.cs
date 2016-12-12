namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NND_Report_CSC_Cancelations_Temp
    {
        [StringLength(20)]
        public string name { get; set; }

        [StringLength(14)]
        public string dept_id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string visit_id { get; set; }

        [StringLength(1)]
        public string vstatus { get; set; }

        public DateTime? visitstart { get; set; }

        public DateTime? visstop { get; set; }

        public decimal? visdur { get; set; }

        public decimal? vbilldur { get; set; }

        public decimal? vpaydur { get; set; }

        [StringLength(14)]
        public string PayRec_ID { get; set; }

        [StringLength(10)]
        public string vpaycode { get; set; }

        public decimal? vpayrate { get; set; }

        [StringLength(10)]
        public string vpayrtcode { get; set; }

        [StringLength(14)]
        public string vshift { get; set; }

        [StringLength(5)]
        public string vpayunits { get; set; }

        [StringLength(1)]
        public string vbillable { get; set; }

        [StringLength(1)]
        public string vpayable { get; set; }

        [StringLength(1)]
        public string vtimestatus { get; set; }

        [StringLength(30)]
        public string vreason { get; set; }

        [StringLength(1)]
        public string vnonotice { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string clastname { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string cfirstname { get; set; }

        [StringLength(20)]
        public string cmiddle { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(14)]
        public string ccltid { get; set; }

        [StringLength(5)]
        public string carea { get; set; }

        [StringLength(40)]
        public string caddr1 { get; set; }

        [StringLength(40)]
        public string caddr2 { get; set; }

        [StringLength(30)]
        public string ccity { get; set; }

        [StringLength(3)]
        public string cprov { get; set; }

        [StringLength(10)]
        public string cpost { get; set; }

        [StringLength(30)]
        public string elastname { get; set; }

        [StringLength(20)]
        public string efirstname { get; set; }

        [StringLength(20)]
        public string emiddle { get; set; }

        [StringLength(14)]
        public string eempid { get; set; }

        [StringLength(5)]
        public string earea { get; set; }

        [StringLength(12)]
        public string chomephone { get; set; }

        [StringLength(12)]
        public string cworkphone { get; set; }

        [StringLength(10)]
        public string cworkext { get; set; }

        [StringLength(20)]
        public string ocoordname { get; set; }

        [StringLength(5)]
        public string bbillunits { get; set; }

        public decimal? bbillrate { get; set; }

        public DateTime? cdstart { get; set; }
    }
}
