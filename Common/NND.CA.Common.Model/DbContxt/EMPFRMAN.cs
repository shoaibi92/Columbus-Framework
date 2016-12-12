namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPFRMANS")]
    public partial class EMPFRMAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPFRMAN()
        {
            EMPFRMCHANS = new HashSet<EMPFRMCHAN>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMPFRM_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [StringLength(80)]
        public string EFVALUETEXT { get; set; }

        [StringLength(80)]
        public string EFVALUETEXT2 { get; set; }

        [Column(TypeName = "text")]
        public string EFVALUEMEMO { get; set; }

        public decimal? EFVALUENUM { get; set; }

        public decimal? EFVALUENUM2 { get; set; }

        public DateTime? EFVALUEDATE { get; set; }

        public DateTime? EFVALUEDATE2 { get; set; }

        [StringLength(255)]
        public string EFAUX_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual EMPFRM EMPFRM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMCHAN> EMPFRMCHANS { get; set; }
    }
}
