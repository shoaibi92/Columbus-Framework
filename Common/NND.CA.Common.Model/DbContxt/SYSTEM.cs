namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSTEM")]
    public partial class SYSTEM
    {
        [Key]
        [StringLength(14)]
        public string COMPANY_ID { get; set; }

        [StringLength(40)]
        public string COMP_NAME { get; set; }

        [StringLength(12)]
        public string PRI_PHONE { get; set; }

        [StringLength(12)]
        public string SEC_PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(40)]
        public string ADDRESS_2 { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public int? LANGUAGE { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        [StringLength(14)]
        public string DEFEMPDEPT { get; set; }

        [StringLength(14)]
        public string DEFCLTDEPT { get; set; }

        [StringLength(1)]
        public string DEPTMODE { get; set; }

        [StringLength(1)]
        public string TAX1USE { get; set; }

        public decimal? TAX1VAL { get; set; }

        [StringLength(40)]
        public string TAX1GL { get; set; }

        [StringLength(20)]
        public string TAX1NUM { get; set; }

        [StringLength(20)]
        public string TAX1DESCR { get; set; }

        [StringLength(1)]
        public string TAX2USE { get; set; }

        public decimal? TAX2VAL { get; set; }

        [StringLength(40)]
        public string TAX2GL { get; set; }

        [StringLength(20)]
        public string TAX2NUM { get; set; }

        [StringLength(20)]
        public string TAX2DESCR { get; set; }

        [StringLength(30)]
        public string DEFCITY { get; set; }

        [StringLength(3)]
        public string DEFPROV { get; set; }

        [StringLength(30)]
        public string DEF_CNTRY { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(1)]
        public string POLLUSERS { get; set; }

        public int? ZIPPER { get; set; }

        [StringLength(10)]
        public string DBVERSION { get; set; }

        [Column(TypeName = "text")]
        public string PROCURA { get; set; }

        [StringLength(1)]
        public string USEPAGER { get; set; }

        [StringLength(40)]
        public string PAGERSUFFIX { get; set; }

        public int? PAGERMAX { get; set; }

        [StringLength(1)]
        public string PAGERNODASH { get; set; }

        public int? PAGERMAXLINES { get; set; }

        public DateTime? LICINSTALL { get; set; }

        public DateTime? LICCHANGED { get; set; }

        public int? CLPVDAYS { get; set; }

        public int? CLPPDAYS { get; set; }

        [StringLength(14)]
        public string CLPUSERCODE { get; set; }

        [StringLength(14)]
        public string CLPUSERPIN { get; set; }

        public int? PINTERVAL { get; set; }

        public int? PTIMEOUT { get; set; }

        [StringLength(1)]
        public string PROMPTLOG { get; set; }

        [Column(TypeName = "text")]
        public string PROMPTMSG { get; set; }

        [StringLength(1)]
        public string DEPTTAX { get; set; }

        [StringLength(14)]
        public string CLTNUMBER_ID { get; set; }

        [StringLength(14)]
        public string CLTSSN_ID { get; set; }

        [StringLength(20)]
        public string MCAREPNUM { get; set; }

        [StringLength(20)]
        public string MCARENUM { get; set; }

        [StringLength(20)]
        public string MCAIDPNUM { get; set; }

        [StringLength(20)]
        public string MCAIDNUM { get; set; }

        [StringLength(20)]
        public string BRCHNUMNAME { get; set; }

        [StringLength(1)]
        public string OASAUTOFILL { get; set; }

        [StringLength(1)]
        public string OASOVERWRITE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string REMOTEDB { get; set; }

        [StringLength(30)]
        public string CLASTNAME { get; set; }

        [StringLength(20)]
        public string CFIRSTNAME { get; set; }

        [StringLength(10)]
        public string EXTENSION { get; set; }

        [StringLength(1)]
        public string EXPPASS { get; set; }

        public int? EXPPASSDAYS { get; set; }

        [StringLength(1)]
        public string KICKIDLE { get; set; }

        public int? KICKIDLENUMS { get; set; }

        [StringLength(1)]
        public string SINGLELOGIN { get; set; }

        [StringLength(1)]
        public string RECYCLEPASS { get; set; }

        public int? RECYCLETIMES { get; set; }

        public int? SINGLELOGINTIMES { get; set; }

        [StringLength(255)]
        public string VALIDUNTIL { get; set; }

        [StringLength(10)]
        public string EDCTIMEZONE { get; set; }

        [StringLength(1)]
        public string EDCDAYSAVINGS { get; set; }

        public int? EDCDURROUND { get; set; }

        [StringLength(14)]
        public string MDS_AA2_NUMBER_ID { get; set; }

        [StringLength(14)]
        public string MDS_AA3A_NUMBER_ID { get; set; }

        [StringLength(1)]
        public string EDCSCHEDRETAIN { get; set; }

        [StringLength(14)]
        public string SYNCNOTETYPE_ID { get; set; }

        [StringLength(1)]
        public string CLTAREAREQ { get; set; }

        [StringLength(1)]
        public string EMPAREAREQ { get; set; }

        public DateTime? TRXDATE { get; set; }

        [StringLength(80)]
        public string POSTALMASK { get; set; }

        [StringLength(80)]
        public string PHONEMASK { get; set; }

        [StringLength(1)]
        public string DISORDERDEF { get; set; }

        [StringLength(1)]
        public string SYNCAUTOACCEPT { get; set; }

        [StringLength(1)]
        public string SYNCAUTOSYNC { get; set; }

        public DateTime? SYNCASSDATE { get; set; }

        [StringLength(1)]
        public string AUTHTYPE { get; set; }

        [StringLength(255)]
        public string EDCEMPADDR { get; set; }

        [StringLength(1)]
        public string EDCEMPAUTO { get; set; }

        public DateTime? LCHECKDATE { get; set; }

        [StringLength(1)]
        public string WFENABLED { get; set; }

        public DateTime? POCCONSOLEDATE { get; set; }

        public int? POCCONSOLEINTERVAL { get; set; }

        public int? DB_8100 { get; set; }

        public int? EDCVERIFYWINDOW { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        public byte[] LOGO { get; set; }

        public string PROPS { get; set; }

        public virtual NOTETYPE NOTETYPE { get; set; }

        public virtual NUMBER NUMBER { get; set; }

        public virtual NUMBER NUMBER1 { get; set; }

        public virtual NUMBER NUMBER2 { get; set; }

        public virtual NUMBER NUMBER3 { get; set; }

        public virtual NUMBER NUMBER4 { get; set; }

        public virtual NUMBER NUMBER5 { get; set; }
    }
}
