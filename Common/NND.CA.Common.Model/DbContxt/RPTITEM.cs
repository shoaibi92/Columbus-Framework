namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RPTITEMS")]
    public partial class RPTITEM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RITEM_ID { get; set; }

        public int RFOLDER_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string RITEMNAME { get; set; }

        public int? RITEMSIZE { get; set; }

        public int? RITEMTYPE { get; set; }

        public double? RMODIFIED { get; set; }

        public double? RDELETED { get; set; }

        [Column(TypeName = "image")]
        public byte[] RTEMPLATE { get; set; }

        public DateTime? RRUNDATE { get; set; }

        [StringLength(255)]
        public string RRUNUSER { get; set; }

        public DateTime? RCHGDATE { get; set; }

        [StringLength(255)]
        public string RCHGUSER { get; set; }

        public DateTime? RINTAKE { get; set; }

        [StringLength(255)]
        public string RINTAKEUSER { get; set; }
    }
}
