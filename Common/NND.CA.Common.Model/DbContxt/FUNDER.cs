namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDERS")]
    public partial class FUNDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNDER()
        {
            AUTOORDPLANs = new HashSet<AUTOORDPLAN>();
            CLAIMBATCHes = new HashSet<CLAIMBATCH>();
            CONTACTS = new HashSet<CONTACT>();
            COORDS = new HashSet<COORD>();
            DEPARTMENTS = new HashSet<DEPARTMENT>();
            DEPARTMENTS1 = new HashSet<DEPARTMENT>();
            DEPARTMENTS2 = new HashSet<DEPARTMENT>();
            FUNDCLTREFs = new HashSet<FUNDCLTREF>();
            FUNDDEPTs = new HashSet<FUNDDEPT>();
            FUNDERREFS = new HashSet<FUNDERREF>();
            FUNDERSERVs = new HashSet<FUNDERSERV>();
            LBRGRPS = new HashSet<LBRGRP>();
            ORDERS = new HashSet<ORDER>();
            PAYRECORDS = new HashSet<PAYRECORD>();
            TRXBATCHes = new HashSet<TRXBATCH>();
            TRXBATCHFUNDERS = new HashSet<TRXBATCHFUNDER>();
            USERS = new HashSet<USER>();
        }

        [Key]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CODE { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        [Required]
        [StringLength(1)]
        public string CLASS { get; set; }

        [StringLength(14)]
        public string FUNDTYPE { get; set; }

        [StringLength(40)]
        public string ADDRESS_1 { get; set; }

        [StringLength(40)]
        public string ADDRESS_2 { get; set; }

        [StringLength(30)]
        public string CITY { get; set; }

        [StringLength(3)]
        public string PROVINCE { get; set; }

        [StringLength(30)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string POSTAL { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(12)]
        public string FAX { get; set; }

        [StringLength(10)]
        public string C_PREFIX { get; set; }

        [StringLength(30)]
        public string C_LAST { get; set; }

        [StringLength(20)]
        public string C_FIRST { get; set; }

        [StringLength(40)]
        public string C_TITLE { get; set; }

        [StringLength(12)]
        public string C_PHONE { get; set; }

        [StringLength(10)]
        public string C_EXT { get; set; }

        [StringLength(1)]
        public string SAMEAS { get; set; }

        [StringLength(40)]
        public string B_ADDR_1 { get; set; }

        [StringLength(40)]
        public string B_ADDR_2 { get; set; }

        [StringLength(30)]
        public string B_CITY { get; set; }

        [StringLength(3)]
        public string B_PROVINCE { get; set; }

        [StringLength(30)]
        public string B_COUNTRY { get; set; }

        [StringLength(10)]
        public string B_POSTAL { get; set; }

        [StringLength(12)]
        public string B_PHONE { get; set; }

        [StringLength(12)]
        public string B_FAX { get; set; }

        [StringLength(10)]
        public string BC_PREFIX { get; set; }

        [StringLength(30)]
        public string BC_LAST { get; set; }

        [StringLength(20)]
        public string BC_FIRST { get; set; }

        [StringLength(40)]
        public string BC_TITLE { get; set; }

        [StringLength(12)]
        public string BC_PHONE { get; set; }

        [StringLength(10)]
        public string BC_EXT { get; set; }

        [StringLength(1)]
        public string NONPROFIT { get; set; }

        [StringLength(10)]
        public string PERMIT_ID { get; set; }

        [StringLength(1)]
        public string DEFFUNDER { get; set; }

        [StringLength(4)]
        public string BRANCH_ID { get; set; }

        [StringLength(10)]
        public string PROV_ID { get; set; }

        [StringLength(20)]
        public string PROVOWNER { get; set; }

        [StringLength(15)]
        public string EMPCODE { get; set; }

        [StringLength(30)]
        public string EMPNAME { get; set; }

        [StringLength(1)]
        public string GLINTFACE { get; set; }

        [StringLength(30)]
        public string GLACCT { get; set; }

        [StringLength(1)]
        public string GENGL_ID { get; set; }

        [StringLength(1)]
        public string GLIDMODIFY { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(14)]
        public string BENGROUP { get; set; }

        [StringLength(14)]
        public string PERMTYPE { get; set; }

        [StringLength(1)]
        public string DEFINITION { get; set; }

        [StringLength(1)]
        public string DISFUNDTAB { get; set; }

        [StringLength(30)]
        public string PPSTYPE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string HOSPICEFUNDER { get; set; }

        [StringLength(14)]
        public string CATEGORY_ID { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOORDPLAN> AUTOORDPLANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLAIMBATCH> CLAIMBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTACT> CONTACTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COORD> COORDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT> DEPARTMENTS2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDCLTREF> FUNDCLTREFs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDDEPT> FUNDDEPTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDERREF> FUNDERREFS { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL2 { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDERSERV> FUNDERSERVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBRGRP> LBRGRPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYRECORD> PAYRECORDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCH> TRXBATCHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRXBATCHFUNDER> TRXBATCHFUNDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }
    }
}
