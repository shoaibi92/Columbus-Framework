namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLANG")]
    public partial class EMPLANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

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

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
