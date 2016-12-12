namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTMEDS")]
    public partial class CLTMED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLTMED()
        {
            CLTASSMEDS = new HashSet<CLTASSMED>();
            CLTMEDENTRIES = new HashSet<CLTMEDENTRy>();
            MDS = new HashSet<MD>();
            RAI_ASSESS = new HashSet<RAI_ASSESS>();
        }

        [Key]
        [StringLength(14)]
        public string CLTMED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(14)]
        public string MED_ID { get; set; }

        [StringLength(10)]
        public string CODE { get; set; }

        [StringLength(180)]
        public string DESCR { get; set; }

        [StringLength(20)]
        public string DOSAGE { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? RENEWED { get; set; }

        public DateTime? REORDER { get; set; }

        public DateTime? MEDENDDATE { get; set; }

        [Column(TypeName = "text")]
        public string MANAGEABIL { get; set; }

        [StringLength(1)]
        public string REMINDER { get; set; }

        public DateTime? PRESCRIBED { get; set; }

        public DateTime? ASSESSDATE { get; set; }

        [Column(TypeName = "text")]
        public string MEDUSE { get; set; }

        [StringLength(10)]
        public string FUNCTCODE { get; set; }

        [StringLength(25)]
        public string FUNCTDESCR { get; set; }

        [StringLength(10)]
        public string INFCODE { get; set; }

        [StringLength(25)]
        public string SUPPDESCR { get; set; }

        [StringLength(1)]
        public string FURTHEVAL { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        [StringLength(14)]
        public string DOCTOR { get; set; }

        [StringLength(14)]
        public string PHARMACY { get; set; }

        [StringLength(1)]
        public string REVIEW { get; set; }

        [StringLength(20)]
        public string ROUTE { get; set; }

        [StringLength(20)]
        public string FREQUENCY { get; set; }

        public DateTime? REVIEWDATE { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public DateTime? HISTDATE { get; set; }

        [StringLength(20)]
        public string HISTCODE { get; set; }

        [StringLength(30)]
        public string HISTOUTCOM { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(30)]
        public string DOSUNITS { get; set; }

        [StringLength(30)]
        public string PRESAMT { get; set; }

        [StringLength(30)]
        public string PRESSTR { get; set; }

        [StringLength(30)]
        public string MEDSTATUS { get; set; }

        [StringLength(3)]
        public string SORTORDER { get; set; }

        [StringLength(14)]
        public string MEDDB_ID { get; set; }

        public DateTime? PSTARTDATE { get; set; }

        public DateTime? PSTOPDATE { get; set; }

        public DateTime? PDISCDATE { get; set; }

        public DateTime? ADISCDATE { get; set; }

        public DateTime? DISCDATE { get; set; }

        [StringLength(255)]
        public string DISCUSER { get; set; }

        public DateTime? TIMEDUE { get; set; }

        [StringLength(1)]
        public string RECTYPE { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        public DateTime? TIMEDUE1 { get; set; }

        public DateTime? TIMEDUE2 { get; set; }

        public DateTime? TIMEDUE3 { get; set; }

        [StringLength(20)]
        public string ADMINSITE { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTASSMED> CLTASSMEDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLTMEDENTRy> CLTMEDENTRIES { get; set; }

        public virtual MEDICATION MEDICATION { get; set; }

        public virtual FRMCONTACT FRMCONTACT { get; set; }

        public virtual FRMCONTACT FRMCONTACT1 { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD> MDS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RAI_ASSESS> RAI_ASSESS { get; set; }
    }
}
