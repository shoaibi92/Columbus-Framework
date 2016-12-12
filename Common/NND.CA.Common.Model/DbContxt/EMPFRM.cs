namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPFRMS")]
    public partial class EMPFRM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPFRM()
        {
            EMPFRMANS = new HashSet<EMPFRMAN>();
            EMPFRMLOGs = new HashSet<EMPFRMLOG>();
            EMPFRMS1 = new HashSet<EMPFRM>();
        }

        [Key]
        [StringLength(14)]
        public string EMPFRM_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [StringLength(14)]
        public string PEMPFRM_ID { get; set; }

        [StringLength(14)]
        public string PQUESTION_ID { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string EFRMSTATE { get; set; }

        public DateTime EFRMDATE { get; set; }

        [StringLength(30)]
        public string EFREFNUMBER { get; set; }

        public DateTime? EFCOMPDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string EFRMTYPE { get; set; }

        [StringLength(14)]
        public string EFASSESSOR_ID { get; set; }

        public int? EFTIMESPENT { get; set; }

        public decimal? EFSCORE { get; set; }

        [Required]
        [StringLength(1)]
        public string EFRECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(30)]
        public string EFCUSTOMSTATUS { get; set; }

        public DateTime? LOCKDATE { get; set; }

        public DateTime? SENTDATE { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [StringLength(14)]
        public string REQ_ID { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual EMPFOLDER EMPFOLDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMAN> EMPFRMANS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMLOG> EMPFRMLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS1 { get; set; }

        public virtual EMPFRM EMPFRM1 { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual EMPSUPREQ EMPSUPREQ { get; set; }

        public virtual VISIT VISIT { get; set; }
    }
}
