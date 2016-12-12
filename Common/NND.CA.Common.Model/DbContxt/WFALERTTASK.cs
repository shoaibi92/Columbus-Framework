namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFALERTTASKS")]
    public partial class WFALERTTASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFALERTTASK()
        {
            WFTASKS = new HashSet<WFTASK>();
        }

        [Key]
        [StringLength(14)]
        public string WFALERTTASK_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string WFALERT_ID { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        [Column(TypeName = "text")]
        public string DETAILS { get; set; }

        [Required]
        [StringLength(1)]
        public string NOTIFYUSER { get; set; }

        [Required]
        [StringLength(1)]
        public string NOTIFY_TYPE { get; set; }

        public int? NOTIFY_INDEX { get; set; }

        public DateTime? NOTIFY_TIME { get; set; }

        [Required]
        [StringLength(1)]
        public string DUE1_TYPE { get; set; }

        public int? DUE1_INDEX { get; set; }

        public DateTime? DUE1_TIME { get; set; }

        [Required]
        [StringLength(1)]
        public string DUE2_TYPE { get; set; }

        public int? DUE2_INDEX { get; set; }

        public DateTime? DUE2_TIME { get; set; }

        [Required]
        [StringLength(1)]
        public string DUE3_TYPE { get; set; }

        public int? DUE3_INDEX { get; set; }

        public DateTime? DUE3_TIME { get; set; }

        [Required]
        [StringLength(1)]
        public string DUE4_TYPE { get; set; }

        public int? DUE4_INDEX { get; set; }

        public DateTime? DUE4_TIME { get; set; }

        [StringLength(14)]
        public string DUE4_USER_ID { get; set; }

        [StringLength(14)]
        public string DUE4_PLANNER_ID { get; set; }

        [StringLength(14)]
        public string DUE4_SUPERTYPE_ID { get; set; }

        [StringLength(14)]
        public string COMP_WFALERT_ID { get; set; }

        [StringLength(14)]
        public string DISM_WFALERT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string GROUP_ID { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual PLANNER PLANNER1 { get; set; }

        public virtual SCHGROUP SCHGROUP { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }

        public virtual WFALERT WFALERT { get; set; }

        public virtual WFALERT WFALERT1 { get; set; }

        public virtual WFALERT WFALERT2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS { get; set; }
    }
}
