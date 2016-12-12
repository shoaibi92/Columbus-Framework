namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHGROUPCLTS")]
    public partial class SCHGROUPCLT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHGROUPCLT()
        {
            SCHGROUPCLTSTATES = new HashSet<SCHGROUPCLTSTATE>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }

        public virtual SCHGROUP SCHGROUP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHGROUPCLTSTATE> SCHGROUPCLTSTATES { get; set; }
    }
}
