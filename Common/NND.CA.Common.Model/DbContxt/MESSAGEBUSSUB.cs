namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSAGEBUSSUBS")]
    public partial class MESSAGEBUSSUB
    {
        [Key]
        [StringLength(14)]
        public string MESSAGESUB_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string MESSAGE_ID { get; set; }

        [Required]
        [StringLength(40)]
        public string MESSAGETARGET { get; set; }

        public int MESSAGESTATE { get; set; }

        public DateTime INTAKEDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime? STATEDATE { get; set; }

        [StringLength(255)]
        public string STATEUSER { get; set; }

        public DateTime? UTCINTAKEDATE { get; set; }

        public DateTime? UTCSTATEDATE { get; set; }

        [Column(TypeName = "text")]
        public string MESSAGERESULTS { get; set; }

        public virtual MESSAGEBU MESSAGEBU { get; set; }
    }
}
