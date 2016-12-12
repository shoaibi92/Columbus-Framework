namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EQUIPPRES")]
    public partial class EQUIPPRE
    {
        [Key]
        [StringLength(14)]
        public string EQPRES_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EQUIP_ID { get; set; }

        [StringLength(1)]
        public string MISSING { get; set; }

        [StringLength(1)]
        public string REQUIRED { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
