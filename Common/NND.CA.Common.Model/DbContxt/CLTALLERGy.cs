namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTALLERGIES")]
    public partial class CLTALLERGy
    {
        [Key]
        [StringLength(14)]
        public string CLTALGY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string ALERGY_ID { get; set; }

        [StringLength(1)]
        public string TYPE { get; set; }

        [StringLength(5)]
        public string CODE { get; set; }

        [StringLength(30)]
        public string DESCR { get; set; }

        [StringLength(30)]
        public string INTERVENT { get; set; }

        [StringLength(15)]
        public string DEGREE { get; set; }

        [Column(TypeName = "text")]
        public string INTRVNOTES { get; set; }

        public DateTime? DIAGNSDATE { get; set; }

        [StringLength(10)]
        public string INFCODE { get; set; }

        [StringLength(25)]
        public string FUNCTDESCR { get; set; }

        [StringLength(1)]
        public string FURTHEVAL { get; set; }

        public DateTime? REPORTDATE { get; set; }

        [StringLength(10)]
        public string FUNCTCODE { get; set; }

        [StringLength(25)]
        public string INFDESCR { get; set; }

        [StringLength(1)]
        public string DNOTIFY { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string ARCHIVED { get; set; }

        public virtual ALLERGy ALLERGy { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
