namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTUSERFOLD")]
    public partial class RPTUSERFOLD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string USER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RFOLDER_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RDSGFOLDER { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public virtual RPTFOLDER RPTFOLDER { get; set; }

        public virtual USER USER { get; set; }
    }
}
