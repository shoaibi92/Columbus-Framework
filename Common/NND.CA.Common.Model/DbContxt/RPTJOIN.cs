namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTJOINS")]
    public partial class RPTJOIN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(60)]
        public string RTABLENAME1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string RTABLENAME2 { get; set; }

        [Required]
        [StringLength(60)]
        public string RJOINTYPE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string RFIELDNAMES1 { get; set; }

        [Required]
        [StringLength(60)]
        public string ROPERATORS { get; set; }

        [Required]
        [StringLength(255)]
        public string RFIELDNAMES2 { get; set; }

        [StringLength(1)]
        public string RCUSTOM { get; set; }
    }
}
