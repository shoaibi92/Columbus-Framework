namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PATHWAYS")]
    public partial class PATHWAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATHWAY()
        {
            CLTPATHWAYS = new HashSet<CLTPATHWAY>();
            CLTPATHWAYS1 = new HashSet<CLTPATHWAY>();
            PATHWAYDEPTS = new HashSet<PATHWAYDEPT>();
            PATHWAYSTEPS = new HashSet<PATHWAYSTEP>();
        }

        [Key]
        [StringLength(14)]
        public string PATHWAY_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string TITLE { get; set; }

        [Required]
        [StringLength(30)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(80)]
        public string CERTBY { get; set; }

        [StringLength(80)]
        public string CERTNOTICE { get; set; }

        [Required]
        [StringLength(1)]
        public string CHANGED { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        [StringLength(20)]
        public string DIAGSTART { get; set; }

        [StringLength(20)]
        public string DIAGSTOP { get; set; }

        [Required]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

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
        public string RECSTATUS { get; set; }

        [StringLength(1)]
        public string ALLOWORDER { get; set; }

        [StringLength(1)]
        public string DYNAMICITEMS { get; set; }

        [StringLength(1)]
        public string MULTIINCOMPLETES { get; set; }

        [StringLength(1)]
        public string SINGLESTEP { get; set; }

        [StringLength(1)]
        public string LINKEDITEMS { get; set; }

        [StringLength(1)]
        public string LINKEDITEMSAUTOMET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHWAY> CLTPATHWAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHWAY> CLTPATHWAYS1 { get; set; }

        public virtual PATHVCODETABLE PATHVCODETABLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHWAYDEPT> PATHWAYDEPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHWAYSTEP> PATHWAYSTEPS { get; set; }
    }
}
