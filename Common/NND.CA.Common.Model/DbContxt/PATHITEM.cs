namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHITEMS")]
    public partial class PATHITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHITEM()
        {
            ASSQPATHDEPENDS = new HashSet<ASSQPATHDEPEND>();
            CLTPATHITEMS = new HashSet<CLTPATHITEM>();
            CLTPATHITEMSXes = new HashSet<CLTPATHITEMSX>();
            CLTPATHVISITNOTES = new HashSet<CLTPATHVISITNOTE>();
            PATHSTEPITEMS = new HashSet<PATHSTEPITEM>();
            PATHSTEPITEMLINKS = new HashSet<PATHSTEPITEMLINK>();
            PATHSTEPITEMLINKS1 = new HashSet<PATHSTEPITEMLINK>();
        }

        [Key]
        [StringLength(14)]
        public string ITEM_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CAT_ID { get; set; }

        [Required]
        [StringLength(6)]
        public string ISORTORDER { get; set; }

        [Required]
        [StringLength(1000)]
        public string LABELTEXT { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Required]
        [StringLength(14)]
        public string FCAT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DCAT_ID { get; set; }

        [StringLength(1)]
        public string IREQUIRED { get; set; }

        [StringLength(1)]
        public string COMPLETEONCE { get; set; }

        [StringLength(1)]
        public string PRINTPOT { get; set; }

        [StringLength(1)]
        public string RECCLASS { get; set; }

        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        [StringLength(1)]
        public string ICOPY { get; set; }

        [StringLength(1000)]
        public string POTLABELTEXT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQPATHDEPEND> ASSQPATHDEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEM> CLTPATHITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEMSX> CLTPATHITEMSXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISITNOTE> CLTPATHVISITNOTES { get; set; }

        public virtual CLTPATHWAY CLTPATHWAY { get; set; }

        public virtual PATHCAT PATHCAT { get; set; }

        public virtual PATHCAT PATHCAT1 { get; set; }

        public virtual PATHCAT PATHCAT2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEPITEM> PATHSTEPITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEPITEMLINK> PATHSTEPITEMLINKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEPITEMLINK> PATHSTEPITEMLINKS1 { get; set; }
    }
}
