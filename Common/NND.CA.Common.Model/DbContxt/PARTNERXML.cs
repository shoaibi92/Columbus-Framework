namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARTNERXML")]
    public partial class PARTNERXML
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string PARTNER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string XML_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual PARTNER PARTNER { get; set; }

        public virtual XMLTRX XMLTRX { get; set; }
    }
}
