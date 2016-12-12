namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HAZARDS")]
    public partial class HAZARD
    {
        [Key]
        [StringLength(14)]
        public string HAZARD_ID { get; set; }

        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        [StringLength(60)]
        public string DESCR { get; set; }

        [StringLength(60)]
        public string LOCATION { get; set; }

        [StringLength(1)]
        public string HARM_EMP { get; set; }

        [StringLength(1)]
        public string HARM_CLT { get; set; }

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

        public virtual CLIENT CLIENT { get; set; }
    }
}
