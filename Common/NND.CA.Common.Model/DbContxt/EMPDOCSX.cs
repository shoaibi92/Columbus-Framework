namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPDOCSX")]
    public partial class EMPDOCSX
    {
        [Key]
        [StringLength(14)]
        public string EMPDOC_ID { get; set; }

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

        public virtual EMPDOC EMPDOC { get; set; }
    }
}
