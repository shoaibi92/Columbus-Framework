namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFALERTACTIONS")]
    public partial class WFALERTACTION
    {
        [Key]
        [StringLength(14)]
        public string WFALERTACTION_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string WFALERT_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string WFACTION_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string WFACTDATA { get; set; }

        [Required]
        [StringLength(6)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(80)]
        public string DESCR { get; set; }

        public virtual WFACTION WFACTION { get; set; }

        public virtual WFALERT WFALERT { get; set; }
    }
}
