namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFTASKS")]
    public partial class WFTASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFTASK()
        {
            WFTASKS1 = new HashSet<WFTASK>();
        }

        [Key]
        [StringLength(14)]
        public string WFTASK_ID { get; set; }

        [StringLength(14)]
        public string WFALERTTASK_ID { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [StringLength(14)]
        public string PLANNER_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string CCONTACT_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECCLASS { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime? STATUSDATE { get; set; }

        [StringLength(60)]
        public string STATUSREASON { get; set; }

        [StringLength(20)]
        public string ACTIVESTATUS { get; set; }

        public int? TASKPROGRESS { get; set; }

        [StringLength(30)]
        public string TASKPRIORITY { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        [Column(TypeName = "text")]
        public string DETAILS { get; set; }

        [Required]
        [StringLength(1)]
        public string NOTIFYUSER { get; set; }

        public DateTime NOTIFYDATE { get; set; }

        public DateTime? DUEDATE1 { get; set; }

        public DateTime? DUEDATE2 { get; set; }

        public DateTime? DUEDATE3 { get; set; }

        public DateTime? DUEDATE4 { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string PARENTWFTASK_ID { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CONTACT CONTACT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PLANNER PLANNER { get; set; }

        public virtual USER USER { get; set; }

        public virtual WFALERTTASK WFALERTTASK { get; set; }

        public virtual WFTASKDET WFTASKDET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFTASK> WFTASKS1 { get; set; }

        public virtual WFTASK WFTASK1 { get; set; }
    }
}
