namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SYSDOCSX")]
    public partial class SYSDOCSX
    {
        [Key]
        [StringLength(14)]
        public string SYSDOC_ID { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] DOCDATA { get; set; }

        [Column(TypeName = "image")]
        public byte[] DOCDATAX { get; set; }

        [Required]
        [StringLength(10)]
        public string COMPRESSTYPE { get; set; }

        [Required]
        [StringLength(10)]
        public string COMPRESSTYPEX { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual SYSDOC SYSDOC { get; set; }
    }
}
