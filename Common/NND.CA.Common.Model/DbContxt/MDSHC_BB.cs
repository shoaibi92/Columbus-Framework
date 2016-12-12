namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_BB
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(1)]
        public string BB_2B_BIRTHEST { get; set; }

        [StringLength(1)]
        public string BB_3_ABORIGINAL { get; set; }

        [StringLength(1)]
        public string BB_4_MARITAL { get; set; }

        [StringLength(3)]
        public string BB_5_LANG { get; set; }

        [StringLength(1)]
        public string BB_6_EDU { get; set; }

        [StringLength(1)]
        public string BB_7A_GUARDIAN { get; set; }

        [StringLength(1)]
        public string BB_7B_MEDDIR { get; set; }

        [StringLength(11)]
        public string BB_8_PAY { get; set; }

        [Required]
        [StringLength(1)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(255)]
        public string STATUSUSER { get; set; }

        public DateTime STATUSDATE { get; set; }

        public DateTime CHGDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string CHGUSER { get; set; }

        [StringLength(10)]
        public string BB_1_SEX { get; set; }

        public DateTime? BB_2A_BIRTHDATE { get; set; }

        [StringLength(14)]
        public string BB_5A_PRILANG { get; set; }

        public virtual MD MD { get; set; }
    }
}
