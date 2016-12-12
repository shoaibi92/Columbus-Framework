namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTLANG")]
    public partial class CLTLANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string LANG_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [Column(TypeName = "text")]
        public string LCOMMENTS { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
