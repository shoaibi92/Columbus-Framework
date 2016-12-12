namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OASISCOMMS")]
    public partial class OASISCOMM
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string OASIS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string M0NUMBER { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? CHGDATE { get; set; }

        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual OASIS OASIS { get; set; }
    }
}
