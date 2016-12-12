namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDEPTPER")]
    public partial class FUNDEPTPER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNDEPTPER()
        {
            BILLINGs = new HashSet<BILLING>();
            BILLINGs1 = new HashSet<BILLING>();
            BILLINVs = new HashSet<BILLINV>();
            BILLSUMRECs = new HashSet<BILLSUMREC>();
            INVPERIODS = new HashSet<INVPERIOD>();
            ORDCALCs = new HashSet<ORDCALC>();
            ORDEXCEEDs = new HashSet<ORDEXCEED>();
            OVERSERVs = new HashSet<OVERSERV>();
        }

        [Key]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string BATCH_ID { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime STOPDATE { get; set; }

        public DateTime? DATEOPENED { get; set; }

        public DateTime? DATECLOSED { get; set; }

        public DateTime? DATEINV { get; set; }

        [StringLength(255)]
        public string USERINV { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public int? FIRSTINV { get; set; }

        public int? LASTINV { get; set; }

        [StringLength(1)]
        public string EXBILLING { get; set; }

        [StringLength(255)]
        public string CALCUSER { get; set; }

        public DateTime? CALCDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLING> BILLINGs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLINV> BILLINVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILLSUMREC> BILLSUMRECs { get; set; }

        public virtual FUNDBATCH FUNDBATCH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVPERIOD> INVPERIODS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDCALC> ORDCALCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEXCEED> ORDEXCEEDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OVERSERV> OVERSERVs { get; set; }
    }
}
