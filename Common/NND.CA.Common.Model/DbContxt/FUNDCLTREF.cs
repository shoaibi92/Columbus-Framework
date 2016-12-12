namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FUNDCLTREF")]
    public partial class FUNDCLTREF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FUNDCLTREF()
        {
            FUNDORDVALs = new HashSet<FUNDORDVAL>();
            USERS = new HashSet<USER>();
        }

        [Key]
        [StringLength(14)]
        public string REF_ID { get; set; }

        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [StringLength(60)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string TEXTVAL { get; set; }

        [StringLength(1)]
        public string DATA_TYPE { get; set; }

        public DateTime? DATEVAL { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string PRINTED { get; set; }

        [StringLength(1)]
        public string UNIQNUM { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(1)]
        public string NOFREEFORM { get; set; }

        [StringLength(20)]
        public string FORMAT { get; set; }

        [StringLength(20)]
        public string FORMULA { get; set; }

        public int? NMINLENGTH { get; set; }

        public int? NMAXLENGTH { get; set; }

        [StringLength(40)]
        public string REFNUMBER1 { get; set; }

        [StringLength(40)]
        public string REFNUMBER2 { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string NUMREQ { get; set; }

        [StringLength(1)]
        public string ADMINREF { get; set; }

        [Column(TypeName = "text")]
        public string REFDATA { get; set; }

        [StringLength(1)]
        public string ALLOWEDIT { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FUNDORDVAL> FUNDORDVALs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }
    }
}
