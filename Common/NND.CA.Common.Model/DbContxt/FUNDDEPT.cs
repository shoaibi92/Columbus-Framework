namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDDEPT")]
    public partial class FUNDDEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNDDEPT()
        {
            FUNDBATCHes = new HashSet<FUNDBATCH>();
            FUNDCCTYPEs = new HashSet<FUNDCCTYPE>();
            FUNDEBTYPEs = new HashSet<FUNDEBTYPE>();
            FUNDRULES = new HashSet<FUNDRULE>();
            MEALTABS = new HashSet<MEALTAB>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(10)]
        public string NEXT_INV { get; set; }

        public DateTime? STARTDATE { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        [StringLength(1)]
        public string DEFBILL { get; set; }

        [StringLength(1)]
        public string DEFPAY { get; set; }

        [StringLength(14)]
        public string INVFORMAT { get; set; }

        [StringLength(1)]
        public string STMTFORMAT { get; set; }

        [StringLength(1)]
        public string EBILL { get; set; }

        [StringLength(14)]
        public string EFORMAT { get; set; }

        [StringLength(1)]
        public string BATCHOPTION { get; set; }

        [StringLength(14)]
        public string DEFRATE { get; set; }

        [StringLength(1)]
        public string CHARGETAX1 { get; set; }

        [StringLength(1)]
        public string CHANGETAX1 { get; set; }

        [StringLength(20)]
        public string TAX1DESCR { get; set; }

        [StringLength(1)]
        public string CHARGETAX2 { get; set; }

        [StringLength(1)]
        public string CHANGETAX2 { get; set; }

        [StringLength(20)]
        public string TAX2DESCR { get; set; }

        [StringLength(1)]
        public string USEOR { get; set; }

        [StringLength(14)]
        public string DEFORRATE { get; set; }

        public int? DEFORRULE { get; set; }

        [StringLength(1)]
        public string USECC { get; set; }

        [StringLength(14)]
        public string DEFCCRATE { get; set; }

        public int? DEFCCRULE { get; set; }

        [StringLength(40)]
        public string DEFCCINVCOM { get; set; }

        [StringLength(1)]
        public string USEEB { get; set; }

        [StringLength(14)]
        public string DEFEBRATE { get; set; }

        public int? DEFEBRULE { get; set; }

        [StringLength(40)]
        public string DEFEBINVCOM { get; set; }

        [StringLength(1)]
        public string USERB { get; set; }

        [StringLength(14)]
        public string DEFRBRATE { get; set; }

        public int? DEFRBRULE { get; set; }

        [StringLength(40)]
        public string DEFRBINVCOM { get; set; }

        [StringLength(14)]
        public string RATETABLE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string USEORDSERV { get; set; }

        [StringLength(1)]
        public string USEORDHOLD { get; set; }

        [StringLength(1)]
        public string USEORDXVIS { get; set; }

        [StringLength(1)]
        public string USEORDHRLV { get; set; }

        [StringLength(1)]
        public string BILLING { get; set; }

        [StringLength(1)]
        public string STATACTION { get; set; }

        [StringLength(1)]
        public string STATNOEMP { get; set; }

        [StringLength(14)]
        public string STATPLAN { get; set; }

        [StringLength(1)]
        public string TKSTATACT { get; set; }

        [StringLength(1)]
        public string NOSTATACT { get; set; }

        [StringLength(1)]
        public string NOSTATNOEMP { get; set; }

        [StringLength(14)]
        public string NOSTATPLAN { get; set; }

        public int? LAST_INV { get; set; }

        [Column(TypeName = "text")]
        public string INVCOMMENT { get; set; }

        [StringLength(1)]
        public string SASKRULES { get; set; }

        [StringLength(1)]
        public string CCBILLCYC { get; set; }

        [StringLength(1)]
        public string LVLVISITS { get; set; }

        public int? NEXTSINV { get; set; }

        [StringLength(1)]
        public string OVERMID { get; set; }

        [StringLength(1)]
        public string OVERMIDHOLS { get; set; }

        [StringLength(5)]
        public string DEFMSACODE { get; set; }

        public int? ORDERDAYS { get; set; }

        [StringLength(14)]
        public string INVGROUP_ID { get; set; }

        [StringLength(1)]
        public string INVPRINTCOMP { get; set; }

        [StringLength(1)]
        public string INVPRINTEMP { get; set; }

        [StringLength(20)]
        public string INVEMPTEXT { get; set; }

        public int? INVLANG { get; set; }

        [StringLength(1)]
        public string RAPBILLVISIT { get; set; }

        [StringLength(1)]
        public string FINALCALCTYPE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string RAPBILLVISITV { get; set; }

        [StringLength(1)]
        public string UB04 { get; set; }

        [StringLength(1)]
        public string ORSCHEDONLY { get; set; }

        [StringLength(1)]
        public string LINEITEMPOST { get; set; }

        [StringLength(1)]
        public string CNTRBILLING { get; set; }

        [StringLength(1)]
        public string INVGENFLAG { get; set; }

        public string PROPS { get; set; }

        public virtual BILLREC BILLREC { get; set; }

        public virtual BILLREC BILLREC1 { get; set; }

        public virtual BILLREC BILLREC2 { get; set; }

        public virtual BILLREC BILLREC3 { get; set; }

        public virtual BILLREC BILLREC4 { get; set; }

        public virtual BILLTABLE BILLTABLE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EBILLFORMAT EBILLFORMAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDBATCH> FUNDBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDCCTYPE> FUNDCCTYPEs { get; set; }

        public virtual INVGROUP INVGROUP { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual RULE RULE { get; set; }

        public virtual RULE RULE1 { get; set; }

        public virtual RULE RULE2 { get; set; }

        public virtual RULE RULE3 { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }

        public virtual INVFORMAT INVFORMAT1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDEBTYPE> FUNDEBTYPEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDRULE> FUNDRULES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALTAB> MEALTABS { get; set; }
    }
}
