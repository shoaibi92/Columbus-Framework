namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPTPERIOD")]
    public partial class DEPTPERIOD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? STOPDATE { get; set; }

        [StringLength(1)]
        public string USESCHEDS { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual TIMEPERIOD TIMEPERIOD { get; set; }
    }
}
