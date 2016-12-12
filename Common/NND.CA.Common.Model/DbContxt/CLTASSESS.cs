namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTASSESS")]
    public partial class CLTASSESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTASSESS()
        {
            CLTASSANS = new HashSet<CLTASSAN>();
            CLTASSESS1 = new HashSet<CLTASSESS>();
            CLTASSLOGs = new HashSet<CLTASSLOG>();
            CLTASSMEDS = new HashSet<CLTASSMED>();
            CLTMEDENTRIES = new HashSet<CLTMEDENTRy>();
            CLTPATHVISITS = new HashSet<CLTPATHVISIT>();
            DRORDERS = new HashSet<DRORDER>();
            MDS = new HashSet<MD>();
            Oases = new HashSet<OASIS>();
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string CAASSSTATE { get; set; }

        public DateTime? CAASSDATE { get; set; }

        [StringLength(30)]
        public string CAREFNUMBER { get; set; }

        public DateTime? CACOMPDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string CAASSTYPE { get; set; }

        [StringLength(14)]
        public string CAASSESSOR_ID { get; set; }

        public int? CATIMESPENT { get; set; }

        public decimal? CASCORE { get; set; }

        [StringLength(1)]
        public string CALEVEL { get; set; }

        [StringLength(14)]
        public string REQ_ID { get; set; }

        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [StringLength(14)]
        public string VISIT_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string CARECSTATUS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(30)]
        public string CACUSTOMSTATUS { get; set; }

        [StringLength(14)]
        public string FOLDER_ID { get; set; }

        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        public DateTime? LOCKDATE { get; set; }

        [StringLength(14)]
        public string PCLTASS_ID { get; set; }

        [StringLength(14)]
        public string PQUESTION_ID { get; set; }

        public DateTime? SENTDATE { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSAN> CLTASSANS { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual VISIT VISIT { get; set; }

        public virtual CLTSUPREQ CLTSUPREQ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSESS> CLTASSESS1 { get; set; }

        public virtual CLTASSESS CLTASSESS2 { get; set; }

        public virtual CLTFOLDER CLTFOLDER { get; set; }

        public virtual CLTPATHWAY CLTPATHWAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSLOG> CLTASSLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSMED> CLTASSMEDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMEDENTRy> CLTMEDENTRIES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTPATHVISIT> CLTPATHVISITS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRORDER> DRORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD> MDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }
    }
}
