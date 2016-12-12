namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INFCONTACT")]
    public partial class INFCONTACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFCONTACT()
        {
            CLIENTS = new HashSet<CLIENT>();
            INFCONTACTCHARS = new HashSet<INFCONTACTCHAR>();
            MDSHC_G = new HashSet<MDSHC_G>();
            MDSHC_G1 = new HashSet<MDSHC_G>();
            LOOKUPVALS = new HashSet<LOOKUPVAL>();
        }

        [Key]
        [StringLength(14)]
        public string CONTACT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string TYPE { get; set; }

        [StringLength(10)]
        public string RELATION { get; set; }

        [StringLength(30)]
        public string LASTNAME { get; set; }

        [StringLength(20)]
        public string FIRSTNAME { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(40)]
        public string ADDRESS_2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(12)]
        public string WORK_PHONE { get; set; }

        [StringLength(12)]
        public string HOME_PHONE { get; set; }

        [StringLength(20)]
        public string ABILCARE { get; set; }

        [StringLength(10)]
        public string EXT { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string SALUTATION { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(12)]
        public string CELLPHONE { get; set; }

        [StringLength(12)]
        public string PAGERNUM { get; set; }

        [StringLength(50)]
        public string EMAILADDR { get; set; }

        [StringLength(12)]
        public string VOICEMAIL { get; set; }

        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        [StringLength(1)]
        public string DEPTCONTACT { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string NOTIFYUSER { get; set; }

        [StringLength(14)]
        public string CLTREL_ID { get; set; }

        [StringLength(255)]
        public string RELCOMMENTS { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? BIRTHDATE { get; set; }

        [StringLength(1)]
        public string ESTBIRTHDATE { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(1)]
        public string MULTICARERS { get; set; }

        [StringLength(30)]
        public string COUNTRYOFBIRTH { get; set; }

        [StringLength(30)]
        public string ETHNICITY { get; set; }

        [StringLength(14)]
        public string PRILANG { get; set; }

        [StringLength(30)]
        public string RESSTATUS { get; set; }

        [StringLength(1)]
        public string CONSENTGIVEN { get; set; }

        [StringLength(1)]
        public string BILLINGCONTACT { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLIENT> CLIENTS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CLIENT CLIENT1 { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACTCHAR> INFCONTACTCHARS { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSHC_G> MDSHC_G { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MDSHC_G> MDSHC_G1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOOKUPVAL> LOOKUPVALS { get; set; }
    }
}
