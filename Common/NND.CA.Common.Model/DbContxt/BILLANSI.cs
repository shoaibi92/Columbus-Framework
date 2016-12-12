namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLANSI")]
    public partial class BILLANSI
    {
        [Key]
        [StringLength(14)]
        public string BILLINV_ID { get; set; }

        [StringLength(1)]
        public string L2000B_SBR01 { get; set; }

        [StringLength(2)]
        public string L2000B_SBR02 { get; set; }

        [StringLength(30)]
        public string L2000B_SBR03 { get; set; }

        [StringLength(60)]
        public string L2000B_SBR04 { get; set; }

        [StringLength(2)]
        public string L2000B_SBR09 { get; set; }

        [StringLength(30)]
        public string L2010BA_NM103 { get; set; }

        [StringLength(20)]
        public string L2010BA_NM104 { get; set; }

        [StringLength(20)]
        public string L2010BA_NM105 { get; set; }

        [StringLength(30)]
        public string L2010BA_NM109 { get; set; }

        [StringLength(40)]
        public string L2010BA_N301 { get; set; }

        [StringLength(40)]
        public string L2010BA_N302 { get; set; }

        [StringLength(20)]
        public string L2010BA_N401 { get; set; }

        [StringLength(2)]
        public string L2010BA_N402 { get; set; }

        [StringLength(9)]
        public string L2010BA_N403 { get; set; }

        [StringLength(30)]
        public string L2010CA_NM103 { get; set; }

        [StringLength(20)]
        public string L2010CA_NM104 { get; set; }

        [StringLength(20)]
        public string L2010CA_NM105 { get; set; }

        [StringLength(7)]
        public string L2300_CLM05 { get; set; }

        [StringLength(1)]
        public string L2300_CLM07 { get; set; }

        [StringLength(1)]
        public string L2300_CLM08 { get; set; }

        [StringLength(1)]
        public string L2300_CLM09 { get; set; }

        [StringLength(1)]
        public string L2300_CLM18 { get; set; }

        [StringLength(2)]
        public string L2300_CLM20 { get; set; }

        public DateTime? L2300_DTP03START { get; set; }

        public DateTime? L2300_DTP03STOP { get; set; }

        [StringLength(1)]
        public string L2300_CL102 { get; set; }

        [StringLength(2)]
        public string L2300_CL103 { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string PORDER_ID { get; set; }

        [StringLength(14)]
        public string SORDER_ID { get; set; }

        [StringLength(14)]
        public string TORDER_ID { get; set; }

        [StringLength(30)]
        public string L2300_HI01_2 { get; set; }

        [StringLength(255)]
        public string REMARKS { get; set; }

        [StringLength(1)]
        public string CLAIMTYPE { get; set; }

        [StringLength(80)]
        public string CLAIMCONTROLNUMBER { get; set; }

        [StringLength(60)]
        public string SERVAUTH { get; set; }

        [StringLength(40)]
        public string L2300_REMARKCODES { get; set; }

        public decimal? L2300_MOA01 { get; set; }

        public decimal? L2300_MOA02 { get; set; }

        public decimal? L2300_MOA08 { get; set; }

        public decimal? L2300_MOA09 { get; set; }

        public string PROPS { get; set; }

        public virtual BILLINV BILLINV { get; set; }
    }
}
