namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VISITOFFERS")]
    public partial class VISITOFFER
    {
        [Key]
        [StringLength(14)]
        public string VOFFER_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string VOFFERLIST_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string EMP_ID { get; set; }

        [Required]
        [StringLength(1)]
        public string RECSTATUS { get; set; }

        public DateTime? RESPDATE { get; set; }

        public int OFFERSORT { get; set; }

        public decimal OFFERSCORE { get; set; }

        [Column(TypeName = "ntext")]
        public string OFFERDATA { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(60)]
        public string RESPREASON { get; set; }

        [StringLength(1)]
        public string RESPTYPE { get; set; }

        public int? OFFERSORTORIGINAL { get; set; }

        public DateTime? CALLOUTDATE { get; set; }

        public DateTime? NOTIFYDATE { get; set; }

        public DateTime? INTAKE { get; set; }

        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        [StringLength(1)]
        public string MANUALRESPONSE { get; set; }

        public DateTime? UTCRESPDATE { get; set; }

        public DateTime? UTCCALLOUTDATE { get; set; }

        public DateTime? UTCNOTIFYDATE { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }

        public virtual VISITOFFERLIST VISITOFFERLIST { get; set; }
    }
}
