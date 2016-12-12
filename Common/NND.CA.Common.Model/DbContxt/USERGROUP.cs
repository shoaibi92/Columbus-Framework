namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERGROUPS")]
    public partial class USERGROUP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string GROUP_ID { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual GROUP GROUP { get; set; }

        public virtual USER USER { get; set; }
    }
}
