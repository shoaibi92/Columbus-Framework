namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COORDS")]
    public partial class COORD
    {
        [Key]
        [StringLength(14)]
        public string COORD_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string NAME { get; set; }

        [StringLength(12)]
        public string PHONE { get; set; }

        [StringLength(10)]
        public string EXT { get; set; }

        [StringLength(1)]
        public string COORDTYPE { get; set; }

        [Required]
        [StringLength(14)]
        public string FUNDER_ID { get; set; }

        public virtual FUNDER FUNDER { get; set; }
    }
}
