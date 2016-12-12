namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPFOLDERS")]
    public partial class EMPFOLDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPFOLDER()
        {
            EMPDOCS = new HashSet<EMPDOC>();
            EMPFOLDERS1 = new HashSet<EMPFOLDER>();
            EMPFRMS = new HashSet<EMPFRM>();
        }

        [Key]
        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(14)]
        public string PARENT_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPDOC> EMPDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFOLDER> EMPFOLDERS1 { get; set; }

        public virtual EMPFOLDER EMPFOLDER1 { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS { get; set; }
    }
}
