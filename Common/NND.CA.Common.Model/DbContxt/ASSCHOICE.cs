namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSCHOICES")]
    public partial class ASSCHOICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASSCHOICE()
        {
            ASSQADEPENDS = new HashSet<ASSQADEPEND>();
            CLTASSCHANS = new HashSet<CLTASSCHAN>();
            EMPFRMCHANS = new HashSet<EMPFRMCHAN>();
        }

        [Key]
        [StringLength(14)]
        public string CHOICE_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string ACNAME { get; set; }

        [Required]
        [StringLength(3)]
        public string ACSORTORDER { get; set; }

        public decimal? ACWEIGHT { get; set; }

        [Required]
        [StringLength(1)]
        public string ACUSERTEXT { get; set; }

        [Required]
        [StringLength(1)]
        public string ACDEFAULT { get; set; }

        [StringLength(1)]
        public string ACEXCEPT { get; set; }

        [Required]
        [StringLength(1)]
        public string ACRECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(100)]
        public string ACREFNUMBER { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQADEPEND> ASSQADEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSCHAN> CLTASSCHANS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMCHAN> EMPFRMCHANS { get; set; }
    }
}
