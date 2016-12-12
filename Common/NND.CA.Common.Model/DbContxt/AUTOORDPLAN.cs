namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUTOORDPLAN")]
    public partial class AUTOORDPLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTOORDPLAN()
        {
            AUTOORDPLANSERVS = new HashSet<AUTOORDPLANSERV>();
        }

        [Key]
        [StringLength(14)]
        public string AUTOPLAN_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SERVTYPE_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        [Required]
        [StringLength(10)]
        public string PLANCLASS { get; set; }

        [Required]
        [StringLength(1)]
        public string FREQTYPE { get; set; }

        [StringLength(1)]
        public string FREQUNIT { get; set; }

        public decimal? FREQVALUEMIN { get; set; }

        public decimal? FREQVALUE { get; set; }

        [StringLength(30)]
        public string FREQUNITS { get; set; }

        public decimal? FREQVISITS { get; set; }

        public int? FREQNUM { get; set; }

        public int? FREQDUR { get; set; }

        [StringLength(40)]
        public string CUSTOMPLAN { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(60)]
        public string SERVAUTH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOORDPLANSERV> AUTOORDPLANSERVS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual FUNDER FUNDER { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
