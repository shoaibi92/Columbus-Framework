namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTPATHVISITS")]
    public partial class CLTPATHVISIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTPATHVISIT()
        {
            CLTPATHITEMS = new HashSet<CLTPATHITEM>();
            CLTPATHITEMS1 = new HashSet<CLTPATHITEM>();
            CLTPATHVISITNOTES = new HashSet<CLTPATHVISITNOTE>();
        }

        [Key]
        [StringLength(14)]
        public string PATHVISIT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string STEP_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(60)]
        public string RECREASON { get; set; }

        public DateTime STARTDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string STARTUSER { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(255)]
        public string STOPUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string MERGE_STEP_ID { get; set; }

        public DateTime? LOCKDATE { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEM> CLTPATHITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEM> CLTPATHITEMS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISITNOTE> CLTPATHVISITNOTES { get; set; }

        public virtual CLTPATHWAY CLTPATHWAY { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }

        public virtual PATHSTEP PATHSTEP1 { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
