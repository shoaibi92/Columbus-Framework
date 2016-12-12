namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQUESTSX")]
    public partial class ASSQUESTSX
    {
        [Key]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] DEFIMAGE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSQUEST ASSQUEST { get; set; }
    }
}
