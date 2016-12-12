namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GEODATA")]
    public partial class GEODATA
    {
        [Key]
        [StringLength(14)]
        public string GEO_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string AUX_ID { get; set; }

        [StringLength(255)]
        public string AUX_ID2 { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(20)]
        public string CODE { get; set; }

        public decimal LAT { get; set; }

        public decimal LONG { get; set; }

        [StringLength(20)]
        public string ACCURACY { get; set; }

        [StringLength(100)]
        public string SOURCE { get; set; }

        [StringLength(100)]
        public string SOURCEDET { get; set; }

        [StringLength(1000)]
        public string PROPS { get; set; }

        public DateTime INTAKE { get; set; }

        public DateTime UTCINTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        public DateTime UTCCHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }
    }
}
