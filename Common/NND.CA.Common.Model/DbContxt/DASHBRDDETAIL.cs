namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDDETAILS")]
    public partial class DASHBRDDETAIL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DASHBRD_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string SORTORDER { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC { get; set; }

        public virtual DASHBRD DASHBRD { get; set; }
    }
}
