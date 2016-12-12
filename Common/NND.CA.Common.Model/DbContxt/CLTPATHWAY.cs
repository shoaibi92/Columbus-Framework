namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTPATHWAYS")]
    public partial class CLTPATHWAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTPATHWAY()
        {
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTPATHCOSTEPS = new HashSet<CLTPATHCOSTEP>();
            CLTPATHFOCUS = new HashSet<CLTPATHFOCU>();
            CLTPATHITEMSXes = new HashSet<CLTPATHITEMSX>();
            CLTPATHVISITS = new HashSet<CLTPATHVISIT>();
            PATHITEMS = new HashSet<PATHITEM>();
        }

        [Key]
        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string PATHWAY_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [StringLength(60)]
        public string RECREASON { get; set; }

        [StringLength(20)]
        public string RECTYPE { get; set; }

        public DateTime STARTDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string STARTUSER { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(255)]
        public string STOPUSER { get; set; }

        [Required]
        [StringLength(1)]
        public string NEXTACTION { get; set; }

        [Required]
        [StringLength(1)]
        public string COSTEPSEXIST { get; set; }

        [StringLength(14)]
        public string MERGESTEP_ID { get; set; }

        [StringLength(14)]
        public string DPATHWAY_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        public virtual CLTFOLDER CLTFOLDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHCOSTEP> CLTPATHCOSTEPS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHFOCU> CLTPATHFOCUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHITEMSX> CLTPATHITEMSXes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS { get; set; }

        public virtual PATHWAY PATHWAY { get; set; }

        public virtual PATHSTEP PATHSTEP { get; set; }

        public virtual PATHWAY PATHWAY1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PATHITEM> PATHITEMS { get; set; }
    }
}
