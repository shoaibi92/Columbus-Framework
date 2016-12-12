namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQUESTS")]
    public partial class ASSQUEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASSQUEST()
        {
            ASSCHOICES = new HashSet<ASSCHOICE>();
            ASSQDEPENDS = new HashSet<ASSQDEPEND>();
            ASSQDEPENDS1 = new HashSet<ASSQDEPEND>();
            ASSQMDSHCDEPENDS = new HashSet<ASSQMDSHCDEPEND>();
            ASSQPATHDEPENDS = new HashSet<ASSQPATHDEPEND>();
            CLTASSANS = new HashSet<CLTASSAN>();
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTASSLOGCHGs = new HashSet<CLTASSLOGCHG>();
            EMPFRMANS = new HashSet<EMPFRMAN>();
            EMPFRMLOGCHGs = new HashSet<EMPFRMLOGCHG>();
            EMPFRMS = new HashSet<EMPFRM>();
            NOTETYPES = new HashSet<NOTETYPE>();
        }

        [Key]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string SECTION_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string QNAME { get; set; }

        [Column(TypeName = "text")]
        public string QINSTRUCT { get; set; }

        [Required]
        [StringLength(3)]
        public string QSORTORDER { get; set; }

        [Required]
        [StringLength(15)]
        public string QTYPE { get; set; }

        [StringLength(15)]
        public string QCTYPE { get; set; }

        [StringLength(80)]
        public string QMASK { get; set; }

        [Required]
        [StringLength(1)]
        public string QREQUIRED { get; set; }

        public decimal? QMINVALUE { get; set; }

        public decimal? QMAXVALUE { get; set; }

        public int? QMAXLENGTH { get; set; }

        [StringLength(30)]
        public string QCUSTNUMBER { get; set; }

        [StringLength(100)]
        public string QREFNUMBER { get; set; }

        public int? QCHCOLS { get; set; }

        [Required]
        [StringLength(1)]
        public string QCHLAYOUT { get; set; }

        [Required]
        [StringLength(1)]
        public string QWHOLENUMS { get; set; }

        [Required]
        [StringLength(1)]
        public string QFREEFORM { get; set; }

        [Required]
        [StringLength(1)]
        public string QALLOWTIME { get; set; }

        [Required]
        [StringLength(1)]
        public string QWEIGHTED { get; set; }

        [Required]
        [StringLength(1)]
        public string QDEPENDS { get; set; }

        [Required]
        [StringLength(1)]
        public string QLIBRARY { get; set; }

        [StringLength(5)]
        public string QSEPARATOR { get; set; }

        [StringLength(10)]
        public string QVALUNITS { get; set; }

        [StringLength(1)]
        public string QSYSDEFINED { get; set; }

        [StringLength(1)]
        public string QRECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string QRECSTATUS { get; set; }

        [StringLength(14)]
        public string LOOKUP_ID { get; set; }

        [StringLength(14)]
        public string NUMBER_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string SERVICE_ID { get; set; }

        [StringLength(1)]
        public string PRINTPOT { get; set; }

        [StringLength(1)]
        public string QMDSHCDEPENDS { get; set; }

        [StringLength(1)]
        public string QCOPY { get; set; }

        [StringLength(1)]
        public string QALLOWEDIT { get; set; }

        [StringLength(1)]
        public string QALLOWLOAD { get; set; }

        [StringLength(1)]
        public string QSHRINKFIT { get; set; }

        public int? QMAXHEIGHT { get; set; }

        public decimal? QMAXSIZE { get; set; }

        [StringLength(1)]
        public string QPATHDEPENDS { get; set; }

        [StringLength(14)]
        public string QFLOWASSESS_ID { get; set; }

        [Column(TypeName = "text")]
        public string GUIDELINES { get; set; }

        public string PROPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSCHOICE> ASSCHOICES { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQDEPEND> ASSQDEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQDEPEND> ASSQDEPENDS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQMDSHCDEPEND> ASSQMDSHCDEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQPATHDEPEND> ASSQPATHDEPENDS { get; set; }

        public virtual ASSSECT ASSSECT { get; set; }

        public virtual LOOKUP LOOKUP { get; set; }

        public virtual NUMBER NUMBER { get; set; }

        public virtual SERVICE SERVICE { get; set; }

        public virtual ASSQUESTSX ASSQUESTSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSAN> CLTASSANS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSLOGCHG> CLTASSLOGCHGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMAN> EMPFRMANS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRMLOGCHG> EMPFRMLOGCHGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPFRM> EMPFRMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTETYPE> NOTETYPES { get; set; }
    }
}
