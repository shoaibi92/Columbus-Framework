namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERDEPT")]
    public partial class USERDEPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERDEPT()
        {
            USERNOTES = new HashSet<USERNOTE>();
            USERPLANS = new HashSet<USERPLAN>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERNOTE> USERNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERPLAN> USERPLANS { get; set; }
    }
}
