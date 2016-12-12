namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERSYNCH")]
    public partial class USERSYNCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERSYNCH()
        {
            USERSYNCHRECS = new HashSet<USERSYNCHREC>();
        }

        [Key]
        [StringLength(14)]
        public string SYNCH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? CHKOUTDATE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERSYNCHREC> USERSYNCHRECS { get; set; }
    }
}
