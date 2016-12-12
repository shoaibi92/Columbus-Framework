namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSAGEBUSDETAIL")]
    public partial class MESSAGEBUSDETAIL
    {
        [Key]
        [StringLength(14)]
        public string MESSAGE_ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string MESSAGEPAYLOAD { get; set; }

        [Column(TypeName = "text")]
        public string MESSAGEATTRIBS { get; set; }

        [Column(TypeName = "text")]
        public string MESSAGERESULTS { get; set; }

        public virtual MESSAGEBU MESSAGEBU { get; set; }
    }
}
