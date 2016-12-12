namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDSTATHIST")]
    public partial class ORDSTATHIST
    {
        [Key]
        [StringLength(14)]
        public string HISTORY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ORDER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime EFFDATE { get; set; }

        public DateTime? AUXDATE { get; set; }

        [StringLength(40)]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string ACTDONE { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
