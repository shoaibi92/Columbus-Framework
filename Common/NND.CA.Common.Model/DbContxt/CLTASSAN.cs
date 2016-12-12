namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTASSANS")]
    public partial class CLTASSAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTASSAN()
        {
            CLTASSCHANS = new HashSet<CLTASSCHAN>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [StringLength(80)]
        public string CAVALUETEXT { get; set; }

        [StringLength(80)]
        public string CAVALUETEXT2 { get; set; }

        [Column(TypeName = "text")]
        public string CAVALUEMEMO { get; set; }

        public decimal? CAVALUENUM { get; set; }

        public decimal? CAVALUENUM2 { get; set; }

        public DateTime? CAVALUEDATE { get; set; }

        public DateTime? CAVALUEDATE2 { get; set; }

        [StringLength(255)]
        public string CAAUX_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSCHAN> CLTASSCHANS { get; set; }
    }
}
