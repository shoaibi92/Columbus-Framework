namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUTOORDPLANSERVS")]
    public partial class AUTOORDPLANSERV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string AUTOPLAN_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string SERVTYPE_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual AUTOORDPLAN AUTOORDPLAN { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
