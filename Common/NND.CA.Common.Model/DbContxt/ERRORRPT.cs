namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ERRORRPTS")]
    public partial class ERRORRPT
    {
        [Key]
        [StringLength(14)]
        public string REPORT_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [Required]
        [StringLength(1)]
        public string RECTYPE { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [Required]
        [StringLength(10)]
        public string APPVERSION { get; set; }

        [StringLength(10)]
        public string DBVERSION { get; set; }

        [Required]
        [StringLength(255)]
        public string DESCR { get; set; }

        [Column(TypeName = "text")]
        public string DETAILS { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [StringLength(80)]
        public string COMPNAME { get; set; }

        [StringLength(14)]
        public string REGKEY { get; set; }

        [StringLength(1)]
        public string SENT { get; set; }

        public DateTime? SENTDATE { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public DateTime? UTCINTAKE { get; set; }
    }
}
