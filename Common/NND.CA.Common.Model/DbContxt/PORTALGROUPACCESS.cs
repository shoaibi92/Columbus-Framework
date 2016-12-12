namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PORTALGROUPACCESS")]
    public partial class PORTALGROUPACCESS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string ACCESS_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual PORTALACCESSRIGHT PORTALACCESSRIGHT { get; set; }

        public virtual PORTALGROUP PORTALGROUP { get; set; }
    }
}
