namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVALIDPASS")]
    public partial class INVALIDPASS
    {
        [Key]
        [StringLength(14)]
        public string INVPASS_ID { get; set; }

        [StringLength(14)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(100)]
        public string PASSWRD { get; set; }

        public int PASSINDEX { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual USER USER { get; set; }
    }
}
