namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROUTEDDEFS")]
    public partial class ROUTEDDEF
    {
        [Key]
        [StringLength(14)]
        public string ROUTEDEF_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string DAY_ID { get; set; }

        [StringLength(14)]
        public string SCHED_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string REQDEF_ID { get; set; }

        [StringLength(14)]
        public string EMP_ID { get; set; }

        [StringLength(1)]
        public string PAYABLE { get; set; }

        [StringLength(14)]
        public string PAYREC_ID { get; set; }

        [StringLength(14)]
        public string ROUTESDEF_ID { get; set; }

        public decimal? VOLHOURS { get; set; }

        public decimal? VOLKMS { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual PAYRECORD PAYRECORD { get; set; }

        public virtual REQDEF REQDEF { get; set; }

        public virtual ROUTEDAY ROUTEDAY { get; set; }

        public virtual ROUTESCHED ROUTESCHED { get; set; }

        public virtual ROUTESDEF ROUTESDEF { get; set; }
    }
}
