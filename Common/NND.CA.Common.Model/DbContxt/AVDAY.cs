namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AVDAYS")]
    public partial class AVDAY
    {
        [Key]
        [StringLength(14)]
        public string DAY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ROTATE_ID { get; set; }

        [StringLength(40)]
        public string NAME { get; set; }

        [Required]
        [StringLength(1)]
        public string AVAILABLE { get; set; }

        public int? ROTINDEX { get; set; }

        public int? AVTIMES { get; set; }

        public DateTime? START1 { get; set; }

        public DateTime? STOP1 { get; set; }

        public DateTime? START2 { get; set; }

        public DateTime? STOP2 { get; set; }

        public DateTime? START3 { get; set; }

        public DateTime? STOP3 { get; set; }

        public DateTime? START4 { get; set; }

        public DateTime? STOP4 { get; set; }

        public DateTime? START5 { get; set; }

        public DateTime? STOP5 { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual AVROTATE AVROTATE { get; set; }
    }
}
