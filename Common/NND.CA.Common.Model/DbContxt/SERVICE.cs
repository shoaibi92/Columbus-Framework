namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SERVICES")]
    public partial class SERVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICE()
        {
            ACTIVITies = new HashSet<ACTIVITY>();
            ASSQUESTS = new HashSet<ASSQUEST>();
        }

        [Key]
        [StringLength(14)]
        public string SERVICE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(10)]
        public string REFNUMBER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(30)]
        public string AUXCODE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVITY> ACTIVITies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQUEST> ASSQUESTS { get; set; }

        public virtual SERVTABLE SERVTABLE { get; set; }
    }
}
