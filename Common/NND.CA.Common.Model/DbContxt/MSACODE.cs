namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MSACODES")]
    public partial class MSACODE
    {
        [Key]
        [StringLength(14)]
        public string MSA_ID { get; set; }

        [Column("MSACODE")]
        [Required]
        [StringLength(5)]
        public string MSACODE1 { get; set; }

        [Required]
        [StringLength(60)]
        public string MSADESCR { get; set; }

        public decimal WAGEINDEX { get; set; }

        [Required]
        [StringLength(1)]
        public string AVAILABLE { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(1)]
        public string RURALMSA { get; set; }
    }
}
