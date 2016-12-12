namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTFOLDERS")]
    public partial class CLTFOLDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTFOLDER()
        {
            CLTASSESSes = new HashSet<CLTASSESS>();
            CLTDOCS = new HashSet<CLTDOC>();
            CLTFOLDERS1 = new HashSet<CLTFOLDER>();
            CLTPATHWAYS = new HashSet<CLTPATHWAY>();
            MDS = new HashSet<MD>();
            Oases = new HashSet<OASIS>();
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string PARENT_ID { get; set; }

        [StringLength(80)]
        public string DESCR { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTDOC> CLTDOCS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTFOLDER> CLTFOLDERS1 { get; set; }

        public virtual CLTFOLDER CLTFOLDER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHWAY> CLTPATHWAYS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD> MDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }
    }
}
