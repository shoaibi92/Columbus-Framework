namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCTYPES")]
    public partial class DOCTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTYPE()
        {
            CLTDOCS = new HashSet<CLTDOC>();
            DOCTYPEDEPTS = new HashSet<DOCTYPEDEPT>();
            EMPDOCS = new HashSet<EMPDOC>();
            SYSDOCS = new HashSet<SYSDOC>();
        }

        [Key]
        [StringLength(14)]
        public string DOCTYPE_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string NAME { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(1)]
        public string SYSDEFINED { get; set; }

        [Required]
        [StringLength(1)]
        public string DOCCLIENT { get; set; }

        [Required]
        [StringLength(1)]
        public string DOCPOINTOFCARE { get; set; }

        [Required]
        [StringLength(100)]
        public string FILEEXTS { get; set; }

        public int MAXSIZE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        public string PROPS { get; set; }

        [StringLength(1)]
        public string DEPTSPECIFIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDOC> CLTDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTYPEDEPT> DOCTYPEDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDOC> EMPDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYSDOC> SYSDOCS { get; set; }
    }
}
