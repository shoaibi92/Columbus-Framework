namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDPLAN")]
    public partial class ORDPLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDPLAN()
        {
            ORDPLANCANCELs = new HashSet<ORDPLANCANCEL>();
            ORDPLANSERVS = new HashSet<ORDPLANSERV>();
        }

        [Key]
        [StringLength(14)]
        public string ORDPLAN_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SERVTYPE_ID { get; set; }

        public DateTime EFFDATE { get; set; }

        [Required]
        [StringLength(10)]
        public string PLANCLASS { get; set; }

        [Required]
        [StringLength(1)]
        public string FREQTYPE { get; set; }

        public decimal? FREQVALUE { get; set; }

        public decimal? FREQVALUEMIN { get; set; }

        [StringLength(30)]
        public string FREQUNITS { get; set; }

        public int? FREQDUR { get; set; }

        [Required]
        [StringLength(40)]
        public string CUSTOMPLAN { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [Required]
        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? EXPDATE { get; set; }

        [StringLength(1)]
        public string FREQUNIT { get; set; }

        [StringLength(60)]
        public string SERVAUTH { get; set; }

        public decimal? FREQVISITS { get; set; }

        public int? FREQNUM { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public DateTime? SENTDATE { get; set; }

        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [StringLength(20)]
        public string FREQTIMEDESCR { get; set; }

        public string PROPS { get; set; }

        public int? BLOCKCOUNT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual ORDER ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDPLANCANCEL> ORDPLANCANCELs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDPLANSERV> ORDPLANSERVS { get; set; }
    }
}
