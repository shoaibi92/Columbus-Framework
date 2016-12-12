namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLNOTES")]
    public partial class EMPLNOTE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string NOTE_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual DATEDNOTE DATEDNOTE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual EMPLDEPT EMPLDEPT { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
