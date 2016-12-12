namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AVROTATE")]
    public partial class AVROTATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AVROTATE()
        {
            AVDAYS = new HashSet<AVDAY>();
            AVROTEMPs = new HashSet<AVROTEMP>();
            DEPTAVROTs = new HashSet<DEPTAVROT>();
        }

        [Key]
        [StringLength(14)]
        public string ROTATE_ID { get; set; }

        [StringLength(40)]
        public string NAME { get; set; }

        public DateTime? EFFDATE { get; set; }

        public DateTime? EXPDATE { get; set; }

        public int? ROTDAYS { get; set; }

        public int? DAYSTART { get; set; }

        [StringLength(100)]
        public string ROTPATTERN { get; set; }

        [StringLength(1)]
        public string EMPSPEC { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVDAY> AVDAYS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AVROTEMP> AVROTEMPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPTAVROT> DEPTAVROTs { get; set; }
    }
}
