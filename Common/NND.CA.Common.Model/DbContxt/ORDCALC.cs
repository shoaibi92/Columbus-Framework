namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDCALC")]
    public partial class ORDCALC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDCALC()
        {
            ORDCALCINVGRPs = new HashSet<ORDCALCINVGRP>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string PERIOD_ID { get; set; }

        [StringLength(1000)]
        public string CALCREASON { get; set; }

        [StringLength(255)]
        public string CALCUSER { get; set; }

        public DateTime? CALCDATE { get; set; }

        [StringLength(1)]
        public string BILLCALC { get; set; }

        public int? INVNUM { get; set; }

        [StringLength(1)]
        public string REVIEWED { get; set; }

        [StringLength(255)]
        public string REVIEWUSER { get; set; }

        public DateTime? REVIEWDATE { get; set; }

        [StringLength(1)]
        public string CALCERROR { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual FUNDEPTPER FUNDEPTPER { get; set; }

        public virtual ORDER ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDCALCINVGRP> ORDCALCINVGRPs { get; set; }
    }
}
