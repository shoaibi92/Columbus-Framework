namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTETEMPLATES")]
    public partial class NOTETEMPLATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOTETEMPLATE()
        {
            NOTETYPETPLATES = new HashSet<NOTETYPETPLATE>();
        }

        [Key]
        [StringLength(14)]
        public string TEMPLATE_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECCLASS { get; set; }

        [StringLength(80)]
        public string SUBJECT { get; set; }

        [Column(TypeName = "text")]
        public string CONTENTS { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [StringLength(1)]
        public string TEMPREADONLY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTETYPETPLATE> NOTETYPETPLATES { get; set; }
    }
}
