namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DASHBRDGROUPS")]
    public partial class DASHBRDGROUP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string DASHBRD_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual DASHBRD DASHBRD { get; set; }

        public virtual GROUP GROUP { get; set; }
    }
}
