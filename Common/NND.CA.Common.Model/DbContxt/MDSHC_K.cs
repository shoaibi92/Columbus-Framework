namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_K
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(5)]
        public string K_1_PREVENT { get; set; }

        [StringLength(6)]
        public string K_2_PROBLEMS { get; set; }

        [StringLength(5)]
        public string K_3_PROBPHYSICAL { get; set; }

        [StringLength(3)]
        public string K_3_PROBMENTAL { get; set; }

        [StringLength(5)]
        public string K_4_PAIN { get; set; }

        [StringLength(1)]
        public string K_5_FALLS { get; set; }

        [StringLength(2)]
        public string K_6_FALLDANGER { get; set; }

        [StringLength(3)]
        public string K_7_LIFESTYLE { get; set; }

        [StringLength(6)]
        public string K_8_HEALTHSTATUS { get; set; }

        [StringLength(6)]
        public string K_9_OTHERSTATUS { get; set; }

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

        public virtual MD MD { get; set; }
    }
}
