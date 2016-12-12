namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHCATS")]
    public partial class PATHCAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHCAT()
        {
            ASSQPATHDEPENDS = new HashSet<ASSQPATHDEPEND>();
            ASSSECTS = new HashSet<ASSSECT>();
            ASSSECTS1 = new HashSet<ASSSECT>();
            ASSSECTS2 = new HashSet<ASSSECT>();
            CLTPATHFOCUS = new HashSet<CLTPATHFOCU>();
            CLTPATHVISITNOTES = new HashSet<CLTPATHVISITNOTE>();
            PATHITEMS = new HashSet<PATHITEM>();
            PATHITEMS1 = new HashSet<PATHITEM>();
            PATHITEMS2 = new HashSet<PATHITEM>();
            PATHSTEPS = new HashSet<PATHSTEP>();
        }

        [Key]
        [StringLength(14)]
        public string CAT_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

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

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(20)]
        public string SHORTDESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSQPATHDEPEND> ASSQPATHDEPENDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSSECT> ASSSECTS2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHFOCU> CLTPATHFOCUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISITNOTE> CLTPATHVISITNOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHITEM> PATHITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHITEM> PATHITEMS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHITEM> PATHITEMS2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHSTEP> PATHSTEPS { get; set; }
    }
}
