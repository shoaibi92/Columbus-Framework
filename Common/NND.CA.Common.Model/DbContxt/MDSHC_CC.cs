namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_CC
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        public DateTime? CC_1_OPENED { get; set; }

        [StringLength(1)]
        public string CC_2_REFREASON { get; set; }

        [StringLength(6)]
        public string CC_3_GOALS { get; set; }

        [StringLength(1)]
        public string CC_4_LASTHOSP { get; set; }

        [StringLength(1)]
        public string CC_5_RESIDENCE { get; set; }

        [StringLength(1)]
        public string CC_6_ROOMMATE { get; set; }

        [StringLength(1)]
        public string CC_7_PRIORCARE { get; set; }

        [StringLength(1)]
        public string CC_8_RESHIST { get; set; }

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
