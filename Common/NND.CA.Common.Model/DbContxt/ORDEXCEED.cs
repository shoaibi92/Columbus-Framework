namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDEXCEED")]
    public partial class ORDEXCEED
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        public decimal MAXAMT { get; set; }

        public decimal EXCEEDAMT { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
