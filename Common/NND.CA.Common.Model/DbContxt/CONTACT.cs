namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACTS")]
    public partial class CONTACT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTACT()
        {
            CONNOTES = new HashSet<CONNOTE>();
            CONSUBCATS = new HashSet<CONSUBCAT>();
            FRMCONTACTs = new HashSet<FRMCONTACT>();
            INFCONTACTs = new HashSet<INFCONTACT>();
            Oases = new HashSet<OASIS>();
            ORDERS = new HashSet<ORDER>();
            REMINDERS = new HashSet<REMINDER>();
            WFTASKS = new HashSet<WFTASK>();
            DEPARTMENTS = new HashSet<DEPARTMENT>();
        }

        [Key]
        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        [StringLength(30)]
        public string CLASTNAME { get; set; }

        [StringLength(20)]
        public string CFIRSTNAME { get; set; }

        [StringLength(20)]
        public string CMIDDLENAME { get; set; }

        [StringLength(10)]
        public string CPREFIX { get; set; }

        [StringLength(40)]
        public string CADDRESS1 { get; set; }

        [StringLength(40)]
        public string CADDRESS2 { get; set; }

        [StringLength(30)]
        public string CCITY { get; set; }

        [StringLength(3)]
        public string CPROV { get; set; }

        [StringLength(30)]
        public string CCOUNTRY { get; set; }

        [StringLength(10)]
        public string CPOSTAL { get; set; }

        [StringLength(12)]
        public string CWORKPHONE { get; set; }

        [StringLength(10)]
        public string CWORKEXT { get; set; }

        [StringLength(12)]
        public string CHOMEPHONE { get; set; }

        [StringLength(12)]
        public string CCELLPHONE { get; set; }

        [StringLength(12)]
        public string CPAGERNUM { get; set; }

        [StringLength(12)]
        public string CFAX { get; set; }

        [StringLength(50)]
        public string CEMAIL { get; set; }

        [StringLength(12)]
        public string CVOICEMAIL { get; set; }

        public DateTime? CBIRTHDATE { get; set; }

        public int? CBIRTHDAY { get; set; }

        public int? CBIRTHMONTH { get; set; }

        [Column(TypeName = "text")]
        public string CCOMMENTS { get; set; }

        [StringLength(30)]
        public string CSTATUS { get; set; }

        public DateTime? CLASTCONT { get; set; }

        [StringLength(30)]
        public string CLASTCONTCOMM { get; set; }

        public DateTime? CNEXTCONT { get; set; }

        [StringLength(30)]
        public string CNEXTCONTCOMM { get; set; }

        public DateTime? CINTAKE { get; set; }

        [StringLength(255)]
        public string CINTAKEUSER { get; set; }

        public DateTime? CCHGDATE { get; set; }

        [StringLength(255)]
        public string CCHGUSER { get; set; }

        [StringLength(1)]
        public string CFORMAL { get; set; }

        [StringLength(30)]
        public string CFTYPE { get; set; }

        [StringLength(20)]
        public string CFSPECIALTY { get; set; }

        [StringLength(20)]
        public string CFPRACTICE { get; set; }

        [StringLength(1)]
        public string CINFORMAL { get; set; }

        [StringLength(30)]
        public string CITYPE { get; set; }

        [StringLength(10)]
        public string CIRELATION { get; set; }

        [StringLength(1)]
        public string CCOORD { get; set; }

        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [StringLength(3)]
        public string CCLASS { get; set; }

        [StringLength(14)]
        public string CORG_ID { get; set; }

        [StringLength(60)]
        public string CORGNAME { get; set; }

        [StringLength(30)]
        public string CDEPT { get; set; }

        [StringLength(30)]
        public string CDIVISION { get; set; }

        [StringLength(1)]
        public string CSECURITY { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [StringLength(30)]
        public string CPOSITION { get; set; }

        [StringLength(30)]
        public string CCOMMMODE { get; set; }

        [StringLength(30)]
        public string CGROUPING { get; set; }

        public DateTime? CANNDATE { get; set; }

        [StringLength(30)]
        public string CANNCOMM { get; set; }

        [StringLength(30)]
        public string CCONTACTTYPE { get; set; }

        [StringLength(30)]
        public string CREFNUMBER { get; set; }

        [StringLength(30)]
        public string CREFID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(1)]
        public string CARCHIVED { get; set; }

        public string PROPS { get; set; }

        [StringLength(200)]
        public string TZID { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONNOTE> CONNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONSUBCAT> CONSUBCATS { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FRMCONTACT> FRMCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFCONTACT> INFCONTACTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REMINDER> REMINDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }
    }
}
