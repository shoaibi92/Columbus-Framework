namespace NND.CA.Common.Model.DbContxt
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MDSHC_H
    {
        [Key]
        [StringLength(14)]
        public string MDS_ID { get; set; }

        [StringLength(2)]
        public string H_1A_MEALS { get; set; }

        [StringLength(2)]
        public string H_1B_HOUSEWORK { get; set; }

        [StringLength(2)]
        public string H_1C_FINANCES { get; set; }

        [StringLength(2)]
        public string H_1D_MEDS { get; set; }

        [StringLength(2)]
        public string H_1E_PHONE { get; set; }

        [StringLength(2)]
        public string H_1F_SHOPPING { get; set; }

        [StringLength(2)]
        public string H_1G_TRANSPORT { get; set; }

        [StringLength(10)]
        public string H_2_ADLSELF { get; set; }

        [StringLength(1)]
        public string H_3_ADLDECLINE { get; set; }

        [StringLength(2)]
        public string H_4_LOCOMOTION { get; set; }

        [StringLength(1)]
        public string H_5_STAIRS { get; set; }

        [StringLength(2)]
        public string H_6_STAMINA { get; set; }

        [StringLength(4)]
        public string H_7_POTENTIAL { get; set; }

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
