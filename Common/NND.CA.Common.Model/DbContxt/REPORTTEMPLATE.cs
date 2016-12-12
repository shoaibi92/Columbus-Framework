namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REPORTTEMPLATES")]
    public partial class REPORTTEMPLATE
    {
        [Key]
        [StringLength(14)]
        public string TEMPLATE_ID { get; set; }

        [Required]
        [StringLength(7)]
        public string RECTYPE { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(80)]
        public string REPORTKEY { get; set; }

        [Required]
        [StringLength(80)]
        public string NAME { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string TEMPLATE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual USER USER { get; set; }
    }
}
