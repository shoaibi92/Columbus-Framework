namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROTRANSLATE")]
    public partial class PROTRANSLATE
    {
        [Key]
        [StringLength(14)]
        public string PTL_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string PTLSOURCE { get; set; }

        [StringLength(255)]
        public string PTLFRENCH { get; set; }

        [StringLength(255)]
        public string PTLSPANISH { get; set; }
    }
}
