namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REMOTETEAMS")]
    public partial class REMOTETEAM
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string USER_ID2 { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual USER USER { get; set; }

        public virtual USER USER1 { get; set; }
    }
}
