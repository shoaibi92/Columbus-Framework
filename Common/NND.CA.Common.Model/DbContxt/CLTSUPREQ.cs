namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTSUPREQ")]
    public partial class CLTSUPREQ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTSUPREQ()
        {
            CLTASSESSes = new HashSet<CLTASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string REQ_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLTVISITOR_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(40)]
        public string DESCR { get; set; }

        public DateTime? DUEDATE { get; set; }

        public DateTime? COMPDATE { get; set; }

        [StringLength(14)]
        public string SUPER_ID { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        [StringLength(14)]
        public string REQMNT { get; set; }

        [StringLength(14)]
        public string TYPE { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        public virtual CLTDEPT CLTDEPT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual SUPERVISOR SUPERVISOR { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL1 { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
