namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEPTAGREE")]
    public partial class DEPTAGREE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DEPT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string AGREE_ID { get; set; }

        [StringLength(1)]
        public string USEEMPDBK { get; set; }

        [StringLength(1)]
        public string USEEMPLBR { get; set; }

        [StringLength(1)]
        public string USEEMPDNSD { get; set; }

        [StringLength(1)]
        public string USEEMPSTAT { get; set; }

        [StringLength(1)]
        public string USEEMPAVL { get; set; }

        [StringLength(1)]
        public string USEEMPLIKDIS { get; set; }

        [StringLength(1)]
        public string TKSTATACT { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual LABORAGREE LABORAGREE { get; set; }
    }
}
