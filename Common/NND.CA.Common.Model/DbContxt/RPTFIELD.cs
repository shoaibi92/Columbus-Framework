namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTFIELDS")]
    public partial class RPTFIELD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(60)]
        public string RTABLENAME { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string RFIELDNAME { get; set; }

        [Required]
        [StringLength(60)]
        public string RFIELDALIAS { get; set; }

        [Required]
        [StringLength(60)]
        public string RDATATYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RSELECTABLE { get; set; }

        [Required]
        [StringLength(1)]
        public string RSEARCHABLE { get; set; }

        [Required]
        [StringLength(1)]
        public string RSORTABLE { get; set; }

        [Required]
        [StringLength(1)]
        public string RAUTOSEARCH { get; set; }

        [Required]
        [StringLength(1)]
        public string RMANDATORY { get; set; }

        [StringLength(1)]
        public string RCUSTOM { get; set; }
    }
}
