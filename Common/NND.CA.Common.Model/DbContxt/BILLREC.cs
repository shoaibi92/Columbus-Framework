namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BILLRECS")]
    public partial class BILLREC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILLREC()
        {
            ACTIVITies = new HashSet<ACTIVITY>();
            BILLINGs = new HashSet<BILLING>();
            BILLRECS1 = new HashSet<BILLREC>();
            BILLRECVALs = new HashSet<BILLRECVAL>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            FUNDDEPTs = new HashSet<FUNDDEPT>();
            FUNDDEPTs1 = new HashSet<FUNDDEPT>();
            FUNDDEPTs2 = new HashSet<FUNDDEPT>();
            FUNDDEPTs3 = new HashSet<FUNDDEPT>();
            FUNDDEPTs4 = new HashSet<FUNDDEPT>();
            MEALPACKS = new HashSet<MEALPACK>();
            ORDERS = new HashSet<ORDER>();
            RATECHARTs = new HashSet<RATECHART>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string BILLREC_ID { get; set; }

        [Required]
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

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
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

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVITY> ACTIVITies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        public virtual TRXTYPE TRXTYPE { get; set; }

        public virtual BILLTABLE BILLTABLE { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PAYRECORD PAYRECORD1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLREC> BILLRECS1 { get; set; }

        public virtual BILLREC BILLREC1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLRECVAL> BILLRECVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEALPACK> MEALPACKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATECHART> RATECHARTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
