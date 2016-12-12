namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLNTNOTES")]
    public partial class CLNTNOTE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string NOTE_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual DATEDNOTE DATEDNOTE { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
