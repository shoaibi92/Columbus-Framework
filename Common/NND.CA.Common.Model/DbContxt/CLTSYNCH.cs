namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSYNCH")]
    public partial class CLTSYNCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTSYNCH()
        {
            CLTSYNCHERRs = new HashSet<CLTSYNCHERR>();
            CLTSYNCHRECS = new HashSet<CLTSYNCHREC>();
        }

        [Key]
        [StringLength(14)]
        public string SYNCH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string ERRLAST { get; set; }

        public DateTime? CHKOUTDATE { get; set; }

        public DateTime? SYNCDATE { get; set; }

        public DateTime? CHKINDATE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? LSTCHGDATE { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSYNCHERR> CLTSYNCHERRs { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTSYNCHREC> CLTSYNCHRECS { get; set; }
    }
}
