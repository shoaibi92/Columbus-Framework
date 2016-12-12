namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTASSCHANS")]
    public partial class CLTASSCHAN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string CLTASS_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string CHOICE_ID { get; set; }

        [StringLength(80)]
        public string CACTEXT { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        public virtual ASSCHOICE ASSCHOICE { get; set; }

        public virtual CLTASSAN CLTASSAN { get; set; }
    }
}
