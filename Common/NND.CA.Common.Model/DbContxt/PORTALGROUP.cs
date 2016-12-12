namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALGROUPS")]
    public partial class PORTALGROUP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PORTALGROUP()
        {
            PORTALGROUPACCESSes = new HashSet<PORTALGROUPACCESS>();
            PORTALUSERGROUPS = new HashSet<PORTALUSERGROUP>();
        }

        [Key]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Column(TypeName = "text")]
        public string NOTICE { get; set; }

        [StringLength(1)]
        public string PROMPTNOTICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALGROUPACCESS> PORTALGROUPACCESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PORTALUSERGROUP> PORTALUSERGROUPS { get; set; }
    }
}
