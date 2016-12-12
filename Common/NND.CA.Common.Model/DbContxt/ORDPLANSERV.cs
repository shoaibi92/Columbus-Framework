namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDPLANSERVS")]
    public partial class ORDPLANSERV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ORDPLAN_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string SERVTYPE_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }

        public virtual ORDPLAN ORDPLAN { get; set; }
    }
}
