namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPCATS")]
    public partial class EMPCAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPCAT()
        {
            CATRULES = new HashSet<CATRULE>();
            LBREMPCATS = new HashSet<LBREMPCAT>();
            TIMEDUTies = new HashSet<TIMEDUTY>();
            CLTDEPTs = new HashSet<CLTDEPT>();
        }

        [Key]
        [StringLength(14)]
        public string EMPCAT_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(1)]
        public string SPLITSHIFT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string RULESET_ID { get; set; }

        [StringLength(14)]
        public string RULESET_ID2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATRULE> CATRULES { get; set; }

        public virtual RULESET RULESET { get; set; }

        public virtual RULESET RULESET1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LBREMPCAT> LBREMPCATS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMEDUTY> TIMEDUTies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDEPT> CLTDEPTs { get; set; }
    }
}
