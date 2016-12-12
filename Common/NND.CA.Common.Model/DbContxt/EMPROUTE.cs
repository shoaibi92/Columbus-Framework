namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPROUTES")]
    public partial class EMPROUTE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string ROUTE_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual ROUTE ROUTE { get; set; }
    }
}
