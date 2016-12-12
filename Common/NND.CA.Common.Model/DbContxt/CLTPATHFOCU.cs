namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTPATHFOCUS")]
    public partial class CLTPATHFOCU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTPATH_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string CAT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual CLTPATHWAY CLTPATHWAY { get; set; }

        public virtual PATHCAT PATHCAT { get; set; }
    }
}
