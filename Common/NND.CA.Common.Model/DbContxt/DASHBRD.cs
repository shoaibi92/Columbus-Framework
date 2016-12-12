namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDS")]
    public partial class DASHBRD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DASHBRD()
        {
            DASHBRDDETAILS = new HashSet<DASHBRDDETAIL>();
            DASHBRDGROUPS = new HashSet<DASHBRDGROUP>();
        }

        [Key]
        [StringLength(14)]
        public string DASHBRD_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        public int DISPLAYROWS { get; set; }

        public int DISPLAYCOLS { get; set; }

        public int? REFRESHTIMER { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDDETAIL> DASHBRDDETAILS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DASHBRDGROUP> DASHBRDGROUPS { get; set; }
    }
}
