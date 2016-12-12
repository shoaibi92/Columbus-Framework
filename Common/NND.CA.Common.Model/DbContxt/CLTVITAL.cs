namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLTVITALS")]
    public partial class CLTVITAL
    {
        [Key]
        [StringLength(14)]
        public string VITALS_ID { get; set; }

        [Required]
        [StringLength(14)]
        public string CLIENT_ID { get; set; }

        public DateTime VDATE { get; set; }

        [Required]
        [StringLength(1)]
        public string VTYPE { get; set; }

        [StringLength(30)]
        public string VSOURCE { get; set; }

        [StringLength(20)]
        public string VHEIGHT { get; set; }

        [StringLength(20)]
        public string VWEIGHT { get; set; }

        [StringLength(20)]
        public string VRESP { get; set; }

        [StringLength(20)]
        public string VTEMP { get; set; }

        public int? PAVALUE { get; set; }

        [StringLength(30)]
        public string PASEVERITY { get; set; }

        public int? PRVALUE { get; set; }

        [StringLength(30)]
        public string PRSEVERITY { get; set; }

        public int? BPSILS { get; set; }

        public int? BPSILD { get; set; }

        public int? BPSIRS { get; set; }

        public int? BPSIRD { get; set; }

        public int? BPSTLS { get; set; }

        public int? BPSTLD { get; set; }

        public int? BPSTRS { get; set; }

        public int? BPSTRD { get; set; }

        public int? BPLYLS { get; set; }

        public int? BPLYLD { get; set; }

        public int? BPLYRS { get; set; }

        public int? BPLYRD { get; set; }

        [Column(TypeName = "text")]
        public string COMMENTS { get; set; }

        public DateTime INTAKE { get; set; }

        [Required]
        [StringLength(255)]
        public string INTAKEUSER { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(1)]
        public string RECSTATUS { get; set; }

        [StringLength(255)]
        public string AUX_ID { get; set; }

        public string PROPS { get; set; }

        public virtual CLIENT CLIENT { get; set; }
    }
}
