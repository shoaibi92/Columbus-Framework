namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPTASSESS")]
    public partial class DEPTASSESS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ASSESS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [StringLength(1)]
        public string AVIEWONLY { get; set; }

        public virtual ASSESSMENT ASSESSMENT { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }
    }
}
