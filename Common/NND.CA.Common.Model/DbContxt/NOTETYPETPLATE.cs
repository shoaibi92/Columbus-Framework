namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOTETYPETPLATES")]
    public partial class NOTETYPETPLATE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string TYPE_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string TEMPLATE_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual NOTETEMPLATE NOTETEMPLATE { get; set; }

        public virtual NOTETYPE NOTETYPE { get; set; }
    }
}
