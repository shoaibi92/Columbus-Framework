namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OUTTABLES")]
    public partial class OUTTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OUTTABLE()
        {
            ACTIVITies = new HashSet<ACTIVITY>();
            ACTIVITies1 = new HashSet<ACTIVITY>();
            OUTCOMES = new HashSet<OUTCOME>();
            VALOUTTABS = new HashSet<VALOUTTAB>();
        }

        [Key]
        [StringLength(14)]
        public string OUTTABLE_ID { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(14)]
        public string GOALSTATAB { get; set; }

        [StringLength(14)]
        public string OUTSTATTAB { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVITY> ACTIVITies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVITY> ACTIVITies1 { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual LOOKUP LOOKUP1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OUTCOME> OUTCOMES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VALOUTTAB> VALOUTTABS { get; set; }
    }
}
