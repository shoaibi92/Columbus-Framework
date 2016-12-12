namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRORDERS")]
    public partial class DRORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DRORDER()
        {
            DRORDERSLOGs = new HashSet<DRORDERSLOG>();
            DRORDERS1 = new HashSet<DRORDER>();
            Oases = new HashSet<OASIS>();
        }

        [Key]
        [StringLength(14)]
        public string DRORDER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string ORDERTYPE { get; set; }

        [StringLength(14)]
        public string CONTACT_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        public DateTime? DATEENTERED { get; set; }

        public DateTime? DATEPRINTED { get; set; }

        public DateTime? DATEMAILED { get; set; }

        public DateTime? DATESIGNED { get; set; }

        public DateTime? DATERECEIVED { get; set; }

        [Column(TypeName = "text")]
        public string ORDERCOMMENTS { get; set; }

        [Column(TypeName = "text")]
        public string GOALCOMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public DateTime? DATEDUE { get; set; }

        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [StringLength(14)]
        public string POCLINK_ID { get; set; }

        public string PROPS { get; set; }

        public virtual CLTASSESS CLTASSESS { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual FRMCONTACT FRMCONTACT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRORDERSLOG> DRORDERSLOGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DRORDER> DRORDERS1 { get; set; }

        public virtual DRORDER DRORDER1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OASIS> Oases { get; set; }
    }
}
