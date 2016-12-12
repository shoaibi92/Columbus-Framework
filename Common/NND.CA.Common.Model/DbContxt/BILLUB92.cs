namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BILLUB92
    {
        [Key]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [StringLength(30)]
        public string FL02 { get; set; }

        [StringLength(3)]
        public string FL04_TYPE { get; set; }

        [StringLength(30)]
        public string FL05_TAX { get; set; }

        [StringLength(5)]
        public string FL07_COVD { get; set; }

        [StringLength(5)]
        public string FL08_NCD { get; set; }

        [StringLength(5)]
        public string FL09_CID { get; set; }

        [StringLength(5)]
        public string FL10_LRD { get; set; }

        [StringLength(30)]
        public string FL11 { get; set; }

        [StringLength(30)]
        public string FL12_LAST { get; set; }

        [StringLength(20)]
        public string FL12_FIRST { get; set; }

        [StringLength(20)]
        public string FL12_MIDDLE { get; set; }

        [StringLength(40)]
        public string FL13_ADDR1 { get; set; }

        [StringLength(40)]
        public string FL13_ADDR2 { get; set; }

        [StringLength(30)]
        public string FL13_CITY { get; set; }

        [StringLength(3)]
        public string FL13_STATE { get; set; }

        [StringLength(10)]
        public string FL13_ZIP { get; set; }

        [StringLength(2)]
        public string FL22_STATUS { get; set; }

        [StringLength(2)]
        public string FL24_CC { get; set; }

        [StringLength(2)]
        public string FL25_CC { get; set; }

        [StringLength(2)]
        public string FL26_CC { get; set; }

        [StringLength(2)]
        public string FL27_CC { get; set; }

        [StringLength(2)]
        public string FL28_CC { get; set; }

        [StringLength(2)]
        public string FL29_CC { get; set; }

        [StringLength(2)]
        public string FL30_CC { get; set; }

        [StringLength(30)]
        public string FL31 { get; set; }

        [StringLength(2)]
        public string FL32A_CODE { get; set; }

        public DateTime? FL32A_DATE { get; set; }

        [StringLength(2)]
        public string FL32B_CODE { get; set; }

        public DateTime? FL32B_DATE { get; set; }

        [StringLength(2)]
        public string FL33A_CODE { get; set; }

        public DateTime? FL33A_DATE { get; set; }

        [StringLength(2)]
        public string FL33B_CODE { get; set; }

        public DateTime? FL33B_DATE { get; set; }

        [StringLength(2)]
        public string FL34A_CODE { get; set; }

        public DateTime? FL34A_DATE { get; set; }

        [StringLength(2)]
        public string FL34B_CODE { get; set; }

        public DateTime? FL34B_DATE { get; set; }

        [StringLength(2)]
        public string FL35A_CODE { get; set; }

        public DateTime? FL35A_DATE { get; set; }

        [StringLength(2)]
        public string FL35B_CODE { get; set; }

        public DateTime? FL35B_DATE { get; set; }

        [StringLength(2)]
        public string FL36A_CODE { get; set; }

        public DateTime? FL36A_DATEFR { get; set; }

        public DateTime? FL36A_DATETO { get; set; }

        [StringLength(2)]
        public string FL36B_CODE { get; set; }

        public DateTime? FL36B_DATEFR { get; set; }

        public DateTime? FL36B_DATETO { get; set; }

        [StringLength(20)]
        public string FL38_FIRST { get; set; }

        [StringLength(30)]
        public string FL38_LAST { get; set; }

        [StringLength(40)]
        public string FL38_ADDR1 { get; set; }

        [StringLength(40)]
        public string FL38_ADDR2 { get; set; }

        [StringLength(30)]
        public string FL38_CITY { get; set; }

        [StringLength(3)]
        public string FL38_STATE { get; set; }

        [StringLength(10)]
        public string FL38_ZIP { get; set; }

        [StringLength(2)]
        public string FL39A_CODE { get; set; }

        public decimal? FL39A_AMT { get; set; }

        [StringLength(2)]
        public string FL39B_CODE { get; set; }

        public decimal? FL39B_AMT { get; set; }

        [StringLength(2)]
        public string FL39C_CODE { get; set; }

        public decimal? FL39C_AMT { get; set; }

        [StringLength(2)]
        public string FL39D_CODE { get; set; }

        public decimal? FL39D_AMT { get; set; }

        [StringLength(2)]
        public string FL40A_CODE { get; set; }

        public decimal? FL40A_AMT { get; set; }

        [StringLength(2)]
        public string FL40B_CODE { get; set; }

        public decimal? FL40B_AMT { get; set; }

        [StringLength(2)]
        public string FL40C_CODE { get; set; }

        public decimal? FL40C_AMT { get; set; }

        [StringLength(2)]
        public string FL40D_CODE { get; set; }

        public decimal? FL40D_AMT { get; set; }

        [StringLength(2)]
        public string FL41A_CODE { get; set; }

        public decimal? FL41A_AMT { get; set; }

        [StringLength(2)]
        public string FL41B_CODE { get; set; }

        public decimal? FL41B_AMT { get; set; }

        [StringLength(2)]
        public string FL41C_CODE { get; set; }

        public decimal? FL41C_AMT { get; set; }

        [StringLength(2)]
        public string FL41D_CODE { get; set; }

        public decimal? FL41D_AMT { get; set; }

        [StringLength(30)]
        public string FL56 { get; set; }

        [StringLength(30)]
        public string FL57 { get; set; }

        [StringLength(10)]
        public string FL67_PRIDIAG { get; set; }

        [StringLength(10)]
        public string FL68_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL69_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL70_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL71_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL72_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL73_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL74_OTHDIAG { get; set; }

        [StringLength(10)]
        public string FL75_OTHDIAG { get; set; }

        [StringLength(5)]
        public string FL78 { get; set; }

        [StringLength(255)]
        public string FL84_REMARKS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(12)]
        public string FL38_PHONE { get; set; }

        public virtual BILLINV BILLINV { get; set; }
    }
}
