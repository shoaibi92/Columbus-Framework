namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARTNERS")]
    public partial class PARTNER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTNER()
        {
            PARTNERXMLs = new HashSet<PARTNERXML>();
        }

        [Key]
        [StringLength(14)]
        public string PARTNER_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string NAME { get; set; }

        [Required]
        [StringLength(40)]
        public string REFNUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string PENABLED { get; set; }

        [Required]
        [StringLength(1)]
        public string LOGTRX { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(255)]
        public string USERNAME { get; set; }

        [StringLength(128)]
        public string PASSWRD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARTNERXML> PARTNERXMLs { get; set; }
    }
}
