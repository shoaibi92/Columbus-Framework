namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIMEPERIOD")]
    public partial class TIMEPERIOD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMEPERIOD()
        {
            DEPTPERIODs = new HashSet<DEPTPERIOD>();
            EXPMILEAGEs = new HashSet<EXPMILEAGE>();
            VISITS = new HashSet<VISIT>();
        }

        [Key]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(1)]
        public string PERIODOPEN { get; set; }

        public DateTime? OPENED { get; set; }

        public DateTime? CLOSED { get; set; }

        public DateTime? LSTOPENED { get; set; }

        [StringLength(255)]
        public string LSTOPENUSR { get; set; }

        public DateTime? LSTCHANGED { get; set; }

        [StringLength(255)]
        public string LSTCHGUSR { get; set; }

        public DateTime? LSTSTATRAN { get; set; }

        [StringLength(255)]
        public string LSTSTATUSR { get; set; }

        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTPERIOD> DEPTPERIODs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPMILEAGE> EXPMILEAGEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VISIT> VISITS { get; set; }
    }
}
