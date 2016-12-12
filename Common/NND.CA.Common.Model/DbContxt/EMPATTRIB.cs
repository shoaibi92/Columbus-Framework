namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPATTRIB")]
    public partial class EMPATTRIB
    {
        [Key]
        [StringLength(14)]
        public string ATTRB_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string LOOKUPVAL_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string DISLIKE { get; set; }

        [StringLength(255)]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual LOOKUPVAL LOOKUPVAL { get; set; }
    }
}
