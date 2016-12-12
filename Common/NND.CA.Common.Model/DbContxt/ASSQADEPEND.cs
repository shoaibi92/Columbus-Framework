namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ASSQADEPENDS")]
    public partial class ASSQADEPEND
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string QUESTION_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(14)]
        public string DQUESTION_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string CHOICE_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string DEXPRESS { get; set; }

        [StringLength(80)]
        public string DVALUE { get; set; }

        public virtual ASSCHOICE ASSCHOICE { get; set; }

        public virtual ASSQDEPEND ASSQDEPEND { get; set; }
    }
}
