namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFALERTS")]
    public partial class WFALERT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFALERT()
        {
            WFALERTACTIONS = new HashSet<WFALERTACTION>();
            WFALERTDEPTS = new HashSet<WFALERTDEPT>();
            WFALERTTASKS = new HashSet<WFALERTTASK>();
            WFALERTTASKS1 = new HashSet<WFALERTTASK>();
            WFALERTTASKS2 = new HashSet<WFALERTTASK>();
        }

        [Key]
        [StringLength(14)]
        public string WFALERT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string WFEVENT_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(1)]
        public string WFCOND { get; set; }

        [StringLength(14)]
        public string WFCOND_ID { get; set; }

        [StringLength(1)]
        public string WFCONDCOMPTYPE { get; set; }

        [StringLength(80)]
        public string WFCONDCOMPVALUE { get; set; }

        [StringLength(1)]
        public string WFCONDCOMPACTION { get; set; }

        [Column(TypeName = "text")]
        public string WFCONTDATA { get; set; }

        [Required]
        [StringLength(1)]
        public string RECENABLED { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTACTION> WFALERTACTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTDEPT> WFALERTDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFALERTTASK> WFALERTTASKS2 { get; set; }

        public virtual WFCONDITION WFCONDITION { get; set; }

        public virtual WFEVENT WFEVENT { get; set; }
    }
}
