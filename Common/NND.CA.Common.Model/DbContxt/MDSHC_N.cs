namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_N
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(1)]
        public string N_1_SKINPROB { get; set; }

        [StringLength(2)]
        public string N_2_ULCERS { get; set; }

        [StringLength(6)]
        public string N_3_OTHERSKINPROB { get; set; }

        [StringLength(1)]
        public string N_4_PRESSUREULCER { get; set; }

        [StringLength(5)]
        public string N_5_WOUNDCARE { get; set; }

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
