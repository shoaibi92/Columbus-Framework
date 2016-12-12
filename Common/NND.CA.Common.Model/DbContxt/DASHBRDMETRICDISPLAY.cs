namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDMETRICDISPLAY")]
    public partial class DASHBRDMETRICDISPLAY
    {
        [Key]
        [StringLength(14)]
        public string DISPLAY_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string METRIC_ID { get; set; }

        public int DISPINDEX { get; set; }

        [StringLength(40)]
        public string DISPLABEL { get; set; }

        [StringLength(40)]
        public string DISPFORMAT { get; set; }

        public int DISPWIDTH { get; set; }

        [Required]
        [StringLength(1)]
        public string DISPPERCENT { get; set; }

        [Required]
        [StringLength(1)]
        public string DISPVISIBLE { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual DASHBRDMETRIC DASHBRDMETRIC { get; set; }
    }
}
