namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RAI_ASSESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RAI_ASSESS()
        {
            RAI_DATA = new HashSet<RAI_DATA>();
            RAI_LOG = new HashSet<RAI_LOG>();
            RAI_NOTES = new HashSet<RAI_NOTES>();
            RAI_SECTION = new HashSet<RAI_SECTION>();
            CLTDIAGs = new HashSet<CLTDIAG>();
            CLTMEDS = new HashSet<CLTMED>();
        }

        [Key]
        [StringLength(14)]
        public string RAI_ASSESS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [Required]
        [StringLength(8)]
        public string ASSESSTYPE { get; set; }

        public DateTime ASSESSDATE { get; set; }

        [Required]
        [StringLength(2)]
        public string RFA { get; set; }

        [Required]
        [StringLength(80)]
        public string SUPPLEMENTS { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime STATUSDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string STATUSUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [StringLength(14)]
        public string EXPORT_ID { get; set; }

        [StringLength(80)]
        public string CANCELREASON { get; set; }

        public DateTime? EXPORTDATE { get; set; }

        [StringLength(255)]
        public string EXPORTUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual CLTFOLDER CLTFOLDER { get; set; }

        public virtual TRANSBATCH TRANSBATCH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_DATA> RAI_DATA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_LOG> RAI_LOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_NOTES> RAI_NOTES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_SECTION> RAI_SECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDIAG> CLTDIAGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMED> CLTMEDS { get; set; }
    }
}
