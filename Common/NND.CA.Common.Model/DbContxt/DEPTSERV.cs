namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPTSERV")]
    public partial class DEPTSERV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string TABLE_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual SERVTABLE SERVTABLE { get; set; }
    }
}
