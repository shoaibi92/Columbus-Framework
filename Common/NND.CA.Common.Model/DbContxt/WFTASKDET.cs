namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WFTASKDETS")]
    public partial class WFTASKDET
    {
        [Key]
        [StringLength(14)]
        public string WFTASK_ID { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        [Column(TypeName = "text")]
        public string EVENTDATA { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual WFTASK WFTASK { get; set; }
    }
}
